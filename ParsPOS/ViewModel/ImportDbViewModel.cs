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
        readonly InventoryViewModel inventorymodel;
        readonly CategoryViewModel categorymodel ;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;

        public ImportDbViewModel(InventoryViewModel inventoryModel, CategoryViewModel categoryModel) 
        {
            inventorymodel = inventoryModel;
            categorymodel = categoryModel;
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

        [RelayCommand]
        async Task ImportAsync()
        {
            if(Product) 
            {
                inventorymodel.DownloadDataCommand.Execute(null);
            }
            if(Category)
            {
                categorymodel.DownloadCategoryCommand.Execute(null);
            }
            if(Prefix)
            {
                ImportPrefixCommand.Execute(null);
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
