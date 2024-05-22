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
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public ProfileViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;

        LoadUserDetails();
    }
    public async void LoadUserDetails()
    {
        UserModel user = await database.GetLoggedInUser();
        Username = user.Username;
        Email = user.Email;
        Password = user.Password;
    }
    [RelayCommand]
    public async Task Home()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    [RelayCommand]
    public async Task UpdateDetails()
    {
        try
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrEmpty(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await alertService.ShowAlert("Mandatory Fields Empty", "'Email', 'Username' and 'Password' are mandatory fields");
            }
            else
            {
                await database.UpdateUserDetails(Email, Username, Password);
                await alertService.ShowAlert("User Details Updated", "User details have been updated successfully");
            }
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("UNIQUE constraint failed"))
                await alertService.ShowAlert("Invalid Data Entered", "'Email' and 'Username' must be unique");
        }
    }
    [RelayCommand]
    public async Task LogOut()
    {
        // Log out the user
        await database.LogOutUser();
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
