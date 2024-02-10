using CommunityToolkit.Mvvm.Input;
using Microsoft.Data.SqlClient;
using ParsVanSale.Views;
using ParsVanSale.Views.BottomSheet;
using ParsVanSale.Views.SqliteSettings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
	public partial class HomeViewModel : BaseViewModel
	{
		public HomeViewModel() { }
		[RelayCommand]
		async Task GoToSearchAsync()
		{
			//ProdSearch page = new ProdSearch();
			//await page.ShowAsync();
		}
		[RelayCommand]
		async Task GotoSettingsAsync()
		{
			await Shell.Current.GoToAsync(nameof(Settings));
		}
		[RelayCommand]
		async Task GotoDownloadAsync()
		{
			await Shell.Current.GoToAsync(nameof(DownloadPage));
		}

		[RelayCommand]
		async Task GotoNetworkAsync()
		{
			try
			{
				await Shell.Current.GoToAsync("//Home/NetworkSetUp");
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}

		}
		[RelayCommand]
		async Task GotoImportDatabaseAsync()
		{
			try
			{
				Shell.Current.GoToAsync(nameof(ImportData));
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Exception: {ex.ToString()}");
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
		}
		//[RelayCommand]
	    //async Task Test()
		//{
		//	try
		//	{
		//		SqlConnection con = new ("Data Source = 10.10.2.12 ;Initial Catalog = PARSAccTrPlusFLN ; Persist Security Info=True;User ID = sa; Password=#1802kjh;Encrypt=false;TrustServerCertificate=true");
		//		con.Open();
		//		if (con.State == System.Data.ConnectionState.Open)
		//		{
		//			con.Close();
		//			await Shell.Current.DisplayAlert("Success", "Your Connection is Successfull", "OK");
		//		}
		//		else
		//		{
		//			await Shell.Current.DisplayAlert("Alert", "Check Your Connection!", "OK");
		//			con.Close();
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		await Shell.Current.DisplayAlert("Alert",ex.Message, "Ok");
		//	}

		//}

	}
}
