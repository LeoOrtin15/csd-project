using RoapTripPlannerApp.Model;
using SQLite;

namespace RoapTripPlannerApp.Services;

public class DatabaseService
{
    readonly string _dbPath;

    private SQLiteAsyncConnection conn;

    public DatabaseService(string dbPath)
    {
        _dbPath = dbPath;
    }
    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<UserModel>();
    }

    public async Task AddUser(UserModel user)
    {
        await Init();

        // Add new user to the database
        await conn.InsertAsync(user);
        //await conn.InsertAsync(new UserModel
        //{
        //    Email = email,
        //    Username = username,
        //    Password = password
        //});

    }
    public async Task<List<UserModel>> GetAllUsers()
    {
        await Init();

        return await conn.Table<UserModel>().ToListAsync();
    }
    public async Task<UserModel> GetUser(int id)
    {
        await Init();

        return await conn.GetAsync<UserModel>(id);
    }
    public async Task UpdateUser(UserModel user)
    { 
        await Init();

        await conn.UpdateAsync(user);
    }
}
