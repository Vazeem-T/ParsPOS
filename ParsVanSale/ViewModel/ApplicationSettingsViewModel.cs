using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
	public partial class ApplicationSettingsViewModel : BaseViewModel
	{
		[ObservableProperty]
		SettingsTb settingsModel;
		public ApplicationSettingsViewModel()
		{
			SettingsModel = new();
			LoadCommand.Execute(null);
		}

		[RelayCommand]
		async Task OnLoadAsync()
		{
			Expression<Func<SettingsTb, int>> orderBy = item => item.Id;
			SettingsModel = await App.Database.GetFirstAsync(null, orderBy);
		}

		[RelayCommand]
		async Task OnSubmit()
		{
			if(SettingsModel != null)
			{
				if (SettingsModel.Id != 0)
				{
					await App.Database.UpdateAsync(SettingsModel);
				}
				else
				{
					await Shell.Current.DisplayAlert("Alert", "Set Up System Settings", "OK");
				}
			}
			else
			{
				await Shell.Current.DisplayAlert("Alert", "Set Up System Settings", "OK");
			}

		}
	}
}
