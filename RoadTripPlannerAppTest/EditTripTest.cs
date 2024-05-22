using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadTripPlannerAppTest
{
    public class EditTripTest
    {
        [Fact]
        public async Task LoadItinerary_OnNavigate_ItineraryDisplayed()
        {
            await Task.Delay(1);
        }
        [Fact]
        public async Task AddStop_ValidDates_StopAddedAndDsiplayed()
        {
            await Task.Delay(1);
        }
        [Fact]
        public async Task AddStop_InvalidDates_StopNotAdded()
        {
            await Task.Delay(1);
        }
        [Fact]
        public async Task DeleteStop_Clicked_StopDeteleted()
        {
            await Task.Delay(1);
        }
    }
}
