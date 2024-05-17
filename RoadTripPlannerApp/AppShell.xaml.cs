using RoadTripPlannerApp.View;

namespace RoadTripPlannerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));

            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));

            Routing.RegisterRoute(nameof(NewTripPage), typeof(NewTripPage));

            Routing.RegisterRoute(nameof(MyTripsPage), typeof(MyTripsPage));

            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));

            Routing.RegisterRoute(nameof(EditTripPage), typeof(EditTripPage));

            Routing.RegisterRoute(nameof(ViewTripPage), typeof(ViewTripPage));

        }
    }

}
