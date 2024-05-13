using SQLite;

namespace RoadTripPlannerApp.Model
{
    [Table("user")]
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique]
        public string? Username { get; set; }
        [Unique]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsUserLoggedIn { get; set; } = false;
    }
}
