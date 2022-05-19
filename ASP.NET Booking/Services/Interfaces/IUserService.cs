using ASP.NET_Booking.Models;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(int id);
        Task<int> Add(User user);
    }
}
