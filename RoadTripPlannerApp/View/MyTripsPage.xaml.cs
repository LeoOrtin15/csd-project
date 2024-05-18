using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class MyTripsPage : ContentPage
{
    public MyTripsPage(MyTripsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}