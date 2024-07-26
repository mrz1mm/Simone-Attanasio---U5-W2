using EpiHot.Models;
using EpiHot.Models.Dto;

namespace EpiHot.Services
{
    public interface IServiceSvc
    {
        /// <summary>
        /// Ottiene un servizio tramite il suo ID.
        /// </summary>
        /// <param name="serviceId">ID del servizio.</param>
        /// <returns>Oggetto Service rappresentante il servizio.</returns>
        Service GetService(int serviceId);

        /// <summary>
        /// Ottiene tutti i servizi.
        /// </summary>
        /// <returns>Lista di servizi.</returns>
        List<Service> GetServices();

        /// <summary>
        /// Aggiunge un nuovo servizio.
        /// </summary>
        /// <param name="serviceDto">DTO rappresentante il servizio da aggiungere.</param>
        void AddService(ServiceDto serviceDto);

        /// <summary>
        /// Aggiorna un servizio esistente.
        /// </summary>
        /// <param name="service">Oggetto Service rappresentante il servizio da aggiornare.</param>
        void UpdateService(Service service);

        /// <summary>
        /// Elimina un servizio tramite il suo ID.
        /// </summary>
        /// <param name="serviceId">ID del servizio da eliminare.</param>
        void DeleteService(int serviceId);

        /// <summary>
        /// Ottiene un servizio di prenotazione tramite il suo ID.
        /// </summary>
        /// <param name="reservationServiceId">ID del servizio di prenotazione.</param>
        /// <returns>Oggetto ReservationService rappresentante il servizio di prenotazione.</returns>
        ReservationService GetServiceToReservation(int reservationServiceId);

        /// <summary>
        /// Ottiene tutti i servizi di una prenotazione.
        /// </summary>
        /// <param name="reservationId">ID della prenotazione.</param>
        /// <returns>Lista di servizi di prenotazione.</returns>
        List<ReservationService> GetServicesToReservation(int reservationId);

        /// <summary>
        /// Aggiunge un servizio a una prenotazione.
        /// </summary>
        /// <param name="reservationService">DTO rappresentante il servizio di prenotazione da aggiungere.</param>
        void AddServiceToReservation(ReservationServiceDto reservationService);

        /// <summary>
        /// Aggiorna un servizio di prenotazione esistente.
        /// </summary>
        /// <param name="reservationService">Oggetto ReservationService rappresentante il servizio di prenotazione da aggiornare.</param>
        void UpdateServiceToReservation(ReservationService reservationService);

        /// <summary>
        /// Elimina un servizio di prenotazione tramite il suo ID.
        /// </summary>
        /// <param name="reservationServiceId">ID del servizio di prenotazione da eliminare.</param>
        void DeleteServiceToReservation(int reservationServiceId);
    }
}
