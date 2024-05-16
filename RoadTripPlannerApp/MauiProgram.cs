using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using RoadTripPlannerApp.Services;
using RoadTripPlannerApp.View;
using RoadTripPlannerApp.ViewModel;

namespace RoadTripPlannerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Register the ViewModels and Views
                .RegisterViewModels()
                .RegisterViews()
                // Register the App Services
                .RegisterAppServices()
                // Initialize the .NET MAUI Community Toolkit
                .UseMauiCommunityToolkit()
                // Initialize the .NET MAUI Maps
                .UseMauiMaps()
                // Initialize the Google Maps for Andriod & IOS
//#if ANDROID
//                .UseGoogleMaps()
//#elif IOS
//                .UseGoogleMaps("AIzaSyCk1AIoeHdPs2yYVAg_H2IiECAyBwVSWtA")
//#endif
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<RegisterViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<HomeViewModel>();
            builder.Services.AddTransient<ViewTripViewModel>();
            builder.Services.AddTransient<ProfileViewModel>();
            builder.Services.AddTransient<MyTripsViewModel>();
            builder.Services.AddTransient<EditTripViewModel>();
            builder.Services.AddTransient<NewTripViewModel>();


            return builder;
        }
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<RegisterPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<HomePage>();
            builder.Services.AddTransient<ViewTripPage>();
            builder.Services.AddTransient<LoadingPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<MyTripsPage>();
            builder.Services.AddTransient<EditTripPage>();
            builder.Services.AddTransient<NewTripPage>();


            return builder;
        }
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
            builder.Services.AddSingleton<IAlertService, AlertService>();

            return builder;
        }
    }
}
