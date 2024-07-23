using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class BackOfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCustomerPartial()
        {
            return PartialView("~/Views/BackOffice/_AddCustomer.cshtml");
        }
    }
}
