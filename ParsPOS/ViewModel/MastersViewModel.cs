using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
	public partial class MastersViewModel : BaseViewModel
 	{
		public ObservableCollection<AccMast> Items { get; set; } = new();
		int downloadId = 0;
		private int apicurrentPage = 1;
		private readonly HttpClient client;
		private CommonHttpServices commonHttpServices;
		[ObservableProperty]
		int currentCount;
		public MastersViewModel()
		{
			commonHttpServices = new CommonHttpServices();
			client = commonHttpServices.GetHttpClient();
		}
		private async Task<int> GetTotalItemCountAsync(string apiUrl)
		{
			try
			{
				HttpResponseMessage response = await client.GetAsync(apiUrl);

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					return JsonConvert.DeserializeObject<int>(content);
				}
				else
				{
					// Handle the case where the API request was not successful
					throw new Exception("Failed to retrieve total item count.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		[RelayCommand]
		private async Task<int> DownloadDataAsync()
		{
			IsDownloading = true;
			int Progress = 0;
			int loadProgress = 0;
			try
			{

				var baseurl = commonHttpServices.GetBaseUrl();

				string countApiUrl = $"{baseurl}/api/ImportDb/AccMastTbCount";
				string dataApiUrl = $"{baseurl}/api/ImportDb/AccMastTb?page=";

				// Get the total count directly from the API
				int Count = await GetTotalItemCountAsync(countApiUrl);
				//downloadViewModel.TotalCount = totalCount;
				CurrentCount = Count;

				var result = await App.Current.MainPage.DisplayAlert("Alert", $"Do you want to delete Masters and update ?", "Yes", "No");
				if (result)
				{
					await App.Database.DeleteAllMasters();
					Items.Clear();
					await App.SaleDb.CreateDownloadDt(new SaleModel.DownloadDt
					{
						Description = "Downloading",
						DownloadDescription = "Masters",
						DownloadTime = DateTime.Now,
						IsRunning = true,
						TotalCount = Count,
						Progress = 0
					});
					SaleModel.DownloadDt downloadDt = await App.SaleDb.GetDownloadItm("Masters");
					downloadId = downloadDt.DownloadId;
					while (loadProgress < Count)
					{
						string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";
						using (HttpResponseMessage response = await client.GetAsync(pageDataUrl))
						{
							if (response.IsSuccessStatusCode)
							{
								string content = await response.Content.ReadAsStringAsync();
								var pageData = JsonConvert.DeserializeObject<List<AccMast>>(content);

								foreach (var item in pageData)
								{
									await App.Database.CreateAccMast(item);
									loadProgress = loadProgress + 1;
									await App.SaleDb.UpdateDownloadProgress(downloadId, loadProgress);
								}
								if (apicurrentPage == 1) /*LoadDataCommand.Execute(null);*/
									Progress += pageData.Count;
								apicurrentPage++;
							}
							else
							{
								// Handle the case where the API request was not successful
								throw new Exception("Failed to download data.");
							}
						}
					}
					await App.SaleDb.UpdateDownloadComplete(downloadId, true);
				}

			}
			catch (Exception ex)
			{
				await App.SaleDb.UpdateDownloadComplete(downloadId, false);
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
			finally
			{
				IsDownloading = true;

			}
			return Progress;
		}
	}
}
