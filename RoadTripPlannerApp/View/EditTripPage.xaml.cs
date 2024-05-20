using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class EditTripPage : ContentPage
{
    public EditTripPage(EditTripViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}