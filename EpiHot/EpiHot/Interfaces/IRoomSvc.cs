using EpiHot.Models;

namespace EpiHot.Services
{
    public interface IRoomSvc
    {
        /// <summary>
        /// Ottiene una stanza tramite il suo ID.
        /// </summary>
        /// <param name="roomId">ID della stanza.</param>
        /// <returns>Oggetto Room rappresentante la stanza.</returns>
        Room GetRoom(int roomId);

        /// <summary>
        /// Ottiene tutte le stanze.
        /// </summary>
        /// <returns>Lista di stanze.</returns>
        List<Room> GetRooms();
    }
}
