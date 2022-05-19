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
            return await _appData.Reservation.Add(reservation);
        }

        public async Task<Reservation> Get(int id)
        {
            return await _appData.Reservation.Get(id);
        }
    }
}
