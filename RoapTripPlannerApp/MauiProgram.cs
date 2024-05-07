using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.View;
using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps();
            
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "users.db3");
            builder.Services.AddSingleton<DatabaseService>(s => ActivatorUtilities.CreateInstance<DatabaseService>(s, dbPath));

            builder.Services.AddSingleton<AuthenticationService>();

            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<RegisterViewModel>();

            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<LoginViewModel>();

            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<HomeViewModel>();

            builder.Services.AddSingleton<NewTripPage>();
            builder.Services.AddSingleton<NewTripViewModel>();

            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<ProfileViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
