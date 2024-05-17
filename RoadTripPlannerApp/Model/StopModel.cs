using SQLite;

namespace RoadTripPlannerApp.Model
{
    [Table("stops")]
    public class StopModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int TripId { get; set; }
        public string? StopName { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
