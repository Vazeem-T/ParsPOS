namespace ParsPOS.Views.User;

public partial class UserSettings : ContentPage
{
	public UserSettings()
	{
		InitializeComponent();
        CurrentUser.Text = App.UserId;
	}

    private async void UserRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(UserInfo));
    }
}