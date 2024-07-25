using EpiHot.Models.Dto;

namespace EpiHot.Models.MW
{
    public class AddReservationMW
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Room> Rooms { get; set; } = new List<Room>();
        public ReservationDto Reservation { get; set; } = new Dto.ReservationDto();
    }
}
