using EpiHot.Models.Dto;
using EpiHot.Services;
using InputValidation.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
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
        [AutoValidateAntiforgeryToken]
        public IActionResult CalculateFiscalCode([FromBody] FiscalCodeDto1 customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Per favore, compila tutti i campi");
            }

            try
            {
                var city = _citySvc.GetCityById(customer.CustomerBirthCity);
                var newCustomer = new FiscalCodeDto2
                {
                    CustomerName = customer.CustomerName,
                    CustomerSurname = customer.CustomerSurname,
                    CustomerGender = customer.CustomerGender,
                    CustomerBirthDate = customer.CustomerBirthDate,
                    CustomerBirthCity = city
                };
                var fiscalCode = _fiscalCodeSvc.CalculateFiscalCode(newCustomer);
                return Ok(new { fiscalCode });
            }
            catch
            {
                return BadRequest("Errore nel calcolo del codice fiscale");
            }
        }
    }
}
