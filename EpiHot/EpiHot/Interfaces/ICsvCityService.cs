using EpiHot.Models;

namespace InputValidation.Services
{
    public interface ICsvCitySvc
    {
        /// <summary>
        /// Ottiene le città di una specifica provincia.
        /// </summary>
        /// <param name="acronym">Sigla della provincia.</param>
        /// <returns>Enumerable di città appartenenti alla provincia.</returns>
        IEnumerable<City> GetByProvince(string acronym);

        /// <summary>
        /// Ottiene una città tramite il suo ID.
        /// </summary>
        /// <param name="id">ID della città.</param>
        /// <returns>Oggetto City rappresentante la città.</returns>
        City GetCityById(int id);

        /// <summary>
        /// Ottiene una città tramite il suo nome.
        /// </summary>
        /// <param name="cityName">Nome della città.</param>
        /// <returns>Oggetto City rappresentante la città.</returns>
        City GetCityByName(string cityName);

        /// <summary>
        /// Ottiene tutte le province.
        /// </summary>
        /// <returns>Enumerable di province.</returns>
        IEnumerable<Province> GetProvinces();
    }
}
