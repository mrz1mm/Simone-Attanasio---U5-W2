using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models.Dto
{
    public class ReservationDto
    {
        [Required(ErrorMessage = "Il numero di prenotazione è obbligatorio")]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Il codice fiscale del cliente è obbligatorio")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Il numero della camera è obbligatorio")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "La data di prenotazione è obbligatorio")]
        public DateTime ReservationDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La data di inizio del soggiorno è obbligatoria")]
        public DateTime ReservationStartStayDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La data di fine del soggiorno è obbligatoria")]
        public DateTime ReservationEndStayDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Il deposito di prenotazione è obbligatorio")]
        public decimal ReservationDeposit { get; set; }

        [Required(ErrorMessage = "Il prezzo della prenotazione è obbligatorio")]
        public decimal ReservationPrice { get; set; }

        [Required(ErrorMessage = "Il tipo di prenotazione è obbligatorio")]
        public ReservationType ReservationType { get; set; }
    }
}
