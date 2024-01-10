using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using Newtonsoft.Json;
using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.Services;
using ParsPOS.Services.ViewSevices;
using ParsPOS.Views.InventoryView;
using PostSharp;
using System.Collections.ObjectModel;
using System.Data;

namespace ParsPOS.ViewModel
{
    public partial class PurchasePopupViewModel : BaseViewModel
    {
        public ObservableCollection<Invitm> PurchaseList { get; set;} = new();
        [ObservableProperty]
        IEnumerable<Column> _columns;
        public ObservableCollection<dynamic> DynamicPopList {  get; set;} = new();
		public ItemsLayout ItemsLayout => new GridItemsLayout(GetColumnCount(), ItemsLayoutOrientation.Vertical);
		private int GetColumnCount() => Columns?.Count() ?? 0;

		private readonly IDbConnection _connection;
        private int currentPage = 1;
        private int itemsPerPage = 10;
        private readonly HttpClient client;
        private CommonHttpServices commonHttpServices;

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
        public PurchaseViewModel _purchaseViewModel { get; set; }

        [ObservableProperty]
        double width;

        [ObservableProperty]
        Grid gridData;

        private readonly SharedPurchaseService _sharedDataService;
        public PurchasePopupViewModel(PopupButtonsSelectionWrapper popSelectWrapper,PurchaseViewModel viewModel,IDbConnection connection) 
        {
            Popselect = popSelectWrapper.Selection;
            _purchaseViewModel = viewModel;
            _connection = connection;
            //_sharedDataService = sharedPurchase;
            commonHttpServices = new CommonHttpServices();
            client = commonHttpServices.GetHttpClient();
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
            try
            {
				currentPage = 1;
				PurchaseList.Clear();
				LoadDataCommand.Execute(null);
			}
            catch (Exception ex)
            {
            }
        }

        [RelayCommand]
        async Task SelectedListItem()
        {
            if (SelectedInv != null)
            {
                _purchaseViewModel.SelectedItemcode = SelectedInv.ItemCode;
                RequestCloseAction();
                await _purchaseViewModel.LoadSelectedItmCommand.ExecuteAsync(null);
                //_sharedDataService.Onselected(SelectedInv);
                //await Shell.Current.GoToAsync(nameof(AddPurchase));
            }
        }
        public event EventHandler RequestClose;
        private void RequestCloseAction()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
