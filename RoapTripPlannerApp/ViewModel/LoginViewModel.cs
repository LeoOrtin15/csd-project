using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;

namespace RoapTripPlannerApp.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    private readonly AuthenticationService _authenticationService;
    public LoginViewModel(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;

    [RelayCommand]
    async Task Login()
    {
        int userId = -1;
        // Check if the user is registered
        List<UserModel> users = await App.Database.GetAllUsers();
        foreach(UserModel user in users)
        {
            if (user.Username == Username)
            {
                userId = user.Id;
                break;
            }
        }
        if(userId == -1)
        {
            await App.Current.MainPage.DisplayAlert("User Not Registered", $"{String.Format("Username {0} is not registered", Username)}", "OK");
        }
        else
        {
            UserModel user = await App.Database.GetUser(userId);
            if(user.Password == Password)
            {
                user.IsUserLoggedIn = true;
                _authenticationService.Login();   
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Incorrect Password", "The password you entered is incorrect", "OK");
            }
        }
    }

    [RelayCommand]
    async Task Register()
    {
        await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
    }

    //[RelayCommand]
    //async Task OnAppearing()
    //{
    //    if (await _authenticationService.IsAuthenticatedAsync())
    //    {
    //        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    //    }
    //}
}
