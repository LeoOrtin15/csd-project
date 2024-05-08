using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;
using System.Collections.Generic;

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
    }

    [RelayCommand]
    async Task LogOut()
    {
        // Search in the database for the user that is logged in
        List<UserModel> users = await database.GetAllUsers();
        foreach (UserModel user in users)
        {
            if (user.IsUserLoggedIn)
            {
                // Log out the user
                user.IsUserLoggedIn = false;
                await database.UpdateUserDetails(user);
                break;
            }
        }
        await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
    }
}
