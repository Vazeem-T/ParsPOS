using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.Model;
using ParsPOS.Services;
using ParsPOS.Services.ViewSevices;
using ParsPOS.Views.InventoryView;
using System.Collections.ObjectModel;

namespace ParsPOS.ViewModel
{
    public partial class PurchasePopupViewModel : BaseViewModel
    {
       
        public ObservableCollection<Invitm> PurchaseList { get; set;} = new();
        private int currentPage = 1;
        private int itemsPerPage = 10;
        [ObservableProperty]
        double height;

        [ObservableProperty]
        string selectedItem = "ItemCode";

        [ObservableProperty]
        double listHeight;

        [ObservableProperty]
        Invitm selectedInv ;

        string searchtxt;
        public string Searchtxt
        {
            get => searchtxt;
            set
            {
                if (searchtxt != value)
                {
                    searchtxt = value;
                    currentPage = 1;
                    PurchaseList.Clear();
                    LoadDataCommand.Execute(null);
                    OnPropertyChanged(nameof(Searchtxt));
                }
            }
        }

        [ObservableProperty]
        PopupButtonsSelection popselect;

        private readonly PopupButtonsSelectionWrapper _popSelectWrapper;

        [ObservableProperty]
        double width;

        [ObservableProperty]
        Grid gridData;

        private readonly SharedPurchaseService _sharedDataService;
        public PurchasePopupViewModel(PopupButtonsSelectionWrapper popSelectWrapper,SharedPurchaseService sharedPurchase) 
        {
            Popselect = popSelectWrapper.Selection;
            _sharedDataService = sharedPurchase;
            LoadDataCommand.Execute(null);
           
        }
        [RelayCommand]
        private async Task LoadDataAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                string select = Enum.GetName<PopupButtonsSelection>(Popselect);
                if(Searchtxt == null || Searchtxt == "")
                {
                    var pageData = await App.Database.GetItemforPopup<Invitm>(currentPage, itemsPerPage, select);
                    if (pageData.Any())
                    {
                        foreach (var item in pageData)
                        {
                            PurchaseList.Add(item);
                        }
                        currentPage++;
                    }
                }
                else
                {
                    var pageData = await App.Database.GetPopProductSearch(Searchtxt, SelectedItem, currentPage, itemsPerPage);
                    if (pageData.Any())
                    {
                        foreach (var item in pageData)
                        {
                            PurchaseList.Add(item);
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
        async Task SearchTextChange()
        {
            currentPage = 1;
            PurchaseList.Clear();
            LoadDataCommand.Execute(null);
        }

        [RelayCommand]
        async Task SelectedListItem()
        {
            if (SelectedInv != null)
            {
               _sharedDataService.Onselected(SelectedInv);
               //await Shell.Current.GoToAsync(nameof(AddPurchase));
               RequestCloseAction();
            }
        }

        public event EventHandler RequestClose;
        private void RequestCloseAction()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
