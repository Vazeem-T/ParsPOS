using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ParsPOS.Model;

namespace ParsPOS.ViewModel
{
    public partial class CompanyViewModel : BaseViewModel
    {
        public CompanyViewModel() 
        {
            OnInit();
        }

        [ObservableProperty]
        SettingsTb _settingsTbs;

        [ObservableProperty]
        string btName;
        private async Task OnInit()
        {
            var settings = await App.Database.GetLastSettings();
            if (settings != null)
            {
                SettingsTbs = settings;
                if (SettingsTbs.Id != 0)
                {
                    BtName = "Update";
                }
            }
            else
            {
                SettingsTbs = new SettingsTb();
                BtName = "Add";
            }
        }

        [RelayCommand]
        async Task AddOrUpdateAsync()
        {
            if (SettingsTbs != null)
            {
                if (SettingsTbs.Id != 0)
                {
                    await App.Database.UpdateSettings(SettingsTbs);
                }
                else
                {
                    SettingsTbs.SofwareSetUp = DateTime.Now;
                    await App.Database.CreateSettings(SettingsTbs);
                    BtName = "Update";
                }
            }
        }
    }
}
