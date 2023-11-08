using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.DBHandler;
using ParsPOS.SaleModel;
using ParsPOS.Services;
using ParsPOS.Views.SubForms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ParsPOS.ViewModel
{
    public partial class SaleViewModel : BaseViewModel
    {
        public ObservableCollection<CanPostrTb> Items { get; set; } = new();
        private int Slno = 1;
        private readonly SaleDatabaseHelper _context;
        public SaleViewModel()
        {
            AddCharCommand = new Command<string>((key) => InputString += key);

            DeleteCharCommand =
                new Command(
                    () => InputString = InputString.Substring(0, InputString.Length - 1),

                    () => InputString.Length > 0
                );
        }

        [ObservableProperty]
        string textHeader;

        [ObservableProperty]
        double _totaltrqty;

        [ObservableProperty]
        double _totalprice;

        [ObservableProperty]
        int invoiceNumber = 1;

        [ObservableProperty]
        int _itemcount = 0;

        [ObservableProperty]
        CanPostrTb postrTbs;
        
        [ObservableProperty]
        SaleSelectedOption optionSelectedButton = SaleSelectedOption.Barcode;

        [ObservableProperty]
        SaleAddorEdit optionaddoredit = SaleAddorEdit.Add;

        [ObservableProperty]
        string code = "Barcode/ ItemCode";
        
        [ObservableProperty]
        PostrTb _operatingPostrTb = new();

        [ObservableProperty]
        string _barcodeText = "";

        [ObservableProperty]
        bool _isBusy;
        [ObservableProperty]
        string _busyText;

        [RelayCommand]
        async Task OptionButton(string button)
        {
            if(Optionaddoredit == SaleAddorEdit.Edit)
            {
                if (Enum.TryParse(button, true, out SaleSelectedOption selectedOption))
                {
                    OptionSelectedButton = selectedOption;

                    switch (selectedOption)
                    {
                        case SaleSelectedOption.Barcode:
                            Code = "Barcode/ ItemCode";
                            BarcodeText = "";
                            InputString = "";
                            BarcodeText = BarcodeText.Trim();
                            break;
                        case SaleSelectedOption.Qty:
                            Code = "Quantity";
                            BarcodeText = PostrTbs?.TrQty.ToString();
                            break;
                        case SaleSelectedOption.Price:
                            Code = "Price";
                            BarcodeText = PostrTbs?.UnitCost.ToString();
                            break;
                    }
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Alert", "For Editing, Change Mode to Edit", "OK");
            }
            
        }
        [RelayCommand]
        async Task AddorEdit(string selectbutton)
        {
            if (Enum.TryParse(selectbutton, true, out SaleAddorEdit Option))
            {
                Optionaddoredit = Option;

                switch (Option)
                {
                    case SaleAddorEdit.Add:
                        TextHeader = "Add";
                        break;
                    case SaleAddorEdit.Edit:
                        TextHeader = "Edit";
                        break;
                }
            }
        }


        [RelayCommand]
        public async Task SearchInvItm()
        {
            IsBusy = true;
            try
            {
                if (Optionaddoredit == SaleAddorEdit.Add && OptionSelectedButton == SaleSelectedOption.Barcode)
                {
                    var item = AddItem();
                    if(item != null) 
                    {
                        Slno++;
                        Items.Add(PostrTbs);
                        Itemcount = Items.Count;
                        Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                        Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                        BarcodeText = "";
                        InputString = "";
                        BarcodeText.Trim();
                    }
                }
                else
                {
                    if(OptionSelectedButton == SaleSelectedOption.Qty)
                    {
                        PostrTbs.TrQty = double.Parse(BarcodeText);
                        PostrTbs.PriceWithTax = double.Parse(string.Format("{0:0.00}",double.Parse(BarcodeText) * PostrTbs.UnitCost));
                        Items.Remove(PostrTbs);
                        Items.Add(PostrTbs);
                        Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                        Totalprice = double.Parse(string.Format("{0:0.00}",Items.Sum(item => item.PriceWithTax)));
                    }
                    else if (OptionSelectedButton == SaleSelectedOption.Price)
                    {
                        PostrTbs.UnitCost = double.Parse(BarcodeText);
                        PostrTbs.PriceWithTax = double.Parse(BarcodeText) * (PostrTbs.TrQty ?? 1);
                        Items.Remove(PostrTbs);
                        Items.Add(PostrTbs);
                        Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                    }
                    else
                    {
                        var Slno = PostrTbs.SlNo;
                        Items.Remove(PostrTbs);
                        var item = AddItem();
                        if (item != null)
                        {
                            PostrTbs.SlNo = Slno;   
                            Items.Add(PostrTbs);
                            Itemcount = Items.Count;
                            Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                            Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                            BarcodeText = "";
                            InputString = "";
                            BarcodeText.Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            finally 
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task SelectedItem(CanPostrTb selecteditem)
        {
            PostrTbs = selecteditem;
        }

        private CanPostrTb AddItem()
        {
            var item = App.Database.EntryChk(InputString).Result;
            if (item != null)
            {
                PostrTbs = new CanPostrTb
                {
                    SysDateTime = DateTime.Now,
                    ItemId = item.ItemId,
                    SlNo = Slno,
                    TrQty = 1,
                    Unit = item.Unit,
                    UnitCost = double.Parse(string.Format("{0:0.00}", item.UnitPrice)),
                    Idescription = item.Description,
                    UnitDiscount = item.DiscountVal,
                    IsReturn = false,
                    CounterNo = 1,
                    CategoryCode = "Item",
                    IsCategorySale = false,
                    CatDescription = "NA",
                    PriceWithTax = double.Parse(string.Format("{0:0.00}", item.UnitPrice))
                };
                return PostrTbs;
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Item Not found !", "OK");
                return null;
            }
        }

        [RelayCommand]
        async Task DeleteItem()
        {
            if(PostrTbs != null)
            {
                var result = await Shell.Current.DisplayAlert("Alert", $"Do you want to delete {PostrTbs.Idescription}", "Yes", "No");
                if (result)
                {
                    Items.Remove(PostrTbs);
                    Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                    Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                    Itemcount = Items.Count;
                }
            }
        }

        [RelayCommand]
        async Task GotoPayPopupAsync()
        {
            var payPopup = new PayPopup(this);
            await Shell.Current.ShowPopupAsync(payPopup);
        }


        [RelayCommand]
        async Task QuantityPlus()
        {
            try
            {
                if (PostrTbs != null)
                {
                    PostrTbs.TrQty = PostrTbs.TrQty + 1;
                    PostrTbs.PriceWithTax = double.Parse(string.Format("{0:0.00}", PostrTbs.TrQty * PostrTbs.UnitCost));
                    Items.Remove(PostrTbs);
                    Items.Add(PostrTbs); 
                    Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                    Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert ("Alert",ex.Message,"OK");
            }
        }

        [RelayCommand]
        void QuantityMinus()
        {
            if (PostrTbs != null)
            {
                PostrTbs.TrQty = PostrTbs.TrQty - 1;
                PostrTbs.PriceWithTax = double.Parse(string.Format("{0:0.00}", PostrTbs.TrQty * PostrTbs.UnitCost));
                Items.Remove(PostrTbs);
                Items.Add(PostrTbs);
                Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
            }
        }


        //NumberPad ContentView
        private string _inputString = "";
        private char[] _specialChars = { '*', '#' };

        public ICommand AddCharCommand { get; private set; }
        public ICommand DeleteCharCommand { get; private set; }

        public string InputString
        {
            get => _inputString;
            private set
            {
                if (_inputString != value)
                {
                    _inputString = value;
                    OnPropertyChanged();
                    BarcodeText = FormatText(_inputString);
                    OnPropertyChanged(nameof(BarcodeText));
                    ((Command)DeleteCharCommand).ChangeCanExecute();
                }
            }
        }

        string FormatText(string str)
        {
            bool hasNonNumbers = str.IndexOfAny(_specialChars) != -1;
            string formatted = str;

            return formatted;
        }
    }
}
