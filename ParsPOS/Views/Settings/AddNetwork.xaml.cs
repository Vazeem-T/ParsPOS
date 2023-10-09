using ParsPOS.Model;
using System.Xml.Linq;

namespace ParsPOS.Views.Settings;

public partial class AddNetwork : ContentPage
{
	public AddNetwork()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        conDt.ItemsSource = await App.Database.GetAllNetwork() ?? null;
    }
    private async void AddButton_Clicked(object sender, EventArgs e)
    {
		try
		{
			if(!string.IsNullOrWhiteSpace(IP.Text))
			{
                await App.Database.UpdtNetworkStatus();
                if (!string.IsNullOrWhiteSpace(Id.Text))
				{
                    await App.Database.UpdNetworkStatusID(Convert.ToInt32(Id.Text), Con.Text, IP.Text, Convert.ToInt32(Port.Text));
                    Add.Text = "Add";
                }
                else
				{
					await App.Database.CreateNetwork(new Model.NetworkIP
					{
						ConnectionName = Con.Text,
						IPAddress = IP.Text,
						PortNumber = Convert.ToInt32(Port.Text),
						CreatedTime = DateTime.Now,
						IsConnected = true
					});
				}
				IP.Text = string.Empty;
                Con.Text = string.Empty;
                Port.Text = string.Empty;
                Id.Text = string.Empty;
            }
			conDt.ItemsSource = await App.Database.GetAllNetwork();
		}
		catch (Exception ex)
        {
            await DisplayAlert("Alert", ex.Message, "OK");
		}
    }

    private async void Delete_Invoked(object sender, EventArgs e)
    {
        var items = sender as SwipeItem;
        var stock = items.CommandParameter as NetworkIP;
        var result = await DisplayAlert("Delete", $"Delete {stock.ConnectionName} from the List", "Yes", "No");
        if (result)
        {
            await App.Database.DeleteNetworkIP(stock);
        }
        conDt.ItemsSource = await App.Database.GetAllNetwork();
    }

    private void conDt_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var item = (NetworkIP)e.SelectedItem;
		if (item != null) 
		{
            IP.Text = item.IPAddress;
            Con.Text = item.ConnectionName;
            Port.Text = (item.PortNumber).ToString();
            Id.Text = item.Id.ToString();
        }
		Add.Text = "Update";
    }
}