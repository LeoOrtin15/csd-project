using RoadTripPlannerApp.Services;

namespace RoadTripPlannerApp.View;

public partial class LoadingPage : ContentPage
{
	private readonly IDatabaseService database;
    public LoadingPage(IDatabaseService database)
	{
        InitializeComponent();

        this.database = database;
    }
    override protected async void OnAppearing()
    {
        base.OnAppearing();
        if (await database.GetLoggedInUser() != null)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}