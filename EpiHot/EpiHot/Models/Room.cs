namespace EpiHot.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public string RoomDescription { get; set; }
        public RoomType RoomType { get; set; }
        public decimal RoomPrice { get; set; }
    }

    public enum RoomType
    {
        Single,
        Double
    }
}
