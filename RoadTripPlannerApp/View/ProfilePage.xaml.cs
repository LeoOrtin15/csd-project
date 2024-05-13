using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp.View;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfileViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
    //override protected async void OnAppearing()
    //{
    //    base.OnAppearing();
    //    await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
    //}
}