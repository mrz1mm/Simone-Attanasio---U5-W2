using System.ComponentModel.DataAnnotations;

namespace EpiHot.Models.Dto
{
    public class ServiceDto
    {
        [Display(Name = "Tipo di servizio")]
        public string ServiceType { get; set; }
    }
}
