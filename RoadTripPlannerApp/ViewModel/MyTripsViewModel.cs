using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;
using System.Collections.ObjectModel;

namespace RoadTripPlannerApp.ViewModel;

public partial class MyTripsViewModel : ObservableObject
{
    [ObservableProperty]
    public ObservableCollection<TripModel>? trips;
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public MyTripsViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;

        LoadTrips();
    }
    async void LoadTrips()
    {
        List<TripModel> tripsList = await database.GetTrips();

        Trips = new ObservableCollection<TripModel>(tripsList);
    }
    [RelayCommand]
    async Task Home()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    [RelayCommand]
    async Task ViewTrip(TripModel trip)
    {
        await Shell.Current.GoToAsync($"/{nameof(ViewTripPage)}", true, 
            new Dictionary<string, object>
            {
                { "Trip", trip }
            });
    }
    [RelayCommand]
    async Task EditTrip(TripModel trip)
    {
        await Shell.Current.GoToAsync($"/{nameof(EditTripPage)}", true,
            new Dictionary<string, object>
            {
                { "Trip", trip }
            });
    }
    [RelayCommand]
    async Task DeleteTrip(TripModel trip)
    {
        if (await alertService.ShowConfirmation("Delete Trip", "Are you sure you want to delete this trip?"))
        {
            await database.DeleteTrip(trip);
            LoadTrips();
        }
    }
}
