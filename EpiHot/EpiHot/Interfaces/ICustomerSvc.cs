using EpiHot.Models;
using EpiHot.Models.Dto;

namespace EpiHot.Services
{
    public interface ICustomerSvc
    {
        /// <summary>
        /// Ottiene un cliente tramite il suo ID.
        /// </summary>
        /// <param name="customerId">ID del cliente.</param>
        /// <returns>Oggetto Customer rappresentante il cliente.</returns>
        Customer GetCustomer(int customerId);

        /// <summary>
        /// Ottiene tutti i clienti.
        /// </summary>
        /// <returns>Lista di clienti.</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Aggiunge un nuovo cliente.
        /// </summary>
        /// <param name="customerDto">DTO rappresentante il cliente da aggiungere.</param>
        void AddCustomer(CustomerDto customerDto);

        /// <summary>
        /// Aggiorna un cliente esistente.
        /// </summary>
        /// <param name="customer">Oggetto Customer rappresentante il cliente da aggiornare.</param>
        void UpdateCustomer(Customer customer);

        /// <summary>
        /// Elimina un cliente tramite il suo ID.
        /// </summary>
        /// <param name="customerId">ID del cliente da eliminare.</param>
        void DeleteCustomer(int customerId);
    }
}
