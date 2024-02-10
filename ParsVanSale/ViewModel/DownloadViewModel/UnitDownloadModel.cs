using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsVanSale.Model;
using ParsVanSale.Services;
using System.Linq.Expressions;

namespace ParsVanSale.ViewModel.DownloadViewModel
{
    public partial class UnitDownloadModel : BaseViewModel
    {
        private CommonHttpServices commonHttpServices;
        private readonly HttpClient client;
        private DownloadViewmodel _downloadViewmodel;
        private int apicurrentPage = 1;
        int downloadId = 0;
        public UnitDownloadModel()
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
                string countApiUrl = $"{baseurl}/ImportDb/GetUnitCount"; //Change
                string dataApiUrl = $"{baseurl}/ImportDb/UnitsTbDet?page="; //Change
                int Count = await GetTotalItemCountAsync(countApiUrl);
				Expression<Func<UnitsTb, string>> orderBy = item => item.Units;
				var unit = await App.Database.GetFirstAsync(null, orderBy);
                if(unit != null)
                {
					await App.Database.DeleteAll<UnitsTb>();//Change
				}
				
                await App.Database.InsertAsync(new DownloadDt //Change
                {
                    Description = "Downloading",
                    DownloadDescription = "Unit Detail",
                    DownloadTime = DateTime.Now,
                    IsRunning = true,
                    TotalCount = Count,
                    Progress = 0
                });
                DownloadDt downloadDt = await App.Database.GetDownloadItm("Unit Detail"); //Change
                downloadId = downloadDt.DownloadId;
                int index = _downloadViewmodel.DownloadItem.IndexOf(_downloadViewmodel.DownloadItem.FirstOrDefault(item => item.DownloadId == downloadId));
                while (loadProgress < Count)
                {
                    string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var pageData = JsonConvert.DeserializeObject<List<UnitsTb>>(content);//Change

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
                        await Shell.Current.DisplayAlert("Alert", "Failed to download Unit Detail Check the Api Connection or Contact the Admin", "OK");
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
				string dataApiUrl = $"{baseurl}/DirectDb/GetModiUnit?date="; //Change
				string pageDataUrl = $"{dataApiUrl}{date}";
				HttpResponseMessage response = await client.GetAsync(pageDataUrl);
				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					var pageData = JsonConvert.DeserializeObject<List<UnitsTb>>(content);//Change
					if (pageData != null)
					{
						foreach (var item in pageData)
						{
							Expression<Func<UnitsTb, bool>> predicate = item => item.Units == item.Units;
							var chk = await App.Database.GetFirstAsync<UnitsTb, bool>(predicate, null);
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
