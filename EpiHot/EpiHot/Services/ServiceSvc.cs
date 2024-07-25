using EpiHot.Models;
using EpiHot.Models.Dto;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class ServiceSvc
    {
        public readonly IConfiguration _config;
        public ServiceSvc(IConfiguration config)
        {
            _config = config;
        }

        public Service GetService(int serviceId)
        {
            try
            {
                Service service = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_BY_ID_COMMAND = "SELECT * FROM Services WHERE ServiceId = @ServiceId";
                    using (SqlCommand cmd = new SqlCommand(SELECT_BY_ID_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceId", serviceId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                service = new Service
                                {
                                    ServiceId = reader.GetInt32(0),
                                    ServiceType = reader.GetString(1)
                                };
                            }
                        }
                    }
                }
                return service;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero del servizio", ex);
            }
        }

        public List<Service> GetServices()
        {
            try
            {
                List<Service> services = new List<Service>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_ALL_COMMAND = "SELECT * FROM Services";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL_COMMAND, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Service service = new Service
                                {
                                    ServiceId = reader.GetInt32(0),
                                    ServiceType = reader.GetString(1)
                                };
                                services.Add(service);
                            }
                        }
                    }
                }
                return services;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei servizi", ex);
            }
        }

        public void AddService(ServiceDto serviceDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT_COMMAND = "INSERT INTO Services (ServiceType) VALUES (@ServiceType)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceType", serviceDto.ServiceType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'aggiunta del servizio", ex);
            }
        }

        public void AddServiceToReservation(ReservationServiceDto reservationService)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT_COMMAND = @"
                    INSERT INTO ReservationServices 
                    (ReservationId, ServiceId, ServiceDate, ServiceQuantity, ServicePrice) 
                    VALUES (@ReservationId, @ServiceId, @ServiceDate, @ServiceQuantity, @ServicePrice)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReservationId", reservationService.ReservationId);
                        cmd.Parameters.AddWithValue("@ServiceId", reservationService.ServiceId);
                        cmd.Parameters.AddWithValue("@ServiceDate", reservationService.ServiceDate);
                        cmd.Parameters.AddWithValue("@ServiceQuantity", reservationService.ServiceQuantity);
                        cmd.Parameters.AddWithValue("@ServicePrice", reservationService.ServicePrice);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'aggiunta del servizio alla prenotazione", ex);
            }
        }

        public void UpdateService(Service service)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string UPDATE_COMMAND = "UPDATE Services SET ServiceType = @ServiceType WHERE ServiceId = @ServiceId";
                    using (SqlCommand cmd = new SqlCommand(UPDATE_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceId", service.ServiceId);
                        cmd.Parameters.AddWithValue("@ServiceType", service.ServiceType);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'aggiornamento del servizio", ex);
            }
        }

        public void DeleteService(int serviceId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string DELETE_COMMAND = "DELETE FROM Services WHERE ServiceId = @ServiceId";
                    using (SqlCommand cmd = new SqlCommand(DELETE_COMMAND, conn))
                    {
                        cmd.Parameters.AddWithValue("@ServiceId", serviceId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'eliminazione del servizio", ex);
            }
        }
    }
}
