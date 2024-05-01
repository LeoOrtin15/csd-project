using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using RoapTripPlannerApp.ViewModel;
using Microsoft.Maui.Devices.Sensors;

namespace RoapTripPlannerApp.View;

public partial class HomePage : ContentPage
{
	public HomePage(HomeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
    }
}