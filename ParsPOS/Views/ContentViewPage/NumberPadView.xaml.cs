using ParsPOS.ViewModel;

namespace ParsPOS.Views.ContentViewPage;

public partial class NumberPadView : ContentView
{

    //public static readonly BindableProperty ViewModelProperty = BindableProperty.Create(
    //    propertyName: "ViewModel",
    //    returnType: typeof(NumberPadViewModel),
    //    declaringType: typeof(NumberPadView),
    //    defaultValue: null,
    //    defaultBindingMode: BindingMode.TwoWay);

    //public NumberPadViewModel ViewModel
    //{
    //    get { return (NumberPadViewModel)GetValue(ViewModelProperty); }
    //    set { SetValue(ViewModelProperty, value); }
    //}

    public NumberPadView()
	{
        InitializeComponent();
        //NumberPadView viewModel = new NumberPadView();
        //BindingContext = viewModel;
    }
  
}