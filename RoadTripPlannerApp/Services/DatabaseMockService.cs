using RoadTripPlannerApp.Model;

namespace RoadTripPlannerApp.Services
{
    public class DatabaseMockService : IDatabaseService
    {
        private List<UserModel> users;
        private List<TripModel> trips;
        private List<StopModel> stops;

        public DatabaseMockService()
        {
            users = new List<UserModel>();
            trips = new List<TripModel>();
            stops = new List<StopModel>();
        }
        public Task AddStop(StopModel stop, TripModel trip)
        {
            throw new NotImplementedException();
        }

        public Task AddTrip(TripModel trip)
        {
            throw new NotImplementedException();
        }

        public async Task AddUser(UserModel user)
        {
            await Task.Run(() => users.Add(user));
        }

        public Task DeleteStop(StopModel stop)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrip(TripModel trip)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            await Task.Delay(10);
            return users;
        }

        public Task<UserModel> GetLoggedInUser()
        {
            throw new NotImplementedException();
        }

        public Task<List<StopModel>> GetStops(TripModel trip)
        {
            throw new NotImplementedException();
        }

        public Task<List<TripModel>> GetTrips()
        {
            throw new NotImplementedException();
        }

        public async Task<UserModel> GetUser(string username)
        {
            await Task.Delay(10);
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            return (new UserModel());
        }

        public Task LogInUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task LogOutUser()
        {
            throw new NotImplementedException();
        }

        public Task UpdateStop(StopModel stop)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTrip(TripModel trip)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserDetails(string email, string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
