using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class ProfilePage : ContentPage
{
    public ProfilePage(ProfileViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}