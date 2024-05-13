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
    private readonly DatabaseService database;
    public RegisterViewModel(DatabaseService database)
    {
        this.database = database;
    }

    [RelayCommand]
    async Task Register()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Mandatory Fields Empty", "'Email', 'Username' and 'Password' are mandatory fields", "OK");
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
                await App.Current.MainPage.DisplayAlert("Invalid Data Entered", "'Email' and 'Username' must be unique", "OK");
            else
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
        }
    }

    [RelayCommand]
    async Task Login()
    {
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
