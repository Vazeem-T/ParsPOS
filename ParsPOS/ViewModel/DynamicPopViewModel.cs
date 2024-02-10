using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Mvvm.ComponentModel;
using FontAwesome;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParsPOS.ViewModel
{
	public partial class DynamicPopViewModel : BaseViewModel
	{
		[ObservableProperty]
		ContentView dynamicBottomSheetContent;

		public DynamicPopViewModel()
		{
			DynamicBottomSheetContent = GenerateBottomSheetContent();
		}
		private ContentView GenerateBottomSheetContent()
		{
			try
			{
				var verticalStackLayout = new StackLayout();
				var horizontalStackLayout = new StackLayout
				{
					Margin = new Thickness(0, 0, 0, 15),
					Orientation = StackOrientation.Horizontal
				};

				// Border 1
				var border1 = new Border
				{
					Margin = new Thickness(5),
					Padding = new Thickness(5, 0),
					HeightRequest = 40,
					WidthRequest = 150,
					StrokeShape = RoundRectangle(10),
					BackgroundColor = Color.FromArgb("#F0F8FF"),//AliceBlue
					Stroke = Color.FromArgb("#000000"),//Black
					StrokeThickness = 0.2
				};

				var grid1 = new Grid
				{
					ColumnDefinitions = new ColumnDefinitionCollection
				{
					new ColumnDefinition(GridLength.Star),
					new ColumnDefinition(GridLength.Auto)
				}
				};

				//var picker = new Picker
				//{
				//	SelectedItem = "{Binding SelectedItem}",
				//	ItemsSource = new List<string> { "ItemCode", "Description", "Unit", "ActiveCost", "UnitPrice", "BarCode" }
				//};

				//var label1 = new Label
				//{
				//	Text = FontAwesomeIcons.CaretDown,
				//	TextColor = Color.FromArgb("#404040"),//Gray600
				//	VerticalTextAlignment = TextAlignment.Center,
				//	FontFamily = "FAS"
				//};

				//grid1.Add(picker, 0, 0);
				//grid1.Add(label1, 1, 0);

				//border1.Content = grid1;

				//// Border 2
				//var border2 = new Border
				//{
				//	Stroke = Color.FromArgb("#252836"),//DarkBg1
				//	Padding = new Thickness(0, 3),
				//	HeightRequest = 40,
				//	StrokeShape = RoundRectangle(10),
				//	StrokeThickness = 0.3,
				//	WidthRequest = 300,
				//	HorizontalOptions = LayoutOptions.FillAndExpand
				//};

				var searchBar = new SearchBar
				{
					Placeholder = "Search",
					Text = "Hello"
				};

				//searchBar.Behaviors.Add(new EventToCommandBehavior
				//{
				//	EventName = "TextChanged",
				//	//Command = "{Binding SearchTextChangeCommand}"
				//});

				//border2.Content = searchBar;

				//horizontalStackLayout.Children.Add(border1);
				//horizontalStackLayout.Children.Add(border2);

				//var grid2 = new Grid
				//{
				//	ColumnDefinitions = new ColumnDefinitionCollection
				//{
				//	new ColumnDefinition(GridLength.Star)
				//}
				//};

				//// CollectionView
				//var collectionView = new CollectionView
				//{
				//	ItemsSource = "{Binding PurchaseList}",
				//	SelectionMode = SelectionMode.Single,
				//	SelectedItem = "{Binding SelectedInv}",
				//	SelectionChangedCommandParameter = "{Binding SelectedInv}",
				//	//SelectionChangedCommand = ,
				//	HeightRequest = 500,
				//	RemainingItemsThreshold = 3,
				//	//RemainingItemsThresholdReachedCommand = "{Binding LoadDataCommand}"
				//};

				//// CollectionView Header
				//var headerGrid = new Grid
				//{
				//	ColumnDefinitions = new ColumnDefinitionCollection
				//{
				//	new ColumnDefinition(GridLength.Star),
				//	new ColumnDefinition(GridLength.Star),
				//	new ColumnDefinition(GridLength.Star),
				//	new ColumnDefinition(GridLength.Star),
				//	new ColumnDefinition(GridLength.Star),
				//	new ColumnDefinition(GridLength.Star)
				//},
				//	Margin = new Thickness(0, 0, 0, 5)
				//};

				//headerGrid.Add(new Label { Text = "Item Code", FontAttributes = FontAttributes.Bold }, 0);
				//headerGrid.Add(new Label { Text = "Description", FontAttributes = FontAttributes.Bold }, 1);
				//headerGrid.Add(new Label { Text = "Unit", FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center }, 2);
				//headerGrid.Add(new Label { Text = "Active Cost", FontAttributes = FontAttributes.Bold }, 3);
				//headerGrid.Add(new Label { Text = "UnitPrice", FontAttributes = FontAttributes.Bold }, 4);
				//headerGrid.Add(new Label { Text = "BarCode", FontAttributes = FontAttributes.Bold }, 5);

				//collectionView.Header = headerGrid;

				//// CollectionView ItemTemplate
				//collectionView.ItemTemplate = new DataTemplate(typeof(InvitmTemplate));

				//grid2.Children.Add(collectionView);

				//verticalStackLayout.Children.Add(horizontalStackLayout);
				//verticalStackLayout.Children.Add(grid2);

				//return verticalStackLayout;
				var contentView = new ContentView
				{
					Content = verticalStackLayout
				};
				return contentView;
			}
			catch (Exception ex)
			{
				return null;
			}
			

		}

		public static Shape RoundRectangle(double radius)
		{
			return new Rectangle
			{
				RadiusX = radius,
				RadiusY = radius
			};
		}

		public class InvitmTemplate : DataTemplate
		{
			public InvitmTemplate() : base(LoadTemplate)
			{
			}

			static Grid LoadTemplate()
			{
				var grid = new Grid
				{
					ColumnDefinitions = new ColumnDefinitionCollection
					{
						new ColumnDefinition(GridLength.Star),
						new ColumnDefinition(GridLength.Star),
						new ColumnDefinition(GridLength.Star),
						new ColumnDefinition(GridLength.Star),
						new ColumnDefinition(GridLength.Star),
						new ColumnDefinition(GridLength.Star)
					},
					Margin = new Thickness(0, 5)
				};

				grid.Add(new Label { Text = "{Binding ItemCode}", }, 0);
				grid.Add(new Label { Text = "{Binding Description}" }, 1);
				grid.Add(new Label { Text = "{Binding Unit}", HorizontalTextAlignment = TextAlignment.Center }, 2);
				grid.Add(new Label { Text = "{Binding ActiveCost}" }, 3);
				grid.Add(new Label { Text = "{Binding UnitPrice}" }, 4);
				grid.Add(new Label { Text = "{Binding BarCode}" }, 5);

				return grid;
			}
		}
	}
}
