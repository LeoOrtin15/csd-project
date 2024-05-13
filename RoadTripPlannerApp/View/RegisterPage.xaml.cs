using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}