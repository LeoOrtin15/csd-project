using CommunityToolkit.Mvvm.ComponentModel;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.View;
using System.Collections.Generic;

namespace RoapTripPlannerApp.ViewModel;

public partial class ProfileViewModel : ObservableObject
{
    public ProfileViewModel()
    {
    }

    [ObservableProperty]
    public string? username;
    [ObservableProperty]
    public string? password;
    [ObservableProperty]
    public string? email;
}
