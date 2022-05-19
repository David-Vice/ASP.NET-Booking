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
        private readonly SqlConnection connection;
        public ReservationRepository()
        {
            connection = DataContext.GetConnection();
        }
        public Task<int> Add(Reservation data)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> Get()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Reservation> Get(int id)
        {
            using (IDbConnection db = connection)
            {
                string query = @"SELECT * FROM Book WHERE Id = @Id";
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
