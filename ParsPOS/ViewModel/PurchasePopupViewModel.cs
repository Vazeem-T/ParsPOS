using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace ParsPOS.ViewModel
{
    public partial class PurchasePopupViewModel : BaseViewModel
    {
        public ObservableCollection<dynamic> Items { get; set; } = new();

        [ObservableProperty]
        List<string> _headers;

        [ObservableProperty]
        List<List<string>> _data;
        
        [ObservableProperty]
        Grid headergrid;

        [ObservableProperty]
        double height;

        [ObservableProperty]
        double width;
        public PurchasePopupViewModel(int width,int height ,string title) 
        {
            Height = height;
            Width = width;
            Title = title;
        }



        private void CreateDynamicGrid()
        {
            // Define the number of columns dynamically
            int numberOfColumns = GetNumberOfColumns(); // Implement this method based on your logic

            // Create columns dynamically
            for (int i = 0; i < numberOfColumns; i++)
            {
                Headergrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Populate data dynamically
            List<List<string>> dynamicData = GetDynamicData(); // Implement this method based on your logic

            for (int row = 0; row < dynamicData.Count; row++)
            {
                for (int col = 0; col < dynamicData[row].Count; col++)
                {
                    // Create a label for each data item
                    Label label = new Label
                    {
                        Text = dynamicData[row][col],
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    };

                    // Add the label to the grid
                    Headergrid.Add(label, col, row);
                }
            }
        }

        // Implement your logic to get the number of columns dynamically
        private int GetNumberOfColumns()
        {
            // Example logic, replace with your implementation
            return 3;
        }

        // Implement your logic to get dynamic data
        private List<List<string>> GetDynamicData()
        {
            // Example logic, replace with your implementation
            return new List<List<string>>
            {
                new List<string> { "Data 1", "Data 2", "Data 3" },
                new List<string> { "Data 4", "Data 5", "Data 6" },
                new List<string> { "Data 7", "Data 8", "Data 9" }
            };
        }
    }
}
