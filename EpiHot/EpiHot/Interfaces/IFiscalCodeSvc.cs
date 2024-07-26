using EpiHot.Models;
using EpiHot.Models.Dto;

namespace EpiHot.Services
{
    public interface IFiscalCodeSvc
    {
        /// <summary>
        /// Calcola il codice fiscale.
        /// </summary>
        /// <param name="data">DTO con i dati necessari per il calcolo.</param>
        /// <returns>Codice fiscale calcolato.</returns>
        string CalculateFiscalCode(FiscalCodeDto2 data);

        /// <summary>
        /// Calcola il codice del cognome.
        /// </summary>
        /// <param name="surname">Cognome del cliente.</param>
        /// <returns>Codice del cognome.</returns>
        string CalculateSurname(string surname);

        /// <summary>
        /// Calcola il codice del nome.
        /// </summary>
        /// <param name="name">Nome del cliente.</param>
        /// <returns>Codice del nome.</returns>
        string CalculateName(string name);

        /// <summary>
        /// Calcola il codice della data di nascita.
        /// </summary>
        /// <param name="birthDate">Data di nascita.</param>
        /// <param name="gender">Genere del cliente.</param>
        /// <returns>Codice della data di nascita.</returns>
        string CalculateBirthDate(DateOnly birthDate, Gender gender);

        /// <summary>
        /// Calcola il codice del comune di nascita.
        /// </summary>
        /// <param name="birthCity">Città di nascita.</param>
        /// <returns>Codice del comune di nascita.</returns>
        string CalculateBirthCity(City birthCity);
    }
}
