using EpiHot.Models.Dto;

namespace EpiHot.Models.MW
{
    public class ReservationServiceMW
    {
        public List<Reservation> Reservations { get; set; }
        public List<Service> Services { get; set; }
        public ReservationServiceDto ReservationService { get; set; }
    }
}
