namespace EpiHot.Models.MW
{
    public class CheckoutMW
    {
        public int ReservationId { get; set; }
        public int RoomNumber { get; set; }
        public DateTime StartStayDate { get; set; }
        public DateTime EndStayDate { get; set; }
        public decimal Tariff { get; set; }
        public decimal Deposit { get; set; }
        public ReservationType ReservationType { get; set; }
        public decimal AdditionalServicesTotal { get; set; }
        public decimal AmountToPay => Tariff - Deposit + AdditionalServicesTotal;
        public List<AdditionalService> AdditionalServices { get; set; }


        public class AdditionalService
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
}
