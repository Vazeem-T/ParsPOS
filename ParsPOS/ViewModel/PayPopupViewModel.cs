using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.InterfaceServices;
using ParsPOS.Model;
using ParsPOS.ResultModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Numerics;
using System.Security.Cryptography;

namespace ParsPOS.ViewModel
{
    public partial class PayPopupViewModel : BaseViewModel
    {
        private readonly SaleViewModel _sale;

        public NumberPadViewModel _numberPad { get; set; }
        public ObservableCollection<PreFixTb> PrefixButtons { get; set; } = new();
        public ObservableCollection<PaymentOption> PaymentOptions { get; set; }= new();
        public PayPopupViewModel(SaleViewModel saleView, NumberPadViewModel numberPadView)
        {
            LoadPrefixButtonCommand.Execute(null);
            _sale = saleView;
            _numberPad = numberPadView;
            TotalPrice = _sale.Totalprice;
            NumberText = _numberPad.DisplayText;
            
            //MessagingCenter.Subscribe<NumberPadViewModel, string>(this, "DisplayTextChanged", (sender, arg) =>
            //{
            //    NumberText = arg;
            //});
            //
            //_numberPad.PropertyChanged += NumberPad_PropertyChanged;
        }
        
        [RelayCommand]
        async Task UpdateDisplayText(string newText)
        {
            NumberText = newText;
        }



        [ObservableProperty]
        string _numberText;

        [ObservableProperty]
        PaymentOption paymentOptionModel;

        [ObservableProperty]
        double totalPaid;

        [ObservableProperty]
        double balance;

        [ObservableProperty]
        double totalPrice;

        [ObservableProperty]
        int selectedPaymentMode = App.Database.GetSalePrefixButton().Result.FirstOrDefault().Id;

        [RelayCommand]
        void ExecuteButton(int voucherId)
        {
            SelectedPaymentMode = voucherId; 
        }
        [RelayCommand]
        async Task AmountReturnAsync()
        {
            if(SelectedPaymentMode != 0)
            {
                var paymentmode = App.Database.GetSaleVoucherName(SelectedPaymentMode).Result.VoucherName;
                PaymentOption paymentOption = new PaymentOption
                {
                    PaymentModeId = SelectedPaymentMode,
                    PaymentAmount = double.Parse(NumberText),
                    PaymentMode = paymentmode
                };
                PaymentOptions.Add(paymentOption);
                TotalPaid = PaymentOptions.Sum(item => item.PaymentAmount);
                Balance = TotalPaid - TotalPrice;
                //NumberText = "".Trim();
            }
            
        }
        [RelayCommand]
        async Task RemovePaymentAsync()
        {
            if(PaymentOptionModel != null) 
            {
                PaymentOptions.Remove(PaymentOptionModel);
                TotalPaid = PaymentOptions.Sum(item => item.PaymentAmount);
                Balance = TotalPaid - TotalPrice;
            }
        }


        [RelayCommand]
        async Task LoadPrefixButtonAsync()
        {
            IsBusy = true;
            try
            {
                // Load data for the current page
                var pageData = await App.Database.GetSalePrefixButton();

                if (pageData.Any())
                {
                    foreach (var item in pageData)
                    {
                        item.ButtonCommand = new Command<int>(ExecuteButton);
                        PrefixButtons.Add(item);
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
    }
}
