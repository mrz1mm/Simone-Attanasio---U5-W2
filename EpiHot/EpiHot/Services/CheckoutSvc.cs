using EpiHot.Models;
using EpiHot.Models.MW;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class CheckoutSvc : ICheckoutSvc
    {
        private readonly IConfiguration _config;

        public CheckoutSvc(IConfiguration config)
        {
            _config = config;
        }

        public CheckoutMW GetCheckoutDetails(int reservationId)
        {
            try
            {
                CheckoutMW checkoutDetails = null;
                List<CheckoutMW.AdditionalService> additionalServices = new List<CheckoutMW.AdditionalService>();

                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string QUERY = @"
                        SELECT 
                            r.ReservationId,
                            rm.RoomNumber,
                            r.ReservationStartStayDate,
                            r.ReservationEndStayDate,
                            r.ReservationPrice,
                            r.ReservationDeposit,
                            r.ReservationType,
                            ISNULL(rs.TotalServicePrice, 0) AS TotalServicePrice
                        FROM Reservations r
                        JOIN Rooms rm ON r.RoomId = rm.RoomId
                        LEFT JOIN (
                            SELECT 
                                ReservationId, 
                                SUM(ServicePrice * ServiceQuantity) AS TotalServicePrice
                            FROM ReservationsServices
                            GROUP BY ReservationId
                        ) rs ON r.ReservationId = rs.ReservationId
                        WHERE r.ReservationId = @ReservationId";

                    using (SqlCommand cmd = new SqlCommand(QUERY, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                checkoutDetails = new CheckoutMW
                                {
                                    ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId")),
                                    RoomNumber = reader.GetInt32(reader.GetOrdinal("RoomNumber")),
                                    StartStayDate = reader.GetDateTime(reader.GetOrdinal("ReservationStartStayDate")),
                                    EndStayDate = reader.GetDateTime(reader.GetOrdinal("ReservationEndStayDate")),
                                    Tariff = reader.GetDecimal(reader.GetOrdinal("ReservationPrice")),
                                    Deposit = reader.GetDecimal(reader.GetOrdinal("ReservationDeposit")),
                                    ReservationType = (ReservationType)Enum.Parse(typeof(ReservationType), reader.GetString(reader.GetOrdinal("ReservationType"))),
                                    AdditionalServicesTotal = reader.GetDecimal(reader.GetOrdinal("TotalServicePrice")),
                                    AdditionalServices = new List<CheckoutMW.AdditionalService>()
                                };
                            }
                        }
                    }

                    const string SERVICES_QUERY = @"
                        SELECT 
                            rs.ReservationServiceId,
                            rs.ReservationId,
                            rs.ServiceId,
                            s.ServiceType,
                            rs.ServiceDate,
                            rs.ServiceQuantity,
                            rs.ServicePrice
                        FROM ReservationsServices rs
                        JOIN Services s ON rs.ServiceId = s.ServiceId
                        WHERE rs.ReservationId = @ReservationId";

                    using (SqlCommand cmd = new SqlCommand(SERVICES_QUERY, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationId", reservationId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                additionalServices.Add(new CheckoutMW.AdditionalService
                                {
                                    ReservationServiceId = reader.GetInt32(reader.GetOrdinal("ReservationServiceId")),
                                    ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId")),
                                    ServiceId = reader.GetInt32(reader.GetOrdinal("ServiceId")),
                                    ServiceType = reader.GetString(reader.GetOrdinal("ServiceType")),
                                    ServiceDate = reader.GetDateTime(reader.GetOrdinal("ServiceDate")),
                                    ServiceQuantity = reader.GetInt32(reader.GetOrdinal("ServiceQuantity")),
                                    ServicePrice = reader.GetDecimal(reader.GetOrdinal("ServicePrice"))
                                });
                            }
                        }
                    }
                }

                if (checkoutDetails != null)
                {
                    checkoutDetails.AdditionalServices = additionalServices;
                }

                return checkoutDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei dettagli del checkout", ex);
            }
        }
    }
}
