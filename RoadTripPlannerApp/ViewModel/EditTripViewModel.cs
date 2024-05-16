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
    public ObservableCollection<StopModel>? stops;
    [ObservableProperty]
    public ObservableCollection<DateModel> days;
    
    private readonly IDatabaseService database;
    public EditTripViewModel(IDatabaseService database)
    {
        this.database = database;
        Trip = new TripModel();
        Days = new ObservableCollection<DateModel>();
        LoadItinerary();
    }
    async void LoadItinerary()
    {
        await Task.Delay(100);

        List<StopModel> stopsList = await database.GetStops(Trip);

        Stops = new ObservableCollection<StopModel>(stopsList);
    }
    [RelayCommand]
    async Task Home()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
    [RelayCommand]
    async Task SaveTrip()
    {
        await database.UpdateTrip(Trip);

        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
