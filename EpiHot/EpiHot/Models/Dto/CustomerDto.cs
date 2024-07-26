using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models.Dto
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "La data di nascita è obbligatoria")]
        public DateOnly CustomerBirthDate { get; set; }

        [Required(ErrorMessage = "Il luogo di nascita è obbligatorio")]
        public string CustomerBirthCity { get; set; }

        [Required(ErrorMessage = "Il sesso è obbligatorio")]
        public Gender CustomerGender { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        public string CustomerFiscalCode { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "La cittù di residenza è obbligatoria")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria'")]
        public string CustomerEmail { get; set; }

        public string? CustomerHomePhone { get; set; }

        [Required(ErrorMessage = "Il cellulare è obbligatorio")]
        public string CustomerMobilePhone { get; set; }
    }
}
