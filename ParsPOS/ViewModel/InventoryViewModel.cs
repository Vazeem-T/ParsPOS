using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.Services;
using ParsPOS.Views;
using ParsPOS.Views.SubForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public partial class InventoryViewModel : BaseViewModel
    {
        public ObservableCollection<Invitm> Items { get; set; } = new();
        private int currentPage = 1;
        private int itemsPerPage = 15;
        private DownloadViewModel downloadViewModel;
        private int apicurrentPage = 1;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;
       
        public InventoryViewModel()
        {
            LoadDataCommand.Execute(null);
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
            downloadViewModel = new DownloadViewModel();
        }
        [ObservableProperty]
        bool isLoadingMore;

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            IsLoadingMore = true;
            try
            {
                // Load data for the current page
                var pageData = await App.Database.GetAllInvItmPaged(currentPage, itemsPerPage);

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
                IsLoadingMore = false;
            }
        }

        //Download Product
        [ObservableProperty]
        bool isDownloading;
        [ObservableProperty]
        int currentCount;

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
            try
            {
                var baseurl = commonHttpServices.GetBaseUrl();
                string countApiUrl = $"{baseurl}/api/ImportDb/GetInvItemCount";
                string dataApiUrl = $"{baseurl}/api/ImportDb/InvItm?page=";

                // Get the total count directly from the API
                int Count = await GetTotalItemCountAsync(countApiUrl);
                //downloadViewModel.TotalCount = totalCount;
                CurrentCount = Count;

                var result = await App.Current.MainPage.DisplayAlert("Alert", $"Do you want to delete products and update ?", "Yes", "No");
                if (result)
                {
                    await App.Database.DeleteAllInvItm();
                    Items.Clear();
                    while (Progress < Count)
                    {
                        string pageDataUrl = $"{dataApiUrl}{apicurrentPage}";

                        HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string content = await response.Content.ReadAsStringAsync();
                            var pageData = JsonConvert.DeserializeObject<List<Invitm>>(content);

                            foreach (var item in pageData)
                            {
                                await App.Database.CreateInvItm(item);
                            }
                            if (apicurrentPage == 1) LoadDataCommand.Execute(null);
                            Progress += pageData.Count;
                            apicurrentPage++;
                            downloadViewModel.Progress = Progress;
                            downloadViewModel.ProgressText = $"{Progress}/{Count}";
                        }
                        else
                        {
                            // Handle the case where the API request was not successful
                            throw new Exception("Failed to download data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // You can log the error or show an alert
            }
            finally
            {
                IsDownloading = true;
            }
            return Progress;
        }
        //Search Handler
        [RelayCommand]
        private async Task SearchProductAsync(string searchText)
        {
            Items.Clear();
            var pageData = await App.Database.GetProductsAsync(searchText);
            if (pageData.Any())
            {
                foreach (var item in pageData)
                {
                    Items.Add(item);
                }
            }
        }
        [RelayCommand]
        async Task GoToCategoryAsync()
        {

            await Shell.Current.GoToAsync(nameof(AddCategory));
        }
    }
}
