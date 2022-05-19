using ASP.NET_Booking.Models;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Login(User user);

        Task<User> Register(User user);
    }
}
