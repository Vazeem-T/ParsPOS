namespace ParsVanSale.Views.Controls;

public partial class DraggableButtonView : ContentView
{
    private double offsetX;
    private double offsetY;

    public DraggableButtonView()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        var button = (Button)sender;
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                offsetX = button.TranslationX;
                offsetY = button.TranslationY;
                break;

            case GestureStatus.Running:
                var newX = button.TranslationX + e.TotalX - offsetX;
                var newY = button.TranslationY + e.TotalY - offsetY;

                button.TranslationX = newX;
                button.TranslationY = newY;

                offsetX = e.TotalX;
                offsetY = e.TotalY;
                break;

            case GestureStatus.Completed:
                // Handle touch-up event if needed
                break;
        }
    }
}