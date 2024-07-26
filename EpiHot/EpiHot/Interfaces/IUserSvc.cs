using EpiHot.Models;
using EpiHot.Models.Dto;

namespace EpiHot.Services
{
    public interface IUserSvc
    {
        /// <summary>
        /// Ottiene un utente tramite le credenziali di accesso.
        /// </summary>
        /// <param name="userDto">DTO rappresentante le credenziali di accesso.</param>
        /// <returns>Oggetto User rappresentante l'utente.</returns>
        User GetUser(LoginDto userDto);

        /// <summary>
        /// Aggiunge un nuovo utente.
        /// </summary>
        /// <param name="registerDto">DTO rappresentante l'utente da registrare.</param>
        void AddUser(RegisterDto registerDto);
    }
}
