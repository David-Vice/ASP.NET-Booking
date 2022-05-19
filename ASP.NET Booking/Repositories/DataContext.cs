using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace ASP.NET_Booking.Repositories
{
    public class DataContext
    {
        private static string ConnectionString = "";
        public static SqlConnection GetConnection()
        {
            ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("HotelDB");
            return new SqlConnection(ConnectionString);
        }
    }
}
