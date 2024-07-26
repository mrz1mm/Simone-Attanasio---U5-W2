namespace EpiHot.Models.Dto
{
    public class CheckoutServiceDto
    {
        public int ReservationServiceId { get; set; }
        public int ReservationId { get; set; }
        public int ServiceId { get; set; }
        public string ServiceType { get; set; }
        public DateTime ServiceDate { get; set; }
        public int ServiceQuantity { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
