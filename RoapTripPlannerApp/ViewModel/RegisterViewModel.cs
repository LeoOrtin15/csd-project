using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.View;

namespace RoapTripPlannerApp.ViewModel;

public partial class RegisterViewModel : ObservableObject
{

    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;
    [ObservableProperty]
    public string? email;

    public RegisterViewModel()
    {
        // Initialize the RegisterViewModel
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
                await App.Database.AddUser(new UserModel
                {
                    Email = Email,
                    Username = Username,
                    Password = Password
                });
                // Redirect to LoginPage
                await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
            }
        }
        catch (Exception)
        {
            await App.Current.MainPage.DisplayAlert("Invalid Data Entered", "'Email' and 'Username' must be unique", "OK");
        }
    }

    [RelayCommand]
    async Task Login()
    {
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
    }
}
