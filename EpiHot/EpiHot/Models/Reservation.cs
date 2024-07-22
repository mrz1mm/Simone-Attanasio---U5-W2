﻿namespace EpiHot.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public string ReservationNumber { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.Now;
        public DateTime ReservationStartStayDate { get; set; }
        public DateTime ReservationEndStayDate { get; set; }
        public decimal ReservationDeposit { get; set; }
        public decimal ReservationPrice { get; set; }
        public ReservationType ReservationType { get; set; }
    }

    public enum ReservationType
    {
        HalfBoard,
        FullBoard,
        OvernightWithBreakfast
    }
}
