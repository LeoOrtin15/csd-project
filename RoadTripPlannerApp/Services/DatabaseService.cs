using RoadTripPlannerApp.Model;
using SQLite;

namespace RoadTripPlannerApp.Services;

public class DatabaseService : IDatabaseService
{
    private readonly SQLiteAsyncConnection connection;
    public DatabaseService()
    {
        if (connection != null)
            return;

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");

        connection = new SQLiteAsyncConnection(dbPath);

        connection.CreateTableAsync<UserModel>();
        connection.CreateTableAsync<TripModel>();
        connection.CreateTableAsync<StopModel>();
    }

    // Add new user to the database
    public async Task AddUser(UserModel user)
    {
        await connection.InsertAsync(user);

    }
    // Get all users from the database
    public async Task<List<UserModel>> GetAllUsers()
    {
        return await connection.Table<UserModel>().ToListAsync();
    }
    // Get a user from the database by username
    public async Task<UserModel> GetUser(string username)
    {
        return await connection.Table<UserModel>().Where(i => i.Username == username).FirstOrDefaultAsync();
    }
    // Log in the user
    public async Task LogInUser(UserModel user)
    {
        user.IsUserLoggedIn = true;
        await connection.UpdateAsync(user);
    }
    // Log out the user
    public async Task LogOutUser()
    {
        // Search in the database for the user that is logged in
        var user = await GetLoggedInUser();
        // Log out the user
        user.IsUserLoggedIn = false;
        await connection.UpdateAsync(user);
    }
    // Get the user that is logged in
    public async Task<UserModel> GetLoggedInUser()
    {
        return await connection.Table<UserModel>().Where(i => i.IsUserLoggedIn == true).FirstOrDefaultAsync();
    }
    // Update the user details
    public async Task UpdateUserDetails(string email, string username, string password)
    {
        var user = await GetLoggedInUser();
        user.Username = username;
        user.Email = email;
        user.Password = password;
        await connection.UpdateAsync(user);
    }
    // Add a new trip to the database
    public async Task AddTrip(TripModel trip)
    {
        UserModel user = await GetLoggedInUser();

        trip.UserId = user.Id;

        await connection.InsertAsync(trip);
    }
    // Get all trips from the logged in user
    public async Task<List<TripModel>> GetTrips()
    {
        UserModel user = await GetLoggedInUser();

        return await connection.Table<TripModel>().Where(i => i.UserId == user.Id).ToListAsync();
    }

    // Update the trip details
    public async Task UpdateTrip(TripModel trip)
    {
        await connection.UpdateAsync(trip);
    }
    // Delete the trip
    public async Task DeleteTrip(TripModel trip)
    {
        await connection.DeleteAsync(trip);
    }
    // Add a new stop to the trip
    public async Task AddStop(StopModel stop, TripModel trip)
    {
        stop.TripId = trip.Id;
        await connection.InsertAsync(stop);
    }
    // Delete the stop
    public async Task DeleteStop(StopModel stop)
    {
        await connection.DeleteAsync(stop);
    }
    // Get all stops from the trip
    public async Task<List<StopModel>> GetStops(TripModel trip)
    {
        return await connection.Table<StopModel>().Where(i => i.TripId == trip.Id).ToListAsync();
    }
}