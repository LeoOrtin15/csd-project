using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadTripPlannerApp.Model
{
    public class DayModel
    {
        public DateTime Date { get; set; }
        public List<StopModel>? Stops { get; set; }
    }
}
