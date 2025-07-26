using SQLite;
using SisonkeBank.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SisonkeBank.Data
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseHelper(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
        }

        // Save new user (basic insert)
        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertAsync(user);
        }

        // Get user by email
        public Task<User> GetUserByEmailAsync(string email)
        {
            return _database.Table<User>().FirstOrDefaultAsync(u => u.Email == email);
        }

        // Update user data (e.g. balance)
        public Task<int> UpdateUserAsync(User user)
        {
            return _database.UpdateAsync(user);
        }

        // Get all users
        public Task<List<User>> GetAllUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        // ✅ Register a user if not already existing
        public async Task<bool> RegisterUserAsync(User user)
        {
            var existing = await _database.Table<User>()
                                          .Where(u => u.Email == user.Email)
                                          .FirstOrDefaultAsync();

            if (existing != null)
                return false; // Email already exists

            await _database.InsertAsync(user);
            return true; // Registration successful
        }
    }
}
