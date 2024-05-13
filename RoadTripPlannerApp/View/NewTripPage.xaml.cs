using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class NewTripPage : ContentPage
{
	public NewTripPage(NewTripViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}