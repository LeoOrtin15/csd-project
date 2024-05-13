using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;

namespace RoadTripPlannerApp.ViewModel;

public partial class ProfileViewModel : ObservableObject
{
    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;
    [ObservableProperty]
    public string? email;
    private readonly DatabaseService database;
    public ProfileViewModel(DatabaseService database)
    {
        this.database = database;
        LoadUserDetails();
    }
    async void LoadUserDetails()
    {
        UserModel user = await database.GetLoggedInUser();
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
    }

    [RelayCommand]
    async Task UpdateDetails()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await App.Current.MainPage.DisplayAlert("Mandatory Fields Empty", "'Email', 'Username' and 'Password' are mandatory fields", "OK");
            }
            else
            {
                await database.UpdateUserDetails(Email, Username, Password);
                await App.Current.MainPage.DisplayAlert("User Details Updated", "User details have been updated successfully", "OK");
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
    async Task LogOut()
    {
        // Log out the user
        await database.LogOutUser();
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
