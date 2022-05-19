using ASP.NET_Booking.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Repositories
{
    public class RoomRepository : IRepository<Room>
    {
        private readonly SqlConnection connection;
        public RoomRepository()
        {
            connection = DataContext.GetConnection();
        }
        public Task<int> Add(Room data)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

      
        public Task<Room> Get(int id)
        {
            throw new System.NotImplementedException();
            
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Rooms";
                return await db.QueryAsync<Room>(query);
            }
        }

        public Task<int> Update(Room data)
        {
            throw new System.NotImplementedException();
        }
    }
}
