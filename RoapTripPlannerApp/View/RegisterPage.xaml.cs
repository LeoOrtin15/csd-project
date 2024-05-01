using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}