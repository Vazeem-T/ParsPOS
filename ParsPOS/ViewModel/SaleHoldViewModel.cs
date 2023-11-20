using CommunityToolkit.Mvvm.ComponentModel;
using ParsPOS.DBHandler;
using ParsPOS.SaleModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
    public partial class SaleHoldViewModel : BaseViewModel
    {
        public ObservableCollection<NizPoscmn> NizPoscmns { get; set; } = new();
        public ObservableCollection<NizPosdet> NizPosdet { get; set;} = new();

        private readonly SaleDatabaseHelper _saleDbHelper;
        public SaleHoldViewModel(SaleDatabaseHelper saleDatabaseHelper)
        {
            _saleDbHelper = saleDatabaseHelper;
            LoadDtOnInit();
        }

        [ObservableProperty]
        bool recieptVisibility = false;

        [ObservableProperty]
        string _companyName;

        [ObservableProperty]
        NizPoscmn _selectedOnHold;


        async Task LoadDtOnInit()
        {
            var PageData = await _saleDbHelper.GetAllAsync<NizPoscmn>();
            if(PageData != null)
            {
                foreach(var item in PageData)
                {
                    NizPoscmns.Add(item);
                }
            }
        }

    }
}
