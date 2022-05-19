using ASP.NET_Booking.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services.Interfaces
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> GetHotels();
        Task<IEnumerable<Room>> GetRoomsByDateAndHotelId(int HotelId, DateTime DateStart, DateTime DateEnd);
    }
}
