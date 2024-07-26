using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models.Dto
{
    public class ReservationServiceDto
    {
        [Required(ErrorMessage = "Il numero di prenotazione è obbligatorio")]
        public int ReservationId { get; set; }
        
        [Required(ErrorMessage = "Il tipo di servizio è obbligatorio")]
        public int ServiceId { get; set; }
        
        [Required(ErrorMessage = "La data del servizio è obbligatoria")]
        public DateTime ServiceDate { get; set; } = DateTime.Now;
        
        [Required(ErrorMessage = "La quantità del servizio è obbligatoria")]
        public int ServiceQuantity { get; set; }
        
        [Required(ErrorMessage = "Il prezzo del servizio è obbligatorio")]
        public decimal ServicePrice { get; set; }
    }
}
