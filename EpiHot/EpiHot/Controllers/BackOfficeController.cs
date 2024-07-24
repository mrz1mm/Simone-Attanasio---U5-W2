using EpiHot.Models.Dto;
using EpiHot.Services;
using InputValidation.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class BackOfficeController : Controller
    {
        private readonly FiscalCodeSvc _fiscalCodeSvc;
        private readonly CsvCitySvc _citySvc;
        public BackOfficeController(FiscalCodeSvc _fiscalCodeSvc, CsvCitySvc _citySvc)
        {
            _fiscalCodeSvc = _fiscalCodeSvc;
            _citySvc = _citySvc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCustomerPartial()
        {
            return PartialView("~/Views/BackOffice/_AddCustomer.cshtml");
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
        public IActionResult CalculateFiscalCode([Bind("CustomerName, CustomerSurname, CustomerGender, CustomerBirthDate, CustomerBirthCity")] FiscalCodeDto1 customer)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Per favore, compila tutti i campi";
                return PartialView("~/Views/BackOffice/_AddCustomer.cshtml", customer);
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
            }
            catch
            {
                TempData["Error"] = "Errore nel calcolo del codice fiscale";
                return PartialView("~/Views/BackOffice/_AddCustomer.cshtml", customer);
            }
            return RedirectToAction("Index");
        }
    }
}
