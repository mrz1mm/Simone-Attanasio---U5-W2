namespace EpiHot.Models.Dto
{
    public class ReservationServiceDto
    {
        public int ReservationId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ServiceDate { get; set; } = DateTime.Now;
        public int ServiceQuantity { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
