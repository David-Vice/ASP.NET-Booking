using ASP.NET_Booking.Models;
using ASP.NET_Booking.Repositories;
using ASP.NET_Booking.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Services
{
    public class HotelService : IHotelService
    {
        private readonly IAppData _appData;
        public HotelService(IAppData appData)
        {
            _appData = appData;
        }
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _appData.Hotel.Get();
        }
        //getavailable rooms by start and end date
        public async Task<IEnumerable<Room>> GetRoomsByDateAndHotelId(int HotelId,DateTime DateStart, DateTime DateEnd)
        {
            return await _appData.Hotel.GetAvailableRoomsByDate(HotelId,DateStart,DateEnd);
        }
    }
}
