using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class LoginPage : ContentPage
{
	private readonly AuthenticationService _authenticationService;
	public LoginPage(LoginViewModel vm, AuthenticationService authenticationService)
	{
		InitializeComponent();
		BindingContext = vm;
		_authenticationService = authenticationService;
	}
    override protected async void OnAppearing()
    {
        base.OnAppearing();
        if (await _authenticationService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}