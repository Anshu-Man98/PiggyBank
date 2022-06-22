using System;
using System.Threading.Tasks;
using PiggyBank.Model;
using SQLite;

namespace PiggyBank.Services
{
    public class UserCredentials:IUserCredentials
    {
        public SQLiteAsyncConnection _database;

        public UserCredentials(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<LoginData>();
        }

        public Task<bool> FindUserCredentialsAsync(LoginData loginData)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> FindUserCredentialsAsync(LoginData loginData)
        //{
        //     var userDetails = _database.Table<LoginData>().ToListAsync();
        //    foreach (var userCred in userDetails)
        //    {

        //    }

        //}
    }
}
