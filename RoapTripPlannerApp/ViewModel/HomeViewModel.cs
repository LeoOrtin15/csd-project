using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.View;

namespace RoapTripPlannerApp.ViewModel;

public partial class HomeViewModel : ObservableObject
{
    public HomeViewModel()
    {

    }

    [RelayCommand]
    async Task NewTrip()
    {
        await Shell.Current.GoToAsync($"/{nameof(NewTripPage)}");
    }
    [RelayCommand]
    async Task MyTrips()
    {
        await Shell.Current.GoToAsync($"/{nameof(MyTripsPage)}");
    }
    [RelayCommand]
    async Task Profile()
    {
        await Shell.Current.GoToAsync($"/{nameof(ProfilePage)}");
    }
}
