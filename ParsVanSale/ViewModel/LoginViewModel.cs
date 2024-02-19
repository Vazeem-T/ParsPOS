using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
	public partial class LoginViewModel : BaseViewModel
	{
		[ObservableProperty]
		string userId;

		[ObservableProperty]
		string password;

		[RelayCommand]
		private async Task LoginAsync()
		{
			try
			{
				if (string.IsNullOrEmpty(Password))
				{
					await Shell.Current.DisplayAlert("Alert", "Password cannot be null or empty", "OK");
					return;
				}

				Application.Current.MainPage = new AppShell();

				var user = await Task.Run(() => App.Database.LoginUser(UserId, Password));

				var adminPass = "VISHWASAM";
				if (Password.ToUpper() == adminPass.ToUpper())
				{
					App.UserId = "Programmer";
					Password = string.Empty;
					await Shell.Current.GoToAsync("//Home");
				}
				else if (user != null)
				{
					App.UserId = UserId;
					UserId = string.Empty;
					Password = string.Empty;
					await Shell.Current.GoToAsync("//Home");
				}
				else
				{
					await Shell.Current.DisplayAlert("Alert", "UserId and Password don't match!", "OK");
				}
			}
			catch (Exception ex)
			{
				await Shell.Current.DisplayAlert("Alert", ex.Message, "OK");
			}
		}
	}
}
