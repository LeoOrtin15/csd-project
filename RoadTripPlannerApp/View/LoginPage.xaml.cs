using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}