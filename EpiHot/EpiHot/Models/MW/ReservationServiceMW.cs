using EpiHot.Models.Dto;

namespace EpiHot.Models.MW
{
    public class ReservationServiceMW
    {
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
        public List<Service> Services { get; set; } = new List<Service>();
        public ReservationServiceDto ReservationService { get; set; } = new ReservationServiceDto();
    }
}
