namespace EpiHot.Models
{
    public class ReservationService
    {
        public int ReservationServiceId { get; set; }
        public int ReservationId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ServiceDate { get; set; } = DateTime.Now;
        public int ServiceQuantity { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
