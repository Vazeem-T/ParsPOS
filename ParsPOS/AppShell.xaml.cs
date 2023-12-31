﻿using ParsPOS.Views;
using ParsPOS.Views.InventoryView;
using ParsPOS.Views.Settings;
using ParsPOS.Views.SubForms;
using ParsPOS.Views.User;

namespace ParsPOS;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        BindingContext = this;
        InitRoutes();
    }

    private void InitRoutes()
    {
        Routing.RegisterRoute(nameof(AddCategory), typeof(AddCategory));
        Routing.RegisterRoute(nameof(Sale), typeof(Sale));
        Routing.RegisterRoute(nameof(ImportDb), typeof(ImportDb));
        Routing.RegisterRoute(nameof(UserInfo), typeof(UserInfo));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(Inventory), typeof(Inventory));
        Routing.RegisterRoute(nameof(PayPopup), typeof(PayPopup));
        Routing.RegisterRoute(nameof(AddCompanydt), typeof(AddCompanydt));
        Routing.RegisterRoute(nameof(Purchase), typeof(Purchase));
        Routing.RegisterRoute(nameof(AddPurchase), typeof(AddPurchase));
        Routing.RegisterRoute(nameof(FOC),typeof(FOC));
        Routing.RegisterRoute(nameof(Download), typeof(Download));

    }
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void DownloadItem_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Download));
    }
}
