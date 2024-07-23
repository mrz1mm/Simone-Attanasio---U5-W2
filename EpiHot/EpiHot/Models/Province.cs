namespace EpiHot.Models
{
    public class Province
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Acronym { get; set; }

        public override bool Equals(object? obj) => obj is Province && obj.GetHashCode() == GetHashCode();
        public override int GetHashCode() => HashCode.Combine(Acronym);
    }
}
