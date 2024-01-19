using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.DBHandler;
using ParsPOS.InterfaceServices;
using ParsPOS.ResultModel;
using ParsPOS.SaleModel;
using ParsPOS.Services;
using ParsPOS.Views.SubForms;
using PARSPOS.SaleModel;
using System.Collections.ObjectModel;

namespace ParsPOS.ViewModel
{
    public partial class SaleViewModel : BaseViewModel
    {
        public ObservableCollection<CanPostrTb> Items { get; set; } = new();
      
        public ObservableCollection<NizPosdet> HodldItemdet { get; set; } = new();
        public ObservableCollection<NizPoscmn>  HoldItem { get; set; } = new();
        //public ObservableCollection<PrefixTbCombination> PrefixTbCombinations { get; set; } = new();
        private readonly SaleHoldViewModel _model;
        private int Slno = 1;
        public SaleViewModel(SaleHoldViewModel viewModel)
        {
            _model = viewModel;
            LoadfromOnHoldAsync().GetAwaiter();
        }
        [ObservableProperty]
        int? customerdt;

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
        async Task PrefixButtonSelection(string button)
        {

        }

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
                            //InputString = "";
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
            if(Optionaddoredit==SaleAddorEdit.Edit)
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
            else
            {
                if(PostrTbs == null)
                {
                    await Shell.Current.DisplayAlert("Alert", "Select One Item First", "OK");
                }
                else
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
            }
           
        }


