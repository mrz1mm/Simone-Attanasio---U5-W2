using EpiHot.Models;

namespace EpiHot.Services
{
    public interface IAuthSvc
    {
        /// <summary>
        /// Effettua il login dell'utente.
        /// </summary>
        /// <param name="user">L'utente da autenticare.</param>
        /// <returns>Task rappresentante l'operazione asincrona.</returns>
        Task Login(User user);

        /// <summary>
        /// Effettua il logout dell'utente.
        /// </summary>
        /// <returns>Task rappresentante l'operazione asincrona.</returns>
        Task Logout();
    }
}
