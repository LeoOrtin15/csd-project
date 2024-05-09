using RoapTripPlannerApp.ViewModel;

namespace RoapTripPlannerApp.View;

public partial class EditTripPage : ContentPage
{
	public EditTripPage(EditTripViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}