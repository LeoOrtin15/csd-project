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
    private readonly DatabaseService database;
    public NewTripViewModel(DatabaseService databaseService)
    {
        database = databaseService;
    }

    [RelayCommand]
    async Task CreateTrip()
    {
        if (string.IsNullOrWhiteSpace(TripName) || string.IsNullOrWhiteSpace(FirstStop))
        {
            await App.Current.MainPage.DisplayAlert("Mandatory Fields Empty", "'Trip Name' and 'First Stop' are mandatory fields", "OK");
            return;
        }
        TripModel trip = new TripModel
        {
            Name = TripName,
            FirstStop = FirstStop,
            StartDate = StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
            EndDate = EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
        };
        await database.AddTrip(trip);

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
