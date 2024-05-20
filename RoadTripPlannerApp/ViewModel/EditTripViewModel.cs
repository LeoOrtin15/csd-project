using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoadTripPlannerApp.Model;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;
using System.Collections.ObjectModel;

namespace RoadTripPlannerApp.ViewModel;

[QueryProperty("Trip", "Trip")]
public partial class EditTripViewModel : ObservableObject
{
    [ObservableProperty]
    public TripModel trip;
    [ObservableProperty]
    public ObservableCollection<DayModel>? stopsByDay;
    [ObservableProperty]
    public ObservableCollection<DateTime> days;
    [ObservableProperty]
    public StopModel newStop;
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public EditTripViewModel(IDatabaseService database, IAlertService alertService)
    {
        this.database = database;
        this.alertService = alertService;
        Trip = new TripModel();
        Days = new ObservableCollection<DateTime>();
        newStop = new StopModel();
        LoadItinerary();
    }
    public async void LoadItinerary()
    {
        await Task.Delay(100);

        var stopsList = await database.GetStops(Trip);

        Days.Clear();

        for (DateTime date = Trip.StartDate; date <= Trip.EndDate; date = date.AddDays(1))
        {
            Days.Add(date);
        }

        StopsByDay = new ObservableCollection<DayModel>(
            Days.GroupJoin(
                stopsList,
                date => date,
                stop => stop.ArrivalDate.Date,
                (date, stopsOnDate) => new DayModel { Date = date, Stops = stopsOnDate.ToList() }));
    }
    [RelayCommand]
    public async Task Home()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    [RelayCommand]
    async Task MyTrips()
    {
        await Shell.Current.GoToAsync($"/{nameof(MyTripsPage)}");
    }
    [RelayCommand]
    public async Task UpdateStop(StopModel stop)
    {
        if (string.IsNullOrWhiteSpace(stop.StopName))
        {
            await alertService.ShowAlert("Stop Name Empty", "Please enter a stop name");
        }
        else
        {
            await database.UpdateStop(stop);
        }
    }
    [RelayCommand]
    public async Task DeleteStop(StopModel stop)
    {
        await database.DeleteStop(stop);
        LoadItinerary();
    }
    [RelayCommand]
    async Task AddStop()
    {
        if (string.IsNullOrWhiteSpace(NewStop.StopName))
        {
            await alertService.ShowAlert("Stop Name Empty", "Please enter a stop name");
        }
        else if (NewStop.ArrivalDate < Trip.StartDate || NewStop.ArrivalDate > Trip.EndDate)
        {
            await alertService.ShowAlert("Invalid Date", "Please enter a date within the trip dates");
        }
        else
        {
            await database.AddStop(NewStop, Trip);
            LoadItinerary();
            NewStop = new StopModel();
        }
    }
    [RelayCommand]
    public async Task UpdateTrip()
    {
        if (string.IsNullOrWhiteSpace(Trip.TripName))
        {
            await alertService.ShowAlert("Trip Name Empty", "Please enter a valid trip name");
            return;
        }
        await database.UpdateTrip(Trip);

        await Shell.Current.GoToAsync($"/{nameof(ViewTripPage)}", true,
            new Dictionary<string, object>
            {
                { "Trip", Trip }
            });
    }
}
