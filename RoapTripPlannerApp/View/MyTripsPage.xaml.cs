using RoapTripPlannerApp.Model;
using RoapTripPlannerApp.Services;
using RoapTripPlannerApp.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoapTripPlannerApp.View;

public partial class MyTripsPage : ContentPage
{
    public MyTripsPage(MyTripsViewModel vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}