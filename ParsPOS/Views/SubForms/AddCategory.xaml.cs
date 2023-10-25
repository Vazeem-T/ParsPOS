using ParsPOS.Model;
using ParsPOS.ResultModel;
using ParsPOS.ViewModel;
using System.Collections.ObjectModel;

namespace ParsPOS.Views.SubForms;

public partial class AddCategory : ContentPage
{
    public AddCategory(CategoryViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}