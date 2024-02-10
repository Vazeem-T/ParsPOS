using CommunityToolkit.Maui.Behaviors;
using ParsPOS.ViewModel;

namespace ParsPOS.Views.BottomSheet;

public partial class CmnDynamicPOP 
{
	public CmnDynamicPOP()
	{
		InitializeComponent();
		ItemTableview = TableView();
		Content = new StackLayout
		{
			
			Children = { SearchPick,ItemTableview }
		};
	}

	private CollectionView TableView()
	{
		var dynamicCollectionView = new CollectionView
		{
			/*ItemsSource = new ObservableCollection<Invitm>(),*/ // Set your data source here
			SelectionMode = SelectionMode.Single,
			SelectedItem = null, // You may want to bind this to a property in your ViewModel
			RemainingItemsThreshold = 3,
			Margin= new Thickness(5, 0),
			HeightRequest = 500,
		};

		// Create a dynamic header grid
		var headerGrid = new Grid
		{
			ColumnDefinitions = new ColumnDefinitionCollection
				{
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = GridLength.Star },
					new ColumnDefinition { Width = GridLength.Star }
				},
			Margin = new Thickness(0, 0, 0, 5)
		};

		// Add header labels
		headerGrid.Add(new Label { Text = "Item Code", FontAttributes = FontAttributes.Bold },0);
		headerGrid.Add(new Label { Text = "Description", FontAttributes = FontAttributes.Bold },1);
		headerGrid.Add(new Label { Text = "Unit", FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center },2);
		headerGrid.Add(new Label { Text = "Active Cost", FontAttributes = FontAttributes.Bold },3);
		headerGrid.Add(new Label { Text = "UnitPrice", FontAttributes = FontAttributes.Bold },4);
		headerGrid.Add(new Label { Text = "BarCode", FontAttributes = FontAttributes.Bold },5);

		dynamicCollectionView.Header = headerGrid;

		// Set the item template
		//dynamicCollectionView.ItemTemplate = new DataTemplate(() =>
		//{
		//	var grid = new Grid
		//	{
		//		ColumnDefinitions = new ColumnDefinitionCollection
		//			{
		//				new ColumnDefinition { Width = GridLength.Star },
		//				new ColumnDefinition { Width = GridLength.Star },
		//				new ColumnDefinition { Width = GridLength.Star },
		//				new ColumnDefinition { Width = GridLength.Star },
		//				new ColumnDefinition { Width = GridLength.Star },
		//				new ColumnDefinition { Width = GridLength.Star }
		//			},
		//		Margin = new Thickness(0, 5)
		//	};

		//	// Add labels for each property
		//	grid.Children.Add(new Label { Text = "{Binding ItemCode}" });
		//	grid.Children.Add(new Label { Text = "{Binding Description}"});
		//	grid.Children.Add(new Label { Text = "{Binding Unit}", HorizontalTextAlignment = TextAlignment.Center, });
		//	grid.Children.Add(new Label { Text = "{Binding ActiveCost}"});
		//	grid.Children.Add(new Label { Text = "{Binding UnitPrice}" });
		//	grid.Children.Add(new Label { Text = "{Binding BarCode}" });

		//	return grid;
		//});

		return dynamicCollectionView;
	}
}