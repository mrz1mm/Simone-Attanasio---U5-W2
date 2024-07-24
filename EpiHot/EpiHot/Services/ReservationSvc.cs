using EpiHot.Models;
using EpiHot.Models.Dto;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class ReservationSvc
    {
        private readonly IConfiguration _config;
        public ReservationSvc(IConfiguration config)
        {
            _config = config;
        }

        public Reservation GetReservation(int id)
        {
            try
            {
                Reservation reservation = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_BY_ID_CMD = "SELECT * FROM Reservations WHERE Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(SELECT_BY_ID_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                reservation = new Reservation
                                {
                                    ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId")),
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                    RoomId = reader.GetInt32(reader.GetOrdinal("RoomId")),
                                    ReservationNumber = reader.GetString(reader.GetOrdinal("ReservationNumber")),
                                    ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate")),
                                    ReservationStartStayDate = reader.GetDateTime(reader.GetOrdinal("ReservationStartStayDate")),
                                    ReservationEndStayDate = reader.GetDateTime(reader.GetOrdinal("ReservationEndStayDate")),
                                    ReservationDeposit = reader.GetDecimal(reader.GetOrdinal("ReservationDeposit")),
                                    ReservationPrice = reader.GetDecimal(reader.GetOrdinal("ReservationPrice")),
                                    ReservationType = (ReservationType)Enum.Parse(typeof(ReservationType), reader.GetString(9)),
                                    ReservationTypePrice = reader.GetDecimal(reader.GetOrdinal("ReservationTypePrice"))
                                };
                            }
                        }
                    }
                }
                return reservation;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting reservation", ex);
            }
        }

        public List<Reservation> GetReservations()
        {
            try
            {
                List<Reservation> reservations = new List<Reservation>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_ALL_CMD = "SELECT * FROM Reservations";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL_CMD, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Reservation reservation = new Reservation
                                {
                                    ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId")),
                                    CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                                    RoomId = reader.GetInt32(reader.GetOrdinal("RoomId")),
                                    ReservationNumber = reader.GetString(reader.GetOrdinal("ReservationNumber")),
                                    ReservationDate = reader.GetDateTime(reader.GetOrdinal("ReservationDate")),
                                    ReservationStartStayDate = reader.GetDateTime(reader.GetOrdinal("ReservationStartStayDate")),
                                    ReservationEndStayDate = reader.GetDateTime(reader.GetOrdinal("ReservationEndStayDate")),
                                    ReservationDeposit = reader.GetDecimal(reader.GetOrdinal("ReservationDeposit")),
                                    ReservationPrice = reader.GetDecimal(reader.GetOrdinal("ReservationPrice")),
                                    ReservationType = (ReservationType)Enum.Parse(typeof(ReservationType), reader.GetString(9).ToString()),
                                    ReservationTypePrice = reader.GetDecimal(reader.GetOrdinal("ReservationTypePrice"))
                                };
                                reservations.Add(reservation);
                            }
                        }
                    }
                }
                return reservations;
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting reservations", ex);
            }
        }

        public void AddReservation(ReservationDto reservationDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT_CMD = "INSERT INTO Reservations (CustomerId, RoomId, ReservationNumber, ReservationDate, ReservationStartStayDate, ReservationEndStayDate, ReservationDeposit, ReservationPrice, ReservationType, ReservationTypePrice) VALUES (@CustomerId, @RoomId, @ReservationNumber, @ReservationDate, @ReservationStartStayDate, @ReservationEndStayDate, @ReservationDeposit, @ReservationPrice, @ReservationType, @ReservationTypePrice)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", reservationDto.CustomerId);
                        cmd.Parameters.AddWithValue("@RoomId", reservationDto.RoomId);
                        cmd.Parameters.AddWithValue("@ReservationNumber", reservationDto.ReservationNumber);
                        cmd.Parameters.AddWithValue("@ReservationDate", reservationDto.ReservationDate);
                        cmd.Parameters.AddWithValue("@ReservationStartStayDate", reservationDto.ReservationStartStayDate);
                        cmd.Parameters.AddWithValue("@ReservationEndStayDate", reservationDto.ReservationEndStayDate);
                        cmd.Parameters.AddWithValue("@ReservationDeposit", reservationDto.ReservationDeposit);
                        cmd.Parameters.AddWithValue("@ReservationPrice", reservationDto.ReservationPrice);
                        cmd.Parameters.AddWithValue("@ReservationType", reservationDto.ReservationType.ToString());
                        cmd.Parameters.AddWithValue("@ReservationTypePrice", reservationDto.ReservationTypePrice);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding reservation", ex);
            }
        }

        public void UpdateReservation(Reservation reservation)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string UPDATE_CMD = "UPDATE Reservations SET CustomerId = @CustomerId, RoomId = @RoomId, ReservationNumber = @ReservationNumber, ReservationDate = @ReservationDate, ReservationStartStayDate = @ReservationStartStayDate, ReservationEndStayDate = @ReservationEndStayDate, ReservationDeposit = @ReservationDeposit, ReservationPrice = @ReservationPrice, ReservationType = @ReservationType, ReservationTypePrice = @ReservationTypePrice WHERE ReservationId = @ReservationId";
                    using (SqlCommand cmd = new SqlCommand(UPDATE_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", reservation.CustomerId);
                        cmd.Parameters.AddWithValue("@RoomId", reservation.RoomId);
                        cmd.Parameters.AddWithValue("@ReservationNumber", reservation.ReservationNumber);
                        cmd.Parameters.AddWithValue("@ReservationDate", reservation.ReservationDate);
                        cmd.Parameters.AddWithValue("@ReservationStartStayDate", reservation.ReservationStartStayDate);
                        cmd.Parameters.AddWithValue("@ReservationEndStayDate", reservation.ReservationEndStayDate);
                        cmd.Parameters.AddWithValue("@ReservationDeposit", reservation.ReservationDeposit);
                        cmd.Parameters.AddWithValue("@ReservationPrice", reservation.ReservationPrice);
                        cmd.Parameters.AddWithValue("@ReservationType", reservation.ReservationType.ToString());
                        cmd.Parameters.AddWithValue("@ReservationTypePrice", reservation.ReservationTypePrice);
                        cmd.Parameters.AddWithValue("@ReservationId", reservation.ReservationId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating reservation", ex);
            }
        }

        public void DeleteReservation(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string DELETE_CMD = "DELETE FROM Reservations WHERE ReservationId = @ReservationId";
                    using (SqlCommand cmd = new SqlCommand(DELETE_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationId", id);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting reservation", ex);
            }
        }
    }
}
