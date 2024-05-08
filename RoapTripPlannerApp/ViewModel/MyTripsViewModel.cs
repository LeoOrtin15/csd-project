using CommunityToolkit.Mvvm.ComponentModel;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using System.Collections.ObjectModel;

namespace RoapTripPlannerApp.ViewModel;

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
}
