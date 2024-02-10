using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsVanSale.Model;
using ParsVanSale.Services;

namespace ParsVanSale.ViewModel.DownloadViewModel
{
    public partial class  SupplierDownloadModel : BaseViewModel
    {
        private CommonHttpServices commonHttpServices;
        private readonly HttpClient client;
        private DownloadViewmodel _downloadViewmodel;
        private int apicurrentPage = 1;
        int downloadId = 0;
        public SupplierDownloadModel()
        {
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
            _downloadViewmodel = new DownloadViewmodel();
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
                return 0;
            }
        }


        [RelayCommand]
        private async Task<int> DownloadDataAsync()
        {
            //IsDownloading = true;
            int Progress = 0;
            int loadProgress = 0;
            try
            {
                var baseurl = commonHttpServices.GetBaseUrl();
                string countApiUrl = $"{baseurl}/ImportDb/AccMastTbCount"; //Change
                string dataApiUrl = $"{baseurl}/ImportDb/AccMastTb?page="; //Change
                int Count = await GetTotalItemCountAsync(countApiUrl);
				Expression<Func<AccMast, int>> orderBy = item => item.AccountNo;
				var accmast = await App.Database.GetFirstAsync(null, orderBy);
                if(accmast != null)
                {
					await App.Database.DeleteAll<AccMast>();//Change
				}
                await App.Database.InsertAsync(new DownloadDt //Change
                {
                    Description = "Downloading",
                    DownloadDescription = "Party Detail",
                    DownloadTime = DateTime.Now,
                    IsRunning = true,
                    TotalCount = Count,
                    Progress = 0
                });
                DownloadDt downloadDt = await App.Database.GetDownloadItm("Party Detail"); //Change
                downloadId = downloadDt.DownloadId;
                int index = _downloadViewmodel.DownloadItem.IndexOf(_downloadViewmodel.DownloadItem.FirstOrDefault(item => item.DownloadId == downloadId));
                while (loadProgress < Count)
                {
                    string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var pageData = JsonConvert.DeserializeObject<List<AccMast>>(content);//Change

                        foreach (var item in pageData)
                        {
                            await App.Database.InsertAsync(item);
                            loadProgress = loadProgress + 1;
                            await App.Database.UpdateDownloadProgress(downloadId, loadProgress);

                            if (index != -1)
                            {
                                downloadDt.Progress = loadProgress;
                                _downloadViewmodel.DownloadItem[index] = downloadDt;
                                OnPropertyChanged(nameof(_downloadViewmodel.DownloadItem));
                            }

                        }
                        apicurrentPage++;
                    }
                    else
                    {
                        // Handle the case where the API request was not successful

                        //Change
                        await Shell.Current.DisplayAlert("Alert", "Failed to download Party Detail Check the Api Connection or Contact the Admin", "OK");
                    }
                }
                await App.Database.UpdateDownloadComplete(downloadId, true);
                if (index != -1)
                {
                    downloadDt.IsSuccess = true;
                    _downloadViewmodel.DownloadItem[index] = downloadDt;
                    OnPropertyChanged(nameof(_downloadViewmodel.DownloadItem));
                }

            }
            catch (Exception ex)
            {
                await App.Database.UpdateDownloadComplete(downloadId, false);
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
            finally
            {
				client.Dispose();
				//IsDownloading = true;
			}
            return Progress;
        }

		[RelayCommand]
		private async Task BackgroundCheck(string date)
		{
			try
			{
				var baseurl = commonHttpServices.GetBaseUrl();
				string dataApiUrl = $"{baseurl}/DirectDb/GetModiSupplier?date="; //Change
				string pageDataUrl = $"{dataApiUrl}{date}";
				HttpResponseMessage response = await client.GetAsync(pageDataUrl);
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					var pageData = JsonConvert.DeserializeObject<List<AccMast>>(content);//Change
                    if(pageData != null)
                    {
						foreach (var item in pageData)
						{
							Expression<Func<AccMast, bool>> predicate = item => item.AccountNo == item.AccountNo;
							var chk = await App.Database.GetFirstAsync<AccMast, bool>(predicate, null);
							if (chk != null)
							{
								await App.Database.UpdateAsync(item);
							}
							else
							{
								await App.Database.InsertAsync(item);
							}
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
