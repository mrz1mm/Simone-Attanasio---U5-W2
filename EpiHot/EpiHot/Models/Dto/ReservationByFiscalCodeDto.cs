namespace EpiHot.Models.Dto
{
    public class ReservationByFiscalCodeDto
    {
        public int ReservationId { get; set; }
        public string CustomerFiscalCode { get; set; }
        public int RoomNumber { get; set; }
        public int ReservationNumber { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationStartStayDate { get; set; }
        public DateTime ReservationEndStayDate { get; set; }
        public decimal ReservationDeposit { get; set; }
        public decimal ReservationPrice { get; set; }
        public ReservationType ReservationType { get; set; }
    }
}
