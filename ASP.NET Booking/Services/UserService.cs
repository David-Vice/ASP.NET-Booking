using ASP.NET_Booking.Models;
using ASP.NET_Booking.Repositories;
using ASP.NET_Booking.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services
{
    public class UserService : IUserService
    {
        private readonly IAppData _data;
        public UserService(IAppData data)
        {
            _data = data;
        }
        public Task<int> Add(User user)
        {
           return _data.User.Add(user);
        }

        public Task<User> Get(int id)
        {
            return _data.User.Get(id);
        }
        public Task<User> GetUserByEmail(string email)
        {
            return _data.User.GetByEmail(email);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return _data.User.GetAll();
        }
    }
}
