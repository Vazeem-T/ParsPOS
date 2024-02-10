using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
    public partial class DownloadViewmodel : BaseViewModel
    {
        public ObservableCollection<DownloadDt> DownloadItem { get; set; } = new();

        [ObservableProperty]
        DownloadDt downloadDt;

        [ObservableProperty]
        bool indicator = false;
       

		[RelayCommand]
        async Task LoadData()
        {
            try
            {
                Expression<Func<DownloadDt, int>> orderBy = item => item.DownloadId;
                var pageData = await App.Database.GetFilteredAsync(null,orderBy);
                foreach (var item in pageData)
                {
                    DownloadItem.Add(item);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
        }


        [RelayCommand]
        async Task ClearDownloadAsync()
        {
            var result = await Shell.Current.DisplayAlert("Deleting", "Are you Sure! It will Clear all your History", "yes", "No");
            if (result)
            {
                await App.Database.DeleteAll<DownloadDt>();
                DownloadItem.Clear();
            }
        }
    }
}
