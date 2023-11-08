using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.Services;
using System.Collections.ObjectModel;


namespace ParsPOS.ViewModel
{
    public partial class CategoryViewModel : BaseViewModel 
    {
        private int currentPage = 1;
        private int itemsPerPage = 15;
        private int parent = 1;
        private int child = 2;
        public ObservableCollection<RGrpItmTb> Items { get; } = new();
        private int apicurrentPage = 1;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;
        //private PublicSevices publicSevices = new PublicSevices();
        public CategoryViewModel()
        {
            LoadDataAsync().GetAwaiter();
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
            SelectedIndex = 0;
        }

        [ObservableProperty]
        RGrpItmTb selectedGrpItm;

        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;
           
            try
            {
                if (SelectedIndex > 0)
                {
                    // Load data for the current page
                    var pageData = await App.Database.GetAllGrpItm(currentPage, itemsPerPage, parent, child);

                    if (pageData.Any())
                    {
                        foreach (var item in pageData)
                        {
                            Items.Add(item);
                           
                        }
                        currentPage++;
                    }
                }
                else
                {
                    var pageData = await App.Database.GetAllFirstGrpItm(currentPage, itemsPerPage);

                    if (pageData.Any())
                    {
                        foreach (var item in pageData)
                        {
                            Items.Add(item);
                        }
                        currentPage++;
                    }
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
        [RelayCommand]
        async Task CategoryUpdate()
        {
            try
            {
                if (SelectedGrpItm != null)
                {
                    await App.Database.UpdateGrpItm(SelectedGrpItm);
                }
                currentPage = 1;
                Items.Clear();
                await LoadDataAsync();
                
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
            
        }

        [RelayCommand]
        async Task SelectedItem(RGrpItmTb selecteditem)
        {
            SelectedGrpItm = selecteditem;
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
                // Handle exceptions
                // You can log the error or show an alert
                throw ex;
            }
        }
        [RelayCommand]
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
                        Items.Clear();
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

        //Custom Tab
        
        int selectedIndex;

        public int SelectedIndex 
        {
            get => selectedIndex; 
            set
            {
                if(selectedIndex != value)
                {
                    selectedIndex = value;
                    IndexChange().GetAwaiter();
                    OnPropertyChanged(nameof(SelectedIndex));
                }
            }
        }
        async Task IndexChange()
        {
            parent = SelectedIndex + 1;
            child = parent + 1;
            currentPage = 1;
            Items.Clear();
            await LoadDataAsync();
        }
    }
}
