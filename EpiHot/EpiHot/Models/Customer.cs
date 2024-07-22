namespace EpiHot.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public DateTime CustomerBirthDate { get; set; }
        public string CustomerBirthCity { get; set; }
        public Gender CustomerGender { get; set; }
        public string CustomerTaxIdCode { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerEmail { get; set; }
        public string? CustomerHomePhone { get; set; }
        public string CustomerMobilePhone { get; set; }
    }

        public enum Gender { M, F }
}
