using ASP.NET_Booking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int id);
        Task<User> GetUserByEmail(string email);
        Task<int> Add(User user);
    }
}
