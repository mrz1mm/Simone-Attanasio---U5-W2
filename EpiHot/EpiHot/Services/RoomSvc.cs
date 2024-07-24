using EpiHot.Models;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class RoomSvc
    {
        private readonly IConfiguration _config;
        public RoomSvc(IConfiguration config)
        {
            _config = config;
        }

        public Room GetRoom(int roomId)
        {
            try
            {
                Room room = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Rooms WHERE RoomId = @RoomId", conn))
                    {
                        cmd.Parameters.AddWithValue("@RoomId", roomId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                room = new Room
                                {
                                    RoomId = reader.GetInt32(0),
                                    RoomNumber = reader.GetString(1),
                                    RoomDescription = reader.GetString(2),
                                    RoomType = (RoomType)Enum.Parse(typeof(RoomType), reader.GetString(3)),
                                    RoomPrice = reader.GetDecimal(4)
                                };
                            }
                        }
                    }
                }
                return room;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero della stanza", ex);
            }
        }

        public List<Room> GetRooms()
        {
            try
            {
                List<Room> rooms = new List<Room>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Rooms", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Room room = new Room
                                {
                                    RoomId = reader.GetInt32(0),
                                    RoomNumber = reader.GetString(1),
                                    RoomDescription = reader.GetString(2),
                                    RoomType = (RoomType)Enum.Parse(typeof(RoomType), reader.GetString(3)),
                                    RoomPrice = reader.GetDecimal(4)
                                };
                                rooms.Add(room);
                            }
                        }
                    }
                }
                return rooms;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero delle stanze", ex);
            }
        }
    }
}
