using EpiHot.Models;
using EpiHot.Models.Dto;
using EpiHot.Services;
using InputValidation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EpiHot.Controllers
{
    [Authorize(Policy = Policies.User)]
    public class CustomerController : Controller
    {
        private readonly FiscalCodeSvc _fiscalCodeSvc;
        private readonly CsvCitySvc _citySvc;
        private readonly CustomerSvc _customerSvc;

        public CustomerController(FiscalCodeSvc fiscalCodeSvc, CsvCitySvc citySvc, CustomerSvc customerSvc)
        {
            _fiscalCodeSvc = fiscalCodeSvc;
            _citySvc = citySvc;
            _customerSvc = customerSvc;
        }

        public IActionResult Index()
        {
            var customers = _customerSvc.GetCustomers();
            return View(customers);
        }

        public IActionResult GetCustomersPartial()
        {
            var customers = _customerSvc.GetCustomers();
            return PartialView("~/Views/Customer/_GetCustomers.cshtml", customers);
        }

        public IActionResult AddCustomerPartial()
        {
            return PartialView("~/Views/Customer/_AddCustomer.cshtml");
        }

        public IActionResult UpdateCustomerPartial(int customerId)
        {
            var customer = _customerSvc.GetCustomer(customerId);
            return PartialView("~/Views/Customer/_UpdateCustomer.cshtml", customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCustomer([Bind("CustomerName, CustomerSurname, CustomerBirthDate, CustomerGender, CustomerBirthCity, CustomerFiscalCode, CustomerAddress, CustomerCity, CustomerEmail, CustomerHomePhone, CustomerMobilePhone")] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("AddCustomerPartial");
            }

            var city = _citySvc.GetCityById(int.Parse(customerDto.CustomerBirthCity));
            var newCustomer = new CustomerDto
            {
                CustomerName = customerDto.CustomerName,
                CustomerSurname = customerDto.CustomerSurname,
                CustomerBirthDate = customerDto.CustomerBirthDate,
                CustomerBirthCity = city.Name,
                CustomerGender = customerDto.CustomerGender,
                CustomerFiscalCode = customerDto.CustomerFiscalCode,
                CustomerAddress = customerDto.CustomerAddress,
                CustomerCity = customerDto.CustomerCity,
                CustomerEmail = customerDto.CustomerEmail,
                CustomerHomePhone = customerDto.CustomerHomePhone,
                CustomerMobilePhone = customerDto.CustomerMobilePhone
            };

            _customerSvc.AddCustomer(newCustomer);

            TempData["Success"] = "Cliente aggiunto";
            return RedirectToAction("Index", "Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCustomer([Bind("CustomerId, CustomerName, CustomerSurname, CustomerBirthDate, CustomerBirthCity, CustomerGender, CustomerFiscalCode, CustomerAddress, CustomerCity, CustomerEmail, CustomerHomePhone, CustomerMobilePhone")] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("Index");
            }

            _customerSvc.UpdateCustomer(customer);
            return RedirectToAction("Index", "Customer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(int customerId)
        {
            _customerSvc.DeleteCustomer(customerId);
            return Json(new { success = true });
        }

        public IActionResult GetProvinces()
        {
            var provinces = _citySvc.GetProvinces();
            return Json(provinces);
        }

        public IActionResult GetCities(string province)
        {
            var cities = _citySvc.GetByProvince(province);
            return Json(cities);
        }

        [HttpPost]
        public IActionResult CalculateFiscalCode([FromBody] FiscalCodeDto1 customer)
        {

            if (!ModelState.IsValid)
            {
                // Log degli errori del ModelState
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                Console.WriteLine($"Errori del ModelState: {string.Join(", ", errors)}");

                return BadRequest(new { message = "Per favore, compila tutti i campi", errors });
            }

            try
            {
                var city = _citySvc.GetCityById(int.Parse(customer.CustomerBirthCity));
                var newCustomer = new FiscalCodeDto2
                {
                    CustomerName = customer.CustomerName,
                    CustomerSurname = customer.CustomerSurname,
                    CustomerGender = customer.CustomerGender,
                    CustomerBirthDate = DateOnly.Parse(customer.CustomerBirthDate),
                    CustomerBirthCity = city
                };
                var fiscalCode = _fiscalCodeSvc.CalculateFiscalCode(newCustomer);
                return Ok(new { fiscalCode });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return BadRequest(new { message = "Errore nel calcolo del codice fiscale", error = ex.Message });
            }
        }
    }
}
