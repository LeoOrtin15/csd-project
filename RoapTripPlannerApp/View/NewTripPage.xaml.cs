using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class NewTripPage : ContentPage
{
	public NewTripPage(NewTripViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}