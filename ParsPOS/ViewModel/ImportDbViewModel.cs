using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public partial class ImportDbViewModel : BaseViewModel
    {
        readonly InventoryViewModel _inventorymodel;
        readonly CategoryViewModel _categorymodel ;
        readonly BaseItmDetViewModel _baseItmDetmodel;
        readonly UnitsViewModel _unitsViewModel;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;

        public ImportDbViewModel(InventoryViewModel inventoryModel, CategoryViewModel categoryModel,BaseItmDetViewModel baseItmDetViewModel,
             UnitsViewModel unitsViewModel) 
        {
            _inventorymodel = inventoryModel;
            _categorymodel = categoryModel;
            _baseItmDetmodel = baseItmDetViewModel;
            _unitsViewModel = unitsViewModel;
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
        }
        
        [ObservableProperty]
        bool product;
        
        [ObservableProperty]
        bool accounts;
        
        [ObservableProperty]
        bool barcode;
        
        [ObservableProperty]
        bool user;
        
        [ObservableProperty]
        bool category;
        
        [ObservableProperty]
        bool prefix;

        [ObservableProperty]
        bool baseItm;
        [ObservableProperty]
        bool units;

        [RelayCommand]
        async Task ImportAsync()
        {
            try
            {
                if (Product)
                {
                    _inventorymodel.DownloadDataCommand.Execute(null);
                }
                if (Category)
                {
                    _categorymodel.DownloadCategoryCommand.Execute(null);
                }
                if (Prefix)
                {
                    ImportPrefixCommand.Execute(null);
                }
                if (BaseItm)
                {
                    _baseItmDetmodel.DownloadDataCommand.Execute(null);
                }
                if(Units)
                {
                    _unitsViewModel.DownloadDataCommand.Execute(null);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
            
        }

        [RelayCommand]
        async Task ImportPrefix()
        {
            IsDownloading = true;
            try
            {
                var baseurl = commonHttpServices.GetBaseUrl();
                string dataApiUrl = $"{baseurl}/api/ImportDb/ImportPrefix";

                var result = await App.Current.MainPage.DisplayAlert("Alert", $"Do you want to delete Pefix and update ?", "Yes", "No");
                if (result)
                {
                    
                    string pageDataUrl = $"{dataApiUrl}";

                    HttpResponseMessage response = await client.GetAsync(pageDataUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        var pageData = JsonConvert.DeserializeObject<List<PreFixTb>>(content);

                        foreach (var item in pageData)
                        {
                            await App.Database.CreatePrefixTb(item);
                        }
                    }
                    else
                    {
                        // Handle the case where the API request was not successful
                        throw new Exception("Failed to download data.");
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
        }

        public async Task DownloadUser()
        {

        }
    }
}
