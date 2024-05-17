using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadTripPlannerApp.Services
{
    public class AlertService : IAlertService
    {
        public async Task ShowAlert(string title, string message)
        {
            await Shell.Current.DisplayAlert(title, message, "OK");
        }
        public async Task<bool> ShowConfirmation(string title, string message)
        {
            return await Shell.Current.DisplayAlert(title, message, "Yes", "No");
        }
    }
}
