using ASP.NET_Booking.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Repositories
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly SqlConnection _connection;
        public ReservationRepository()
        {
            _connection = DataContext.GetConnection();
        }
        public async Task<int> Add(Reservation data)
        {
            using (IDbConnection db = _connection)
            {
                string query = @"INSERT INTO [dbo].Reservations (RoomId, UserId, DateStart, DateEnd)
                VALUES (@RoomId, @UserId, @DateStart,  @DateEnd)"; 
                
                return await db.ExecuteAsync(query,
                    new
                    {
                        data.RoomId,
                        data.UserId,
                        data.DateStart,
                        data.DateEnd
                    }
                    );

            }
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Reservation> Get(int id)
        {
            using (IDbConnection db = _connection)
            {
                string query = @"SELECT * FROM Reservations WHERE Id = @Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);
                Reservation reservation = await db.QueryFirstAsync<Reservation>(query, parameters);
                return reservation;
            }
        }

        public Task<int> Update(Reservation data)
        {
            throw new System.NotImplementedException();
        }
    }
}
