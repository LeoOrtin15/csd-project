using SQLite;

namespace RoadTripPlannerApp.Model
{
    [Table("trips")]
    public class TripModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int UserId { get; set; }
        public string? TripName { get; set; }
        public string? FirstStop { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
