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
    public ObservableCollection<DayModel>? stopsByDay;
    [ObservableProperty]
    public ObservableCollection<DateTime> days;
    private readonly IDatabaseService database;
    private readonly IAlertService alertService;
    public ViewTripViewModel(IDatabaseService database, IAlertService alertService)
    {
        Trip = new TripModel();
        Days = new ObservableCollection<DateTime>();
        this.database = database;
        this.alertService = alertService;
        LoadItinerary();
    }
    async void LoadItinerary()
    {
        await Task.Delay(100);

        var stopsList = await database.GetStops(Trip);

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