using RoapTripPlannerApp.Model;
using SQLite;

namespace RoapTripPlannerApp.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection connection;
    public  DatabaseService()
    {
        if (connection != null)
            return;

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "database.db3");

        connection = new SQLiteAsyncConnection(dbPath);

        connection.CreateTableAsync<UserModel>();
        connection.CreateTableAsync<TripModel>();
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
    // Get the user that is logged in
    public async Task<UserModel> GetLoggedInUser()
    {
        return await connection.Table<UserModel>().Where(i => i.IsUserLoggedIn == true).FirstOrDefaultAsync();
    }
    // Update the user details
    public async Task UpdateUserDetails(UserModel user)
    { 
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
}
