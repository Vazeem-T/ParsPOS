using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsVanSale.Model;
using ParsVanSale.RModel;
using ParsVanSale.Services;
using System.Linq.Expressions;

namespace ParsVanSale.ViewModel.DownloadViewModel
{
    public partial class UserDownloadModel : BaseViewModel
    {
        private CommonHttpServices commonHttpServices;
        private readonly HttpClient client;
        private DownloadViewmodel _downloadViewmodel;
        private int apicurrentPage = 1;
        int downloadId = 0;
        public UserDownloadModel()
        {
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
            _downloadViewmodel = new DownloadViewmodel();
        }
        private async Task<UserCountRModel> GetTotalItemCountAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<UserCountRModel>(content);
                }
                else
                {
                    throw new Exception("Failed to retrieve total item count.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [RelayCommand]
        private async Task<int> DownloadUserAsync()
        {
            int loadProgress = 0;
            try
            {
                var baseurl = commonHttpServices.GetBaseUrl();
                string countApiUrl = $"{baseurl}/ImportDb/UserCount";
                string dataApiUrl = $"{baseurl}/ImportDb/UserDt?page=";

                var Count = await GetTotalItemCountAsync(countApiUrl);
                int largestcount = Math.Max(Math.Max(Count.UserCount, Count.RightCount), Count.RightNodeCount);
				Expression<Func<User, string>> orderBy = item => item.UserId;
				var user = await App.Database.GetFirstAsync(null, orderBy);
                {
					await App.Database.DeleteAll<User>();
					await App.Database.DeleteAll<RightNode>();
					await App.Database.DeleteAll<Rights>();
				}
                await App.Database.InsertAsync(new DownloadDt //Change
                {
                    Description = "Downloading",
                    DownloadDescription = "User Detail",
                    DownloadTime = DateTime.Now,
                    IsRunning = true,
                    TotalCount = largestcount,
                    Progress = 0
                });
                DownloadDt downloadDt = await App.Database.GetDownloadItm("User Detail"); //Change
                downloadId = downloadDt.DownloadId;
                int index = _downloadViewmodel.DownloadItem.IndexOf(_downloadViewmodel.DownloadItem.FirstOrDefault(item => item.DownloadId == downloadId));


                while (loadProgress < largestcount)
                {
                    string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        UserRDt pageData = JsonConvert.DeserializeObject<UserRDt>(content);

                        foreach (var item in pageData.User)
                        {
                            await App.Database.InsertAsync(item);
						}
                        foreach (var item in pageData.Rights)
                        {
                            await App.Database.InsertAsync(item);
                        }
                        foreach (var item in pageData.RightNode)
                        {
                            await App.Database.InsertAsync(item);
							loadProgress++;
						}
                        apicurrentPage++;

                        await App.Database.UpdateDownloadProgress(downloadId, loadProgress);

                        if (index != -1)
                        {
                            downloadDt.Progress = loadProgress;
                            _downloadViewmodel.DownloadItem[index] = downloadDt;
                            OnPropertyChanged(nameof(_downloadViewmodel.DownloadItem));
                        }
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Alert", "Failed to download User Detail Check the Api Connection or Contact the Admin", "OK");
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
			}
            return loadProgress;
        }
    }
}
