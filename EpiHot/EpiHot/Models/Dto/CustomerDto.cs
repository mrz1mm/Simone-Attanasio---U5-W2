using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models.Dto
{
    public class CustomerDto
    {
        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [Display(Name = "Nome")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [Display(Name = "Cognome")]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "La data di nascita è obbligatoria")]
        [Display(Name = "Data di nascita")]
        public DateOnly CustomerBirthDate { get; set; }

        [Required(ErrorMessage = "Il luogo di nascita è obbligatorio")]
        [Display(Name = "Luogo di nascita")]
        public string CustomerBirthCity { get; set; }

        [Required(ErrorMessage = "Il sesso è obbligatorio")]
        [Display(Name = "Sesso")]
        public Gender CustomerGender { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [Display(Name = "Codice fiscale")]
        public string CustomerFiscalCode { get; set; }

        [Required(ErrorMessage = "L'indirizzo è obbligatorio")]
        [Display(Name = "Indirizzo")]
        public string CustomerAddress { get; set; }

        [Required(ErrorMessage = "La cittù di residenza è obbligatoria")]
        [Display(Name = "Città di residenza")]
        public string CustomerCity { get; set; }

        [Required(ErrorMessage = "L'email è obbligatoria'")]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Telefono fisso")]
        public string? CustomerHomePhone { get; set; }

        [Required(ErrorMessage = "Il cellulare è obbligatorio")]
        [Display(Name = "Cellulare")]
        public string CustomerMobilePhone { get; set; }
    }
}
