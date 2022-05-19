using ASP.NET_Booking.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Repositories
{
    public class HotelRepository:IRepository<Hotel>
    {
        private readonly SqlConnection connection;
      
        public HotelRepository()
        {
            connection = DataContext.GetConnection();
        }

        public Task<int> Add(Hotel data)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Hotel> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Update(Hotel data)
        {
            throw new System.NotImplementedException();
        }
        public async Task<IEnumerable<Room>> GetAvailableRoomsByDate(int HotelId,DateTime startDate,DateTime endDate)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT Rooms.* FROM Rooms
                    LEFT JOIN Hotels ON Hotels.Id = Rooms.HotelId
                    WHERE Rooms.HotelId = @HotelId And Rooms.Id NOT IN (
                    SELECT Reservations.RoomId FROM Reservations
                    WHERE NOT ((@startDate < Reservations.DateStart AND @endDate < Reservations.DateStart) OR
                    (@startDate > Reservations.DateEnd AND @endDate > Reservations.DateEnd))
                    )";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@HotelId", HotelId);
                dynamicParameters.Add("@startDate", startDate);
                dynamicParameters.Add("@endDate", endDate);
                return await db.QueryAsync<Room>(query,dynamicParameters);
            }
        }

        public async Task<IEnumerable<Hotel>> GetAll()
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Hotels";
                return await db.QueryAsync<Hotel>(query);
            }
        }
    }
}
