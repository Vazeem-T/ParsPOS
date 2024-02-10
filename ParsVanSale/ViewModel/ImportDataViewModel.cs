using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using ParsVanSale.ViewModel.DownloadViewModel;
using System.Linq.Expressions;

namespace ParsVanSale.ViewModel
{
    public partial class ImportDataViewModel : BaseViewModel
    {

		private ProductDownloadModel _productDownloadModel;
        private BaseItmDetDownloadModel _baseItmDetDownloadModel;
        private PrefixDownloadModel _prefixDownloadModel;
        private SupplierDownloadModel _supplierDownloadModel;
        private SuppProdDownloadModel _suppProdDownloadModel;
        private UnitDownloadModel _unitDownloadModel;
		private UserDownloadModel _userDownloadModel;

        [ObservableProperty]
		bool isDownloading;
		[ObservableProperty]
		int currentCount;
		[ObservableProperty]
        bool product;
        [ObservableProperty]
        bool master;
        [ObservableProperty]
        bool user;
        [ObservableProperty]
        bool barcode;
        [ObservableProperty]
        bool units;
        [ObservableProperty]
        bool suppProd;
        [ObservableProperty]
        bool baseItm;
        [ObservableProperty]
        bool category;
        [ObservableProperty]
        bool prefix;

		[ObservableProperty]
		int prodCount;
        [ObservableProperty]
        int masterCount;
        [ObservableProperty]
        int userCount;
        [ObservableProperty]
        int rightCount;
        [ObservableProperty]
        int rightnodeCount;
        [ObservableProperty]
        int unitCount;
        [ObservableProperty]
        int suppProdCount;
        [ObservableProperty]
        int baseItmCount;
        [ObservableProperty]
        int prefixCount;



        public ImportDataViewModel(ProductDownloadModel productDownloadModel,
            BaseItmDetDownloadModel baseItmDetDownloadModel, PrefixDownloadModel prefixDownloadModel,
            SupplierDownloadModel supplierDownloadModel, SuppProdDownloadModel suppProdDownloadModel,
            UserDownloadModel userDownloadModel, UnitDownloadModel unitDownloadModel)
        {	
			_productDownloadModel = productDownloadModel;
			_baseItmDetDownloadModel = baseItmDetDownloadModel;
			//_prefixDownloadModel = prefixDownloadModel;
			_supplierDownloadModel = supplierDownloadModel;
			_userDownloadModel = userDownloadModel;
			_unitDownloadModel = unitDownloadModel;
			//_suppProdDownloadModel = suppProdDownloadModel;
			LoadDataCommand.Execute(null);
		}	
			
		[RelayCommand]
		async Task DownloadDataAsync()
		{
			try
			{
				var result = await Shell.Current.DisplayAlert("Alert", "Do you want to delete existing Data And Update", "Yes", "No");
				if (result)
				{
					if (Product is true) _productDownloadModel.DownloadDataCommand.Execute(this);
					if (BaseItm is true) _baseItmDetDownloadModel.DownloadDataCommand.Execute(this);
					//if (SuppProd is true) _suppProdDownloadModel.DownloadDataCommand.Execute(this);
					if (Master is true) _supplierDownloadModel.DownloadDataCommand.Execute(this);
					if (Units is true) _unitDownloadModel.DownloadDataCommand.Execute(this);
					if (User is true) _userDownloadModel.DownloadUserCommand.Execute(this);
					//if (Prefix is true) _prefixDownloadModel.ImportPrefixCommand.Execute(this);

					Product = false;
					BaseItm = false;
					//SuppProd = false;
					Master = false;
					Units = false;
					User = false;
					//Prefix = false;
					Expression<Func<SettingsTb, int>> orderBy = item => item.Id;
					var setting = await App.Database.GetFirstAsync(null, orderBy);
					if(setting != null)
					{
						if (setting.Id > 0)
						{
							setting.LstImportTime = DateTime.Now;
							setting.LastImpUser = App.UserId;
							await App.Database.UpdateAsync(setting);
						}
					}
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
			
		}
		[RelayCommand]
		async Task LoadDataAsync()
		{
			try
			{
                ProdCount = App.Database.DbCount<Invitm>().Result;
                MasterCount = App.Database.DbCount<AccMast>().Result;
                UserCount = App.Database.DbCount<User>().Result;
                RightCount = App.Database.DbCount<Rights>().Result;
                RightnodeCount = App.Database.DbCount<RightNode>().Result;
                UnitCount = App.Database.DbCount<UnitsTb>().Result;
                //SuppProdCount = App.Database.DbCount<SuppPrdTb>().Result;
                BaseItmCount = App.Database.DbCount<BaseItmDet>().Result;
                //PrefixCount = App.Database.DbCount<PreFixTb>().Result;
            }
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
        }
	}
}
