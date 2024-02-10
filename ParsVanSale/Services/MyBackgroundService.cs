using Microsoft.Extensions.Hosting;
using ParsVanSale.Model;
using ParsVanSale.ViewModel.DownloadViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.Services
{
    public class MyBackgroundService : BackgroundService
	{
		private HttpClient client;
		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			try
			{
				while (!stoppingToken.IsCancellationRequested)
				{
					var current = Connectivity.NetworkAccess;

					if (current == NetworkAccess.Internet)
					{
						//#if DEBUG
						HttpClientHandlerService handler = new HttpClientHandlerService();
						client = new HttpClient(handler.GetPlatformMessageHandler());
						//#else
						//        client = new HttpClient();
						//#endif
						Expression<Func<NetworkIP, bool>> predicate = item => item.IsConnected == true;
						var network = await App.Database.GetFirstAsync<NetworkIP, bool>(predicate, null);
						if (network != null)
						{
							var api = $"{network.Protocol}://{network.IPAddress}/API/DirectDb/Healthchk";
							client.BaseAddress = new Uri(api);
							HttpResponseMessage response = await client.GetAsync("");
							if (response.IsSuccessStatusCode)
							{
								Expression<Func<SettingsTb, int>> orderby = item => item.Id;
								var settings = await App.Database.GetFirstAsync(null, orderby);
								if (settings != null)
								{
									if (settings.LstImportTime != null)
									{
										//Product Background Check
										string prdchk = $"{network.Protocol}://{network.IPAddress}/API/DirectDb/GetDbUpdateDetail?date={settings.LstImportTime.ToString() ?? DateTime.Now.ToString()}&tablename=Product";
										HttpResponseMessage prodrespose = await client.GetAsync(prdchk);
										if (response.IsSuccessStatusCode)
										{
											ProductDownloadModel productDownloadModel = new();
											productDownloadModel.BackgroundCheckCommand.Execute(settings.LstImportTime.ToString() ?? DateTime.Now.ToString());
										}
										//Supplier Background Check

										string supchk = $"{network.Protocol}://{network.IPAddress}/API/DirectDb/GetDbUpdateDetail?date={settings.LstImportTime.ToString() ?? DateTime.Now.ToString()}&tablename=Account";
										HttpResponseMessage supprespose = await client.GetAsync(supchk);
										if (response.IsSuccessStatusCode)
										{
											SupplierDownloadModel supplierDownloadModel = new();
											supplierDownloadModel.BackgroundCheckCommand.Execute(settings.LstImportTime.ToString() ?? DateTime.Now.ToString());
										}
										//Unit Background Check

										string unitchk = $"{network.Protocol}://{network.IPAddress}/API/DirectDb/GetDbUpdateDetail?date={settings.LstImportTime.ToString() ?? DateTime.Now.ToString()}&tablename=Unit";
										HttpResponseMessage unitrespose = await client.GetAsync(unitchk);
										if (response.IsSuccessStatusCode)
										{
											UnitDownloadModel unitDownloadModel = new();
											unitDownloadModel.BackgroundCheckCommand.Execute(settings.LstImportTime.ToString() ?? DateTime.Now.ToString());
										}
									}
								}

							}
						}
						
					}
					await Task.Delay(TimeSpan.FromSeconds(10000), stoppingToken);
				}
			}
			catch (Exception ex)
			{
			}
		}
	}
}
