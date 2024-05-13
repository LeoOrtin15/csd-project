using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;

namespace RoadTripPlannerApp.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;
    private readonly DatabaseService database;
    public LoginViewModel(DatabaseService databaseService)
    {
        database = databaseService;
    }

    [RelayCommand]
    async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await App.Current.MainPage.DisplayAlert("Mandatory Fields Empty", "'Username' and 'Password' are mandatory fields", "OK");
            return;
        }
        // Search in the database for the user that is trying to log in
        UserModel currentUser = await database.GetUser(Username);
        if (currentUser != null)
        {
            // If the user is found (registered), check if the password is correct
            if (currentUser.Password == Password)
            {
                await database.LogInUser(currentUser);
                Username = "";
                Password = "";
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Incorrect Password", "The password you entered is incorrect", "OK");
            }
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("User Not Registered", $"{String.Format("Username {0} is not registered", Username)}", "OK");
        }
    }

    [RelayCommand]
    async Task Register()
    {
        // Redirect to RegisterPage
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
