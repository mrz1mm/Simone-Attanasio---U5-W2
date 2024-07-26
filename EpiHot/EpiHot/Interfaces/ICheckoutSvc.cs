using EpiHot.Models.MW;

namespace EpiHot.Services
{
    public interface ICheckoutSvc
    {
        /// <summary>
        /// Ottiene i dettagli del checkout per una specifica prenotazione.
        /// </summary>
        /// <param name="reservationId">ID della prenotazione.</param>
        /// <returns>Oggetto CheckoutMW con i dettagli del checkout.</returns>
        CheckoutMW GetCheckoutDetails(int reservationId);
    }
}
