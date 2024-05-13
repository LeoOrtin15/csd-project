using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;

namespace RoadTripPlannerApp.ViewModel;

[QueryProperty("Trip", "Trip")]
public partial class EditTripViewModel : ObservableObject
{
    [ObservableProperty]
    public TripModel trip;
    private readonly DatabaseService database;
    public EditTripViewModel(DatabaseService database)
    {
        this.database = database;
        Trip = new TripModel();
    }

    [RelayCommand]
    async Task SaveTrip()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
