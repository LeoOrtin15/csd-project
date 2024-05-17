using RoadTripPlannerApp.Model;

namespace RoadTripPlannerApp.Services
{
    public interface IDatabaseService
    {
        Task AddTrip(TripModel trip);
        Task AddUser(UserModel user);
        Task DeleteTrip(TripModel trip);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetLoggedInUser();
        Task<List<TripModel>> GetTrips();
        Task<UserModel> GetUser(string username);
        Task LogInUser(UserModel user);
        Task LogOutUser();
        Task UpdateTrip(TripModel trip);
        Task UpdateUserDetails(string email, string username, string password);
        Task AddStop(StopModel stop, TripModel trip);
        Task DeleteStop(StopModel stop);
        Task UpdateStop(StopModel stop);
        Task<List<StopModel>> GetStops(TripModel trip);
    }
}