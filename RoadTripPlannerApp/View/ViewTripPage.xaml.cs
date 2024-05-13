using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class ViewTripPage : ContentPage
{
	public ViewTripPage(ViewTripViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}