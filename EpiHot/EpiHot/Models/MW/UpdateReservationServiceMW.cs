using EpiHot.Models.Dto;

namespace EpiHot.Models.MW
{
    public class UpdateReservationServiceMW
    {
        public ReservationServiceDto ReservationService { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Service> Services { get; set; }
    }
}
