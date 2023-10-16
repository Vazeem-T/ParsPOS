using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.DBHandler;
using ParsPOS.Model;
using PARSPOS.SaleModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public partial class SaleViewModel : ObservableObject
    {
        private readonly SaleDatabaseHelper _context;

        public SaleViewModel(SaleDatabaseHelper context)
        {
            _context = context;
        }

        [ObservableProperty]
        private ObservableCollection<PostrTb> _PostrTb = new();

        [ObservableProperty]
        private  PostrTb _operatingPostrTb = new();

        [ObservableProperty]
        private string _barcodeText;

        [ObservableProperty]
        private bool _isBusy;
        [ObservableProperty]
        private string _busyText;

        public async Task LoadPostrTbsAsync()
        {
            await ExecuteAsync(async () =>
            {
                var positms = await _context.GetAllAsync<PostrTb>();
                if (positms is not null && positms.Any())
                {
                    PostrTb ??= new ObservableCollection<PostrTb>();

                    foreach (var postrTb in positms)
                    {
                        PostrTb.Add(postrTb);
                    }
                }
            }, "Fetching PostrTbs...");
        }

        [RelayCommand]
        private void SetOperatingPostrTb(PostrTb? PostrTb) => OperatingPostrTb = PostrTb ?? new();

        [RelayCommand]
        private async Task SavePostrTbAsync()
        {
            if (OperatingPostrTb is null)
                return;

            //var (isValid, errorMessage) = OperatingPostrTb();
            //if (!isValid)
            //{
            //    await Shell.Current.DisplayAlert("Validation Error", errorMessage, "Ok");
            //    return;
            //}

            var busyText = OperatingPostrTb.ItemId == 0 ? "Creating PostrTb..." : "Updating PostrTb...";
            await ExecuteAsync(async () =>
            {
                if (OperatingPostrTb.ItemId == 0)
                {
                    // Create PostrTb
                    await _context.AddItemAsync<PostrTb>(OperatingPostrTb);
                    PostrTb.Add(OperatingPostrTb);
                }
                else
                {
                    // Update PostrTb
                    if (await _context.UpdateItemAsync<PostrTb>(OperatingPostrTb))
                    {
                        var PostrTbCopy = OperatingPostrTb.Clone();

                        var index = PostrTb.IndexOf(OperatingPostrTb);
                        PostrTb.RemoveAt(index);

                        PostrTb.Insert(index, PostrTbCopy);
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "PostrTb updation error", "Ok");
                        return;
                    }
                }
                SetOperatingPostrTbCommand.Execute(new());
            }, busyText);
        }

        [RelayCommand]
        private async Task DeletePostrTbAsync(int id)
        {
            await ExecuteAsync(async () =>
            {
                if (await _context.DeleteItemByIdAsync<PostrTb>(id))
                {
                    var postrTb = PostrTb.FirstOrDefault(p => p.ItemId == id);
                    PostrTb.Remove(postrTb);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Delete Error", "PostrTb was not deleted", "Ok");
                }
            }, "Deleting PostrTb...");
        }
        private async Task ExecuteAsync(Func<Task> operation, string? busyText = null)
        {
            IsBusy = true;
            BusyText = busyText ?? "Processing...";
            try
            {
                await operation?.Invoke();
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                IsBusy = false;
                BusyText = "Processing...";
            }
        }

        public async Task SearchInvItm()
        {
            IsBusy = true;
            try
            {
                var item = await App.Database.EntryChk(BarcodeText);
                if (item != null)
                {
                    await App.Current.MainPage.DisplayAlert("Success", "Item found !", "OK");
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                IsBusy = false;
            }
        }

    }
}
