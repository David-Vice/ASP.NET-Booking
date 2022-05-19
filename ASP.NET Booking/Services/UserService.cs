using ASP.NET_Booking.Models;
using ASP.NET_Booking.Services.Interfaces;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services
{
    public class UserService : IUserService
    {
        public Task<int> Add(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
