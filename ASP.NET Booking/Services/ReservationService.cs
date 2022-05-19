using ASP.NET_Booking.Models;
using ASP.NET_Booking.Repositories;
using ASP.NET_Booking.Services.Interfaces;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IAppData _appData;
        public ReservationService(IAppData appData)
        {
            _appData = appData;
        }
        public async Task<int> Add(Reservation reservation)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Get(int id)
        {
            return await _appData.Reservation.
        }
    }
}
