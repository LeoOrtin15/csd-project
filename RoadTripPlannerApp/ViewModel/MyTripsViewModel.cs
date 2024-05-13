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
    public static ObservableCollection<TripModel>? trips;
    private readonly DatabaseService database;
    public MyTripsViewModel(DatabaseService database)
    {
        this.database = database;

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
    async Task View(TripModel trip)
    {
        await Shell.Current.GoToAsync($"/{nameof(ViewTripPage)}", true, 
            new Dictionary<string, object>
            {
                { "Trip", trip }
            });
    }
    [RelayCommand]
    async Task Edit(TripModel trip)
    {
        await Shell.Current.GoToAsync($"/{nameof(EditTripPage)}", true,
            new Dictionary<string, object>
            {
                { "Trip", trip }
            });
    }
    [RelayCommand]
    async Task Delete(TripModel trip)
    {
        if (await App.Current.MainPage.DisplayAlert("Delete Trip", "Are you sure you want to delete this trip?", "Yes", "No"))
        {
            await database.DeleteTrip(trip);
            LoadTrips();
        }
    }
}
