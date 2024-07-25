using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models.Dto
{
    public class ReservationServiceDto
    {
        [Required]
        public int ReservationId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        public DateTime ServiceDate { get; set; } = DateTime.Now;

        [Required]
        public int ServiceQuantity { get; set; }

        [Required]
        public decimal ServicePrice { get; set; }
    }
}
