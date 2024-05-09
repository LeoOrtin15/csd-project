using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class LoginPage : ContentPage
{
    private readonly DatabaseService database;
    public LoginPage(LoginViewModel vm, DatabaseService databaseService)
	{
		InitializeComponent();
		BindingContext = vm;
        database = databaseService;
    }
    override protected async void OnAppearing()
    {
        base.OnAppearing();
        if (await database.GetLoggedInUser() != null  )
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}