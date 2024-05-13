using RoadTripPlannerApp.Services;

namespace RoadTripPlannerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
