using ASP.NET_Booking.Models;
using ASP.NET_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_Booking.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet]
        public async Task<IEnumerable<Hotel>> GetAll()
        {
            return await _hotelService.GetHotels();
        }
        [HttpGet("{id}")]
        [Route("EmptyRooms")]
        public async Task<IEnumerable<Room>> GetEmptyRoomsByHotelId(int id,DateTime DateStart,DateTime DateEnd)
        {
            return await _hotelService.GetRoomsByDateAndHotelId(id,DateStart,DateEnd);
        }
    }
}
