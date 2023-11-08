using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ParsPOS.Views.Settings;

public partial class DbSetting : ContentPage
{
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    public DbSetting()
    {
        InitializeComponent();
    }

    private async void Delete_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            string databasepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PARSPOS.db3");
            var result = await DisplayAlert("Alert ", $"Do you want to delete Database?", "Yes", "No");
            if (result)
            {
                var result1 = await DisplayAlert("Alert ", $"It Cannot be Recovered?", "OK", "Cancel");
                if (result1)
                {
                    File.Delete(databasepath);
                    var toast = Toast.Make("Database Deleted Successfully!", ToastDuration.Short, 14);
                    await toast.Show(cancellationTokenSource.Token);
                }

            }
        }
        catch (Exception ex)
        {

        }

    }

    private async void ImportDbRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ImportDb));
    }
}