using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;

namespace RoadTripPlannerApp.ViewModel;

public partial class RegisterViewModel : ObservableObject
{

    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;
    [ObservableProperty]
    public string? email;
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public RegisterViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;
    }

    [RelayCommand]
    public async Task Register()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await alertService.ShowAlert("Mandatory Fields Empty", "'Email', 'Username' and 'Password' are mandatory fields");
            }
            else
            {
                // Add user to de database
                await database.AddUser(new UserModel
                {
                    Email = Email,
                    Username = Username,
                    Password = Password
                });
                Email = "";
                Username = "";
                Password = "";
                // Redirect to LoginPage
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("UNIQUE constraint failed"))
                await alertService.ShowAlert("Invalid Data Entered", "'Email' and 'Username' must be unique");
            //else
            //    await alertService.ShowAlert("Error", ex.Message);
        }
    }

    [RelayCommand]
    public async Task Login()
    {
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
