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
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public LoginViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;
    }

    [RelayCommand]
    async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await alertService.ShowAlert("Mandatory Fields Empty", "'Username' and 'Password' are mandatory fields");
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
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                Username = "";
                Password = "";
            }
            else
            {
                await alertService.ShowAlert("Incorrect Password", "The password you entered is incorrect");
            }
        }
        else
        {
            await alertService.ShowAlert("User Not Registered", $"{String.Format("Username {0} is not registered", Username)}");
        }
    }

    [RelayCommand]
    async Task Register()
    {
        // Redirect to RegisterPage
        await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
        Username = "";
        Password = "";
    }
}
