using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class NewTripPage : ContentPage
{
	public NewTripPage(NewTripViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {

    }
}