using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ParsPOS.SaleModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public partial class DownloadViewModel : BaseViewModel
    {
        public ObservableCollection<DownloadDt> Items { get; set; } = new();
        [ObservableProperty]
        DownloadDt downloadDt;
        public DownloadViewModel()
        {
            LoadDataCommand.Execute(null);
        }
        [RelayCommand]
        async Task LoadData()
        {
            try
            {
                var pageData = await App.SaleDb.GetDownloadList();
                foreach (var item in pageData)
                {
                    Items.Add(item);
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
                await App.SaleDb.DeleteAllDownloadDt();
                Items.Clear();
            }
        }
    }
}
