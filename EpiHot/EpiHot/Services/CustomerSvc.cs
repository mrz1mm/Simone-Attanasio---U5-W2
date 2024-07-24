using EpiHot.Models;
using EpiHot.Models.Dto;
using Microsoft.Data.SqlClient;

namespace EpiHot.Services
{
    public class CustomerSvc
    {
        private readonly IConfiguration _config;
        public CustomerSvc(IConfiguration config)
        {
            _config = config;
        }

        public Customer GetCustomer(int customerId)
        {
            try
            {
                Customer customer = null;
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_BY_ID_CMD =
                        "SELECT * FROM Customers WHERE CustomerId = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(SELECT_BY_ID_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customer = new Customer
                                {
                                    CustomerId = reader.GetInt32(0),
                                    CustomerName = reader.GetString(1),
                                    CustomerSurname = reader.GetString(2),
                                    CustomerBirthDate = reader.GetDateTime(3),
                                    CustomerBirthCity = reader.GetString(4),
                                    CustomerGender = (Gender)Enum.Parse(typeof(Gender), reader.GetChar(5).ToString()),
                                    CustomerFiscalCode = reader.GetString(6),
                                    CustomerAddress = reader.GetString(7),
                                    CustomerCity = reader.GetString(8),
                                    CustomerEmail = reader.GetString(9),
                                    CustomerHomePhone = reader.GetString(10),
                                    CustomerMobilePhone = reader.GetString(11)
                                };
                            }
                        }
                    }
                }
                return customer;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero del cliente", ex);
            }
        }

        public List<Customer> GetCustomers()
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string SELECT_ALL_CMD =
                        "SELECT * FROM Customers";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL_CMD, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerId = reader.GetInt32(0),
                                    CustomerName = reader.GetString(1),
                                    CustomerSurname = reader.GetString(2),
                                    CustomerBirthDate = reader.GetDateTime(3),
                                    CustomerBirthCity = reader.GetString(4),
                                    CustomerGender = (Gender)Enum.Parse(typeof(Gender), reader.GetChar(5).ToString()),
                                    CustomerFiscalCode = reader.GetString(6),
                                    CustomerAddress = reader.GetString(7),
                                    CustomerCity = reader.GetString(8),
                                    CustomerEmail = reader.GetString(9),
                                    CustomerHomePhone = reader.GetString(10),
                                    CustomerMobilePhone = reader.GetString(11)
                                };
                                customers.Add(customer);
                            }
                        }
                    }
                }
                return customers;
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nel recupero dei clienti", ex);
            }
        }

        public void AddCustomer(CustomerDto customerDto)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string INSERT_CMD =
                        "INSERT INTO Customers (CustomerName, CustomerSurname, CustomerBirthDate, CustomerBirthCity, CustomerGender, CustomerFiscalCode, CustomerAddress, CustomerCity, CustomerEmail, CustomerHomePhone, CustomerMobilePhone) " +
                        "VALUES (@CustomerName, @CustomerSurname, @CustomerBirthDate, @CustomerBirthCity, @CustomerGender, @CustomerFiscalCode, @CustomerAddress, @CustomerCity, @CustomerEmail, @CustomerHomePhone, @CustomerMobilePhone)";
                    using (SqlCommand cmd = new SqlCommand(INSERT_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customerDto.CustomerName);
                        cmd.Parameters.AddWithValue("@CustomerSurname", customerDto.CustomerSurname);
                        cmd.Parameters.AddWithValue("@CustomerBirthDate", customerDto.CustomerBirthDate);
                        cmd.Parameters.AddWithValue("@CustomerBirthCity", customerDto.CustomerBirthCity);
                        cmd.Parameters.AddWithValue("@CustomerGender", customerDto.CustomerGender);
                        cmd.Parameters.AddWithValue("@CustomerFiscalCode", customerDto.CustomerFiscalCode);
                        cmd.Parameters.AddWithValue("@CustomerAddress", customerDto.CustomerAddress);
                        cmd.Parameters.AddWithValue("@CustomerCity", customerDto.CustomerCity);
                        cmd.Parameters.AddWithValue("@CustomerEmail", customerDto.CustomerEmail);
                        cmd.Parameters.AddWithValue("@CustomerHomePhone", customerDto.CustomerHomePhone);
                        cmd.Parameters.AddWithValue("@CustomerMobilePhone", customerDto.CustomerMobilePhone);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'inserimento del cliente", ex);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string UPDATE_CMD =
                        "UPDATE Customers SET CustomerName = @CustomerName, CustomerSurname = @CustomerSurname, CustomerBirthDate = @CustomerBirthDate, CustomerBirthCity = @CustomerBirthCity, CustomerGender = @CustomerGender, CustomerFiscalCode = @CustomerFiscalCode, CustomerAddress = @CustomerAddress, CustomerCity = @CustomerCity, CustomerEmail = @CustomerEmail, CustomerHomePhone = @CustomerHomePhone, CustomerMobilePhone = @CustomerMobilePhone " +
                        "WHERE CustomerId = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(UPDATE_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                        cmd.Parameters.AddWithValue("@CustomerSurname", customer.CustomerSurname);
                        cmd.Parameters.AddWithValue("@CustomerBirthDate", customer.CustomerBirthDate);
                        cmd.Parameters.AddWithValue("@CustomerBirthCity", customer.CustomerBirthCity);
                        cmd.Parameters.AddWithValue("@CustomerGender", customer.CustomerGender);
                        cmd.Parameters.AddWithValue("@CustomerFiscalCode", customer.CustomerFiscalCode);
                        cmd.Parameters.AddWithValue("@CustomerAddress", customer.CustomerAddress);
                        cmd.Parameters.AddWithValue("@CustomerCity", customer.CustomerCity);
                        cmd.Parameters.AddWithValue("@CustomerEmail", customer.CustomerEmail);
                        cmd.Parameters.AddWithValue("@CustomerHomePhone", customer.CustomerHomePhone);
                        cmd.Parameters.AddWithValue("@CustomerMobilePhone", customer.CustomerMobilePhone);
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'aggiornamento del cliente", ex);
            }
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    const string DELETE_CMD =
                        "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                    using (SqlCommand cmd = new SqlCommand(DELETE_CMD, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nell'eliminazione del cliente", ex);
            }
        }
    }
}