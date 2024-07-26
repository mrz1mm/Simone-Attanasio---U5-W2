namespace EpiHot.Models.Dto
{
    public class FiscalCodeDto1
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerGender { get; set; }
        public string CustomerBirthDate { get; set; }
        public string CustomerBirthCity { get; set; }
    }

    public class FiscalCodeDto2
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerGender { get; set; }
        public DateOnly CustomerBirthDate { get; set; }
        public City CustomerBirthCity { get; set; }
    }
}
