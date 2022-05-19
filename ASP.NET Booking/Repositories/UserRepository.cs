using ASP.NET_Booking.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly SqlConnection connection;
        public UserRepository()
        {
            connection = DataContext.GetConnection();
        }

        public async Task<int> Add(User data)
        {
            using (IDbConnection db = connection)
            {
                string query = @"INSERT INTO [dbo].Users(FirstName, LastName, Email, Password)
                                 VALUES ('@FirstName', '@LastNime', '@Email', '@Password')";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("FirstName", data.Name);
                parameters.Add("LastName", data.LastName);
                parameters.Add("Email", data.Email);
                parameters.Add("Password", data.Password);
                return await db.ExecuteAsync(query, parameters);
            }
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Users";
                IEnumerable<User> users = await db.QueryFirstAsync<IEnumerable<User>>(query);
                return users;
            }
        }

        public async Task<User> Get(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Users WHERE Users.Id = @Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);
                User user = await db.QueryFirstAsync<User>(query, parameters);
                return user;
            }
        }

        public Task<int> Update(User data)
        {
            throw new System.NotImplementedException();
        }

        // Custom Methods
        public async Task<User> GetByEmail(string email)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Users WHERE Users.Email = @Email";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", email);
                User user = await db.QueryFirstAsync<User>(query, parameters);
                return user;
            }
        }
    }
}