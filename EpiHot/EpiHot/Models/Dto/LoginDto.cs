using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "L'username è obbligatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La password è obbligatoria")]
        public string Password { get; set; }
    }
}
