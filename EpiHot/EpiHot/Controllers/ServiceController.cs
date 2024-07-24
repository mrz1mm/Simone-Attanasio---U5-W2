using EpiHot.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceSvc _serviceSvc;
        public ServiceController(ServiceSvc serviceSvc)
        {
            _serviceSvc = serviceSvc;
        }

        public IActionResult Index()
        {
            var services = _serviceSvc.GetServices();
            return View(services);
        }

        public IActionResult GetServicesPartial()
        {
            var services = _serviceSvc.GetServices();
            return PartialView("~/Views/Service/_GetServices.cshtml", services);
        }

        public IActionResult AddServicePartial()
        {
            return PartialView("~/Views/Service/_AddService.cshtml");
        }

        public IActionResult AddServiceToReservationPartial()
        {
            return PartialView("~/Views/Service/_AddServiceToReservation.cshtml");
        }
    }
}
