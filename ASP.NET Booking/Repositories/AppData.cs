namespace ASP.NET_Booking.Repositories
{
    public class AppData : IAppData
    {
        private readonly HotelRepository hotel;
        public HotelRepository Hotel => hotel ?? new HotelRepository();

        private readonly ReservationRepository reservation;
        public ReservationRepository Reservation => reservation ?? new ReservationRepository();

        private readonly RoomRepository room;
        public RoomRepository Room => room ?? new RoomRepository();

        private readonly UserRepository user;
        public UserRepository User => user ?? new UserRepository();
    }
}
