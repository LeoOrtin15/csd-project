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
        public string? Name { get; set; }
        public string? FirstStop { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
