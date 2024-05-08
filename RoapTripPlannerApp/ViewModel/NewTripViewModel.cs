using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;
using System.Globalization;

namespace RoapTripPlannerApp.ViewModel;

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
    private readonly DatabaseService database;
    public NewTripViewModel(DatabaseService databaseService)
    {
        database = databaseService;
    }

    [RelayCommand]
    async Task CreateTrip()
    {
        TripModel trip = new TripModel
        {
            Name = TripName,
            FirstStop = FirstStop,
            StartDate = StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            EndDate = EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
        };

        await database.AddTrip(trip);

        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
