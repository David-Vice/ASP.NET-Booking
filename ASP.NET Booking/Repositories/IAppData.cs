namespace ASP.NET_Booking.Repositories
{
    public interface IAppData
    {
        HotelRepository Hotel { get; }
        ReservationRepository Reservation { get; }
        RoomRepository Room { get; }
        UserRepository User { get; }
    }
}
