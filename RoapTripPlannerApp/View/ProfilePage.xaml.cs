using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}