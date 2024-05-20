using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class HomePage : ContentPage
{
    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}