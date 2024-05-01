using SQLite;
using System.ComponentModel.DataAnnotations;

namespace RoapTripPlannerApp.Model
{
    [Table("user")]
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Unique, Required]
        public string? Username { get; set; }
        [Unique, Required, EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool? IsUserLoggedIn { get; set; } = false;
        //public List<TripModel>? Trips { get; set; }
    }
}
