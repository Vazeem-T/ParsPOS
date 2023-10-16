using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int currentPage = 1;
        private int itemsPerPage = 15;
        private ObservableCollection<RGrpItmTb> items;
        private int apicurrentPage = 1;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;
        private PublicSevices publicSevices = new PublicSevices();

        public CategoryViewModel() 
        {
            Items = new ObservableCollection<RGrpItmTb>();
            LoadDataAsync().GetAwaiter();
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
            CatogeryDownloadCommand = new Command(async () => await DownloadCategoryAsync());
            LoadDataCommand = new Command(async () => await LoadDataAsync());
        }

        public ICommand LoadDataCommand { get; }
        public ObservableCollection<RGrpItmTb> Items
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

        private bool isDownloading = false;

        public bool IsDownloading
        {
            get { return isDownloading; }
            set
            {
                isDownloading = value;
                OnPropertyChanged(nameof(IsDownloading));
            }
        }
        private async Task LoadDataAsync()
        {
            if (isBusy)
                return;

            isBusy = true;
            IsLoadingMore = true;
            try
            {
                // Load data for the current page
                var pageData = await App.Database.GetAllGrpItm(currentPage, itemsPerPage);

                if (pageData.Any())
                {
                    foreach (var item in pageData)
                    {
                        //RGrpItmTb thing = new { GrpItmCode = $"Code {item}", Description = $"Desc {item}", PCode = $"PCode {item}", PName = $"PName {item}" };
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


        public Command CatogeryDownloadCommand { get; }

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
        private async Task<int> DownloadCategoryAsync()
        {
            IsDownloading = true;
            int Progress = 0;
            try
            {
                var baseurl = commonHttpServices.GetBaseUrl();
                string countApiUrl = $"{baseurl}/api/ImportDb/GetCategoryCount";
                string dataApiUrl = $"{baseurl}/api/ImportDb/Category?page=";

                int Count = await GetTotalItemCountAsync(countApiUrl);
                
                var result = await App.Current.MainPage.DisplayAlert("Alert", $"Do you want to delete Category and update ?", "Yes", "No");
                if (result)
                {

                    //if(await publicSevices.CheckIfTableExistsAsync("GrpitmTb"))
                    //{
                        await App.Database.DeleteAllGrpItm();
                        Items = new ObservableCollection<RGrpItmTb>();
                    //}
                    
                    while (Progress < Count)
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

            // Get the property value using reflection
            var propertyInfo = GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                var propertyValue = propertyInfo.GetValue(this);
                Debug.WriteLine($"Current value of {propertyName}: {propertyValue}");
            }
        }
    }
}
