using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;
using System.Collections.ObjectModel;

namespace RoadTripPlannerApp.ViewModel;

[QueryProperty("Trip", "Trip")]
public partial class ViewTripViewModel : ObservableObject
{
    [ObservableProperty]
    public TripModel trip;
    [ObservableProperty]
    public ObservableCollection<StopModel>? stops;
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public ViewTripViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;
        Trip = new TripModel();
        LoadStops();
    }
    async void LoadStops()
    {
        List<StopModel> stopsList = await database.GetStops(Trip);

        Stops = new ObservableCollection<StopModel>(stopsList);
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
        if (await alertService.ShowConfirmation("Delete Trip", "Are you sure you want to delete this trip?"))
        {
            await database.DeleteTrip(Trip);
            await Shell.Current.GoToAsync($"/{nameof(MyTripsPage)}");
        }
    }
}