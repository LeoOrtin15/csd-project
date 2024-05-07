using RoapTripPlannerApp.Services;

namespace RoapTripPlannerApp
{
    public partial class App : Application
    {
        public static DatabaseService? Database { get; set; }
        public App(DatabaseService db)
        {
            InitializeComponent();

            MainPage = new AppShell();

            Database = db;
        }
    }
}
