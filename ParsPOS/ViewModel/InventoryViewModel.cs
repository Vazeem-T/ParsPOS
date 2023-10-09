﻿using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.Services;
using ParsPOS.Views;
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
    public class InventoryViewModel : INotifyPropertyChanged
    {
        // Implement INotifyPropertyChanged interface (you can use a library like Prism or PropertyChanged.Fody for this)
        public event PropertyChangedEventHandler PropertyChanged;


        private ObservableCollection<Invitm> items;
        private int currentPage = 1;
        private int itemsPerPage = 15;
        private bool isDownloading;
        public DownloadViewModel downloadViewModel;
        private int apicurrentPage = 1;
        private readonly HttpClient client;

        public ObservableCollection<Invitm> Items
        {
            get => items;
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged(nameof(Items));
                }
            }
        }

        public ICommand LoadDataCommand { get; }
        public InventoryViewModel()
        {
            Items = new ObservableCollection<Invitm>();
            LoadDataAsync().GetAwaiter(); // Load initial data
            LoadDataCommand = new Command(async () => await LoadDataAsync());
            #if DEBUG
            HttpClientHandlerService handler = new HttpClientHandlerService();
            client = new HttpClient(handler.GetPlatformMessageHandler());       
            #else
            client = new HttpClient();
            #endif
            DownloadCommand = new Command(async () => await DownloadDataAsync());
            downloadViewModel = new DownloadViewModel();
        }
        private bool isLoadingMore;
        public bool IsLoadingMore
        {
            get => isLoadingMore;
            set
            {
                if (isLoadingMore != value)
                {
                    isLoadingMore = value;
                    OnPropertyChanged(nameof(IsLoadingMore));
                }
            }
        }

        private bool isBusy = false; // Add this field

        private async Task LoadDataAsync()
        {
            if (isBusy)
                return;

            isBusy = true;
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
                isBusy = false;
                IsLoadingMore = false;
            }
        }
        //Download Product


        public bool IsDownloading
        {
            get { return isDownloading; }
            set
            {
                isDownloading = value;
                OnPropertyChanged(nameof(IsDownloading));
            }
        }


        public Command DownloadCommand { get; }

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
                // Handle exceptions
                // You can log the error or show an alert
                throw ex;
            }
        }

        private async Task<int> DownloadDataAsync()
        {
            IsDownloading = true;
            int Progress = 0;
            try
            {
                var baseurl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.10.1.212:7252" : "https://localhost:7252";
                string countApiUrl = $"{baseurl}/api/ImportDb/GetInvItemCount";
                string dataApiUrl = $"{baseurl}/api/ImportDb/InvItm?page=";

                // Get the total count directly from the API
                int totalCount = await GetTotalItemCountAsync(countApiUrl);
                downloadViewModel.TotalCount = totalCount;

                var result = await App.Current.MainPage.DisplayAlert("Alert",$"Do you want to delete products and update ?","Yes","No");
                if(result)
                {
                    await App.Database.DeleteAllInvItm();

                    while (Progress < totalCount)
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

                            Progress += pageData.Count;
                            apicurrentPage++;
                            downloadViewModel.Progress = Progress;
                            downloadViewModel.ProgressText = $"{Progress}/{totalCount}";

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
                IsDownloading = false;
            }

            return Progress;
        }




        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Debug.WriteLine($"Property {propertyName} changed.");
        }
    }
}