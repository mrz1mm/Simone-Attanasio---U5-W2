using EpiHot.Models.Dto;
using EpiHot.Models.MW;
using EpiHot.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServiceSvc _serviceSvc;
        private readonly ReservationSvc _reservationSvc;
        public ServiceController(ServiceSvc serviceSvc, ReservationSvc reservationSvc)
        {
            _serviceSvc = serviceSvc;
            _reservationSvc = reservationSvc;
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
            var reservations = _reservationSvc.GetReservations();
            var services = _serviceSvc.GetServices();
            var model = new ReservationServiceMW
            {
                Reservations = reservations,
                Services = services,
                ReservationService = new ReservationServiceDto()
            };
            return PartialView("~/Views/Service/_AddServiceToReservation.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddServiceToReservation([Bind("ReservationId, ServiceId, ServiceDate, ServiceQuantity, ServicePrice")] ReservationServiceMW model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("Index", "Service");
            }

            _serviceSvc.AddServiceToReservation(model.ReservationService);

            TempData["Success"] = "Servizio aggiunto alla prenotazione";
            return RedirectToAction("Index", "Service");
        }
    }
}
