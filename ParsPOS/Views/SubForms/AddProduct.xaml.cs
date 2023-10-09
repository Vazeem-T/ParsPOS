using CommunityToolkit.Maui.Views;
using ParsPOS.Services;
using ParsPOS.ViewModel;

namespace ParsPOS.Views.SubForms;

public partial class AddProduct : ContentPage
{
	ImageService imageService { get; set; }	
	public AddProduct()
	{
        InitializeComponent();
		imageService = new ImageService();
	}

    private void UploadImageButton_Clicked(object sender, EventArgs e)
    {
    }

    private void BorderlessEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        this.ShowPopup(new CategoryPopup());
    }

    private void AddCategoryButton_Clicked(object sender, EventArgs e)
    {
        this.ShowPopup(new AddCategoryPopup());
    }
}