        [RelayCommand]
        public async Task SearchInvItm()
        {
            IsBusy = true;
            try
            {
                if(!string.IsNullOrWhiteSpace(BarcodeText))
                {

                    if (Optionaddoredit == SaleAddorEdit.Add && OptionSelectedButton == SaleSelectedOption.Barcode)
                    {
                        var item = AddItem();
                        if (item != null)
                        {
                            Slno++;
                            Items.Add(PostrTbs);
                            Itemcount = Items.Count;
                            Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                            Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                            BarcodeText = "";
                            //InputString = "";
                            BarcodeText.Trim();
                        }
                    }
                    else
                    {
                        if (OptionSelectedButton == SaleSelectedOption.Qty)
                        {
                            PostrTbs.TrQty = double.Parse(BarcodeText);
                            PostrTbs.PriceWithTax = double.Parse(string.Format("{0:0.00}", double.Parse(BarcodeText) * PostrTbs.UnitCost));
                            Items.Remove(PostrTbs);
                            Items.Add(PostrTbs);
                            Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                            Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
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
                                //InputString = "";
                                BarcodeText.Trim();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
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

        private async Task<CanPostrTb> AddItem()
        {
            bool isweighted = false;
            try
            { 
                var Isweighting = SplitBarcode(BarcodeText);
                {
                    var BCode = Isweighting.BarCode;
                    var Isweighingitem = App.Database.EntryChk(BCode).Result;

                    if (Isweighingitem.IsWeighting == true)
                    {
                        isweighted = true;
                        PostrTbs = new CanPostrTb
                        {
                            SysDateTime = DateTime.Now,
                            ItemId = Isweighingitem.ItemId,
                            SlNo = Slno,
                            TrQty = double.Parse(string.Format("{0:0.000}", Isweighting.Price / Isweighingitem.UnitPrice)),
                            Unit = Isweighingitem.Unit,
                            UnitCost = double.Parse(string.Format("{0:0.00}", Isweighingitem.UnitPrice)),
                            Idescription = Isweighingitem.Description,
                            UnitDiscount = Isweighingitem.DiscountVal,
                            IsReturn = false,
                            CounterNo = 1,
                            CategoryCode = "Item",
                            IsCategorySale = false,
                            CatDescription = "NA",
                            PriceWithTax = double.Parse(string.Format("{0:0.00}", Isweighting.Price))
                        };
                        return PostrTbs;
                    }
                    if (isweighted == false)
                    {
                        var item = App.Database.EntryChk(BarcodeText).Result;
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
                }
                isweighted = false;
                return PostrTbs;
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
                return null;
            }
            finally
            {
                isweighted = false;
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
                    PostrTbs = null;
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
                if(PostrTbs.TrQty !<= 0)
                {
                    PostrTbs.TrQty = PostrTbs.TrQty - 1;
                    PostrTbs.PriceWithTax = double.Parse(string.Format("{0:0.00}", PostrTbs.TrQty * PostrTbs.UnitCost));
                    Items.Remove(PostrTbs);
                    Items.Add(PostrTbs);
                    Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                    Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));

                }
            }
        }
        public static BarcodeInfo SplitBarcode(string input)
        {
            if (input.Length == 13)
            {
                string barcode = input.Substring(0, 7);
                string pricePart = input.Substring(7, 5);
                int priceIntegerPart = int.Parse(pricePart.Substring(0, 3));
                int priceDecimalPart = int.Parse(pricePart.Substring(3, 2));
                int certificate = int.Parse(input.Substring(12, 1));
                BarcodeInfo barcodeInfo = new BarcodeInfo
                {
                    BarCode = barcode,
                    Price = double.Parse($"{priceIntegerPart}.{priceDecimalPart}"),
                    Certificate = certificate
                };

                return barcodeInfo;
            }
            return new BarcodeInfo { BarCode = input};
        }
        [RelayCommand]
        async Task GotoOnHoldPopupAsync()
        {
            SaleHoldViewModel viewModel = new SaleHoldViewModel();
            var HoldPopup = new LoadHold(viewModel);
            await Shell.Current.ShowPopupAsync(HoldPopup);
        }
        [RelayCommand]
        async Task HoldDataAsync()
        {
            try
            {
                if (Items.Count > 0)
                {
                    var getcounterno = await App.Database.GetLastSettings();
                    int holddtcount = 0;
                    var holddt = await App.SaleDb.GetAllNizPoscmn();
                    if (holddt is not null && holddt.Any())
                    {
                        holddtcount = holddt.LastOrDefault().HoldNo + 1 ;
                    }
                    else
                    {
                        
                        holddtcount = 1;
                    }
                    NizPoscmn nizPoscmn = new NizPoscmn
                    {
                        CounterNo = getcounterno.CounterNumber,
                        HoldNo = Convert.ToInt16(holddtcount),
                        UserId = App.UserId,
                        Tm = DateTime.Now,
                        CustNo = Customerdt,
                        SlsManId = App.UserId
                    };
                    await App.SaleDb.CreateNizPosCmn(nizPoscmn);
                    foreach (var item in Items)
                    {
                        NizPosdet nizPosdet = new NizPosdet
                        {
                            CounterNo = getcounterno.CounterNumber,
                            HoldNo = Convert.ToInt16(holddtcount),
                            SlNo = Convert.ToInt16(item.SlNo),
                            ItemId = item.ItemId,
                            Unit = item.Unit,
                            IsRet = item.IsReturn,
                            Qty = item.TrQty,
                            UnitPrice = item.UnitCost,
                            Discount = item.LineDiscount,
                            CategotyCode = item.CategoryCode,
                            IsCategorySale = item.IsCategorySale,
                            CatDescription = item.Idescription,
                            Expirydt = item.ExpiryDt,
                            WhatInAssrtd = item.WhatInAssrtd,
                            IsLnDisc = item.IsLineDisc ?? 0,
                            DoTrWithTax = item.DoTrWithTax,
                            PriceWithTax = item.PriceWithTax,
                        };
                        await App.SaleDb.CreateNizPosDet(nizPosdet);
                    }
                    Items.Clear();
                    Customerdt = null;
                    Totalprice = 0;
                    Totaltrqty = 0;
                    Itemcount = 0;
                }
                else
                {
                    await Shell.Current.DisplayAlert("Alert", "Add Atleast one Item", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
            }
        }

        private async Task LoadfromOnHoldAsync()
        {
            if (_model.CompanyName != null)
            {
                var nizposcmn = _model.NizPoscmns.FirstOrDefault();
                Customerdt = nizposcmn.CustNo;
                var HoldData = await App.SaleDb.GetNizdetOnHoldNo(nizposcmn.HoldNo);
                foreach (var item in HoldData)
                {
                    CanPostrTb postrTb = new CanPostrTb
                    {
                        CounterNo = nizposcmn.CounterNo ?? 0,
                        SlNo = Convert.ToInt16(item.SlNo),
                        ItemId = item.ItemId,
                        Unit = item.Unit,
                        IsReturn = item.IsRet,
                        TrQty = item.Qty,
                        UnitCost = item.UnitPrice,
                        LineDiscount = item.Discount,
                        CategoryCode = item.CategotyCode,
                        IsCategorySale = item.IsCategorySale,
                        Idescription = item.CatDescription,
                        ExpiryDt = item.Expirydt,
                        WhatInAssrtd = item.WhatInAssrtd,
                        IsLineDisc = item.IsLnDisc,
                        DoTrWithTax = item.DoTrWithTax,
                        PriceWithTax = item.PriceWithTax,
                    };
                    Items.Add(postrTb);
                }
                Totalprice = double.Parse(string.Format("{0:0.00}", Items.Sum(item => item.PriceWithTax)));
                Totaltrqty = Items.Sum(item => item.TrQty) ?? 0.0;
                Itemcount = Items.Count;
                await App.SaleDb.DeletenizPosdtOnHold(nizposcmn.HoldNo);
                await App.SaleDb.DeleteSelectedPoscmn(nizposcmn.HoldNo);
            }
        }

                //OnHold
    }
}
