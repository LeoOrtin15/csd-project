using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;

namespace RoadTripPlannerApp.ViewModel;

[QueryProperty("Trip", "Trip")]
public partial class ViewTripViewModel : ObservableObject
{
    [ObservableProperty]
    public TripModel trip;
    private readonly DatabaseService database;
    public ViewTripViewModel(DatabaseService database)
    {
        Trip = new TripModel();

        this.database = database;
    }
    [RelayCommand]
    async Task Home()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    [RelayCommand]
    async Task MyTrips()
    {
        await Shell.Current.GoToAsync($"/{nameof(MyTripsPage)}");
    }
    [RelayCommand]
    async Task Edit()
    {
        await Shell.Current.GoToAsync($"/{nameof(EditTripPage)}", true,
            new Dictionary<string, object>
            {
                { "Trip", Trip }
            });
    }
    [RelayCommand]
    async Task Delete()
    {
        if (await App.Current.MainPage.DisplayAlert("Delete Trip", "Are you sure you want to delete this trip?", "Yes", "No"))
        {
            await database.DeleteTrip(Trip);
            await Shell.Current.GoToAsync($"/{nameof(MyTripsPage)}");
        }
    }
}
