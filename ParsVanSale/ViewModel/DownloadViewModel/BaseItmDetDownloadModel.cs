using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsVanSale.Services;
using ParsVanSale.Model;
using System.Linq.Expressions;

namespace ParsVanSale.ViewModel.DownloadViewModel
{
    public partial class BaseItmDetDownloadModel : BaseViewModel
    {
        private CommonHttpServices commonHttpServices;
        private readonly HttpClient client;
        private DownloadViewmodel _downloadViewmodel;
        private int apicurrentPage = 1;
        int downloadId = 0;
        public BaseItmDetDownloadModel()
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
                string countApiUrl = $"{baseurl}/ImportDb/GetBaseItemCount"; //Change
                string dataApiUrl = $"{baseurl}/ImportDb/BaseItmDet?page="; //Change
                int Count = await GetTotalItemCountAsync(countApiUrl);
				Expression<Func<BaseItmDet, int>> orderBy = item => item.BaseItemId;
				var baseitmtb = await App.Database.GetFirstAsync(null, orderBy);
                if(baseitmtb != null)
                {
					await App.Database.DeleteAll<BaseItmDet>();//Change
				}
                await App.Database.InsertAsync(new DownloadDt //Change
                {
                    Description = "Downloading",
                    DownloadDescription = "Base Item Detail",
                    DownloadTime = DateTime.Now,
                    IsRunning = true,
                    TotalCount = Count,
                    Progress = 0
                });
                DownloadDt downloadDt = await App.Database.GetDownloadItm("Base Item Detail"); //Change
                downloadId = downloadDt.DownloadId;
                int index = _downloadViewmodel.DownloadItem.IndexOf(_downloadViewmodel.DownloadItem.FirstOrDefault(item => item.DownloadId == downloadId));
                while (loadProgress < Count)
                {
                    string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var pageData = JsonConvert.DeserializeObject<List<BaseItmDet>>(content);//Change

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
                        await Shell.Current.DisplayAlert("Alert", "Failed to download Base Item Detail Check the Api Connection or Contact the Admin", "OK");
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
    }
}
