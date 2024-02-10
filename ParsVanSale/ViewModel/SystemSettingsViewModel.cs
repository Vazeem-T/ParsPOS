using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsVanSale.Model;
using ParsVanSale.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ParsVanSale.ViewModel
{
	public partial class SystemSettingsViewModel : BaseViewModel
	{
		[ObservableProperty]
		byte[] selectedImageBytes;

		[ObservableProperty]
		SettingsTb _settingsModel;

		[ObservableProperty]
		bool isImageVisible = false;

		public SystemSettingsViewModel()
		{
			SettingsModel = new SettingsTb();
			LoadOnOpenCommand.Execute(null);
		}
		[RelayCommand]
		private async Task LoadOnOpen()
		{
			Expression<Func<SettingsTb, int>> orderBy = item => item.Id;
			SettingsModel = await App.Database.GetFirstAsync(null, orderBy);
			if (SettingsModel != null)
			{
				if (SettingsModel.Id != 0)
				{
					IsImageVisible = true;
					SelectedImageBytes = SettingsModel.Logo;
				}
			}
			else
			{
				SettingsModel = new SettingsTb();
			}
		}
		[RelayCommand]
		private async Task SelectImageAsync()
		{
			var result = await MediaPicker.PickPhotoAsync();
			if (result != null)
			{
				var stream = await result.OpenReadAsync();
				using (var ms = new MemoryStream())
				{
					await stream.CopyToAsync(ms);
					SelectedImageBytes = ms.ToArray();
				}
				IsImageVisible = true;
			}
		}
		[RelayCommand]
		private async Task UploadImageAsync()
		{
			if (SettingsModel.DeviceNumber != null)
			{
				if (SettingsModel.Id != 0)
				{
					SettingsModel.Logo = SelectedImageBytes;
					await App.Database.UpdateAsync(SettingsModel);
					await Shell.Current.DisplayAlert("Success!", "Updated Settings Successfully", "OK");
				}
				else
				{
					SettingsModel.Logo = SelectedImageBytes;
					SettingsModel.SoftwareSetUp = DateTime.Now;
					await App.Database.InsertAsync(SettingsModel);
					await Shell.Current.DisplayAlert("Success!", "Added Settings Successfully", "OK");
				}
			}
			else
			{
				await Shell.Current.DisplayAlert("Alert", "Device Number Cannot be null", "OK");
			}
		}
	}
}
