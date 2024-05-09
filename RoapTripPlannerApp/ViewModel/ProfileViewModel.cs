using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RoapTripPlannerApp.ViewModel;

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
    [RelayCommand]
    async Task LogOut()
    {
        // Log out the user
        await database.LogOutUser();
        // Redirect to LoginPage
        await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
    }
}
