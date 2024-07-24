namespace EpiHot.Models.Dto
{
    public class FiscalCodeDto1
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public Gender CustomerGender { get; set; }
        public DateTime CustomerBirthDate { get; set; }
        public int CustomerBirthCity { get; set; }
    }

    public class FiscalCodeDto2
    {
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public Gender CustomerGender { get; set; }
        public DateTime CustomerBirthDate { get; set; }
        public City CustomerBirthCity { get; set; }
    }
}
