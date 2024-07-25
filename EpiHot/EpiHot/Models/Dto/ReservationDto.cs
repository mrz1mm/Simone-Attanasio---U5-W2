namespace EpiHot.Models.Dto
{
    public class ReservationDto
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public DateTime ReservationStartStayDate { get; set; } = DateTime.Now;
        public DateTime ReservationEndStayDate { get; set; } = DateTime.Now;
        public decimal ReservationDeposit { get; set; }
        public decimal ReservationPrice { get; set; }
        public ReservationType ReservationType { get; set; }
    }
}
