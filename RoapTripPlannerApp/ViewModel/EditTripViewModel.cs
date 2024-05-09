using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;

namespace RoapTripPlannerApp.ViewModel;

[QueryProperty("Trip", "Trip")]
public partial class EditTripViewModel : ObservableObject
{
    [ObservableProperty]
    public TripModel? trip;
    private readonly DatabaseService database;
    public EditTripViewModel(DatabaseService database)
    {
        this.database = database;
    }

    [RelayCommand]
    async Task SaveTrip()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
