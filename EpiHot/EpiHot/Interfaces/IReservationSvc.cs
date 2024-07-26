using EpiHot.Models;
using EpiHot.Models.Dto;
using EpiHot.Models.MW;

namespace EpiHot.Services
{
    public interface IReservationSvc
    {
        /// <summary>
        /// Ottiene una prenotazione tramite il suo ID.
        /// </summary>
        /// <param name="reservationId">ID della prenotazione.</param>
        /// <returns>Oggetto Reservation rappresentante la prenotazione.</returns>
        Reservation GetReservation(int reservationId);

        /// <summary>
        /// Ottiene tutte le prenotazioni.
        /// </summary>
        /// <returns>Lista di prenotazioni.</returns>
        List<Reservation> GetReservations();

        /// <summary>
        /// Ottiene i dettagli delle prenotazioni.
        /// </summary>
        /// <returns>Lista di GetReservationMW con i dettagli delle prenotazioni.</returns>
        List<GetReservationMW> GetReservationsDetails();

        /// <summary>
        /// Ottiene le prenotazioni tramite il codice fiscale del cliente.
        /// </summary>
        /// <param name="fiscalCode">Codice fiscale del cliente.</param>
        /// <returns>Lista di ReservationByFiscalCodeDto con le prenotazioni.</returns>
        List<ReservationByFiscalCodeDto> GetReservationsByFiscalCode(string fiscalCode);

        /// <summary>
        /// Ottiene le prenotazioni con trattamento di pensione completa.
        /// </summary>
        /// <returns>Lista di GetReservationMW con le prenotazioni.</returns>
        List<GetReservationMW> GetReservationsByFullBoard();

        /// <summary>
        /// Aggiunge una nuova prenotazione.
        /// </summary>
        /// <param name="reservationDto">DTO rappresentante la prenotazione da aggiungere.</param>
        void AddReservation(ReservationDto reservationDto);

        /// <summary>
        /// Aggiorna una prenotazione esistente.
        /// </summary>
        /// <param name="reservationDto">DTO rappresentante la prenotazione da aggiornare.</param>
        void UpdateReservation(ReservationDto reservationDto);

        /// <summary>
        /// Elimina una prenotazione tramite il suo ID.
        /// </summary>
        /// <param name="id">ID della prenot
