using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public partial class UserViewModel : BaseViewModel
    {
        private int currentPage = 1;
        private int itemsPerPage = 15;
        public ObservableCollection<User> Items { get; } = new();
        private int apicurrentPage = 1;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;
        public UserViewModel()
        {
            LoadDataAsync().GetAwaiter();
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
        }


        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                 //Load data for the current page
                var pageData = await App.Database.GetAllUserDt(currentPage, itemsPerPage);
                
                if (pageData.Any())
                {
                    foreach (var item in pageData)
                    {
                        Items.Add(item);
                
                    }
                    currentPage++;
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;

            }
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
                    // Handle the case where the API request was not successful
                    throw new Exception("Failed to retrieve total item count.");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // You can log the error or show an alert
                throw ex;
            }
        }
        [RelayCommand]
        private async Task<int> DownloadUserAsync()
        {
            IsDownloading = true;
            int Progress = 0;
            try
            {
                var baseurl = commonHttpServices.GetBaseUrl();
                string countApiUrl = $"{baseurl}/api/ImportDb/UserCount";
                string dataApiUrl = $"{baseurl}/api/ImportDb/UserDt?page=";

                var Count = await GetTotalItemCountAsync(countApiUrl);
                int largestcount = Math.Max(Math.Max(Count.UserCount, Count.RightCount), Count.RightNodeCount);

                var result = await App.Current.MainPage.DisplayAlert("Alert", $"Do you want to delete User And Their Right and Update This ! ?", "Yes", "No");
                if (result)
                {
                   // await App.Database.DeleteAllGrpItm();
                   // Items.Clear();

                    while (Progress < largestcount)
                    {
                        string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                        HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            UserRDt pageData = JsonConvert.DeserializeObject<UserRDt>(content);

                            foreach (var item in pageData.User)
                            {
                                await App.Database.CreateUser(item);
                            }
                            foreach (var item in pageData.Rights)
                            {
                                await App.Database.CreateRights(item);
                            }
                            foreach (var item in pageData.RightNode)
                            {
                                await App.Database.CreateRightNode(item);
                            }
                            if (apicurrentPage == 1) await LoadDataAsync();
                            apicurrentPage++;
                            Progress += pageData.RightNode.Count;
                        }
                        else
                        {
                            throw new Exception("Failed to download data.");
                        }
                    }
                    apicurrentPage = 1;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // You can log the error or show an alert
            }
            finally
            {
                IsDownloading = false;
            }
            return Progress;
        }
        public async Task DownloadRights()
        {
            try
            {
                int Progress = 0;
                var baseurl = commonHttpServices.GetBaseUrl();
                string countApiUrl = $"{baseurl}/api/ImportDb/UserCount";
                string dataApiUrl = $"{baseurl}/api/ImportDb/UserDt?page=";

                var Count = await GetTotalItemCountAsync(countApiUrl);
                while (Progress < Count.RightCount)
                {
                    string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var pageData = JsonConvert.DeserializeObject<List<GrpItmTb>>(content);

                        foreach (var item in pageData)
                        {
                            await App.Database.CreateGrpItmTb(item);
                            Console.WriteLine(item.Description);
                        }
                        if (apicurrentPage == 1) await LoadDataAsync();
                        apicurrentPage++;
                        Progress += pageData.Count;
                    }
                    else
                    {
                        // Handle the case where the API request was not successful
                        throw new Exception("Failed to download data.");
                    }
                }
                apicurrentPage = 1;
                await DownloadRightNode(dataApiUrl, Count.RightNodeCount);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        public async Task DownloadRightNode(string dataApiUrl, int RightNodeCount)
        {
            try
            {
                int Progress = 0;
                while (Progress < RightNodeCount)
                {
                    string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var pageData = JsonConvert.DeserializeObject<List<GrpItmTb>>(content);

                        foreach (var item in pageData)
                        {
                            await App.Database.CreateGrpItmTb(item);
                            Console.WriteLine(item.Description);
                        }
                        if (apicurrentPage == 1) await LoadDataAsync();
                        apicurrentPage++;
                        Progress += pageData.Count;
                    }
                    else
                    {
                        // Handle the case where the API request was not successful
                        throw new Exception("Failed to download data.");
                    }
                }
                apicurrentPage++;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
