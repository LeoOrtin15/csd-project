using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;
using System.Collections.Generic;

namespace RoapTripPlannerApp.ViewModel;

public partial class ProfileViewModel : ObservableObject
{
    private readonly AuthenticationService _authenticationService;
    public ProfileViewModel(AuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;
    [ObservableProperty]
    public string? email;

    [RelayCommand]
    async Task LogOut()
    {
        List<UserModel> users = await App.Database.GetAllUsers();
        foreach (UserModel user in users)
        {
            if (user.IsUserLoggedIn)
            {
                _authenticationService.Logout();
                user.IsUserLoggedIn = false;
                await App.Database.UpdateUser(user);
                break;
            }
        }
        await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
    }
}
