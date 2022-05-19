using ASP.NET_Booking.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services.Interfaces
{
    public interface IReservationService
    {
        Task<Reservation> Get(int id);
        Task<int> Add(Reservation reservation);
    }
}
