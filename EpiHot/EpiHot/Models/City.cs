namespace EpiHot.Models
{
    public class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CadastralCode { get; set; }
        public required Province Province { get; set; }
    }
}
