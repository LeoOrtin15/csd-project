using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        await Shell.Current.GoToAsync($"{nameof(NewTripPage)}");
    }
}
