using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;
using System.Globalization;

namespace RoadTripPlannerApp.ViewModel;

public partial class NewTripViewModel : ObservableObject
{
    [ObservableProperty]
    public string? tripName;
    [ObservableProperty]
    public string? firstStop;
    [ObservableProperty]
    public DateTime startDate;
    [ObservableProperty]
    public DateTime endDate;
    [ObservableProperty]
    public DateTime today = DateTime.Today;
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public NewTripViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;
    }
    [RelayCommand]
    async Task Home()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    [RelayCommand]
    async Task CreateTrip()
    {
        if (string.IsNullOrWhiteSpace(TripName) || string.IsNullOrWhiteSpace(FirstStop))
        {
            await alertService.ShowAlert("Mandatory Fields Empty", "'Trip TripName' and 'First Stop' are mandatory fields");
            return;
        }
        TripModel trip = new TripModel
        {
            TripName = TripName,
            FirstStop = FirstStop,
            StartDate = StartDate,
            EndDate = EndDate
        };

        StopModel stop = new StopModel
        {
            TripId = trip.Id,
            StopName = FirstStop,
            ArrivalDate = StartDate
        };
        await database.AddTrip(trip);

        await database.AddStop(stop, trip);

        TripName = "";
        FirstStop = "";
        StartDate = DateTime.Today;
        EndDate = DateTime.Today;

        await Shell.Current.GoToAsync($"/{nameof(EditTripPage)}", true, 
            new Dictionary<string, object>
            {
                { "Trip", trip }
            });
    }
}
