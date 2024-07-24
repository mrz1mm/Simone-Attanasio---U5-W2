using EpiHot.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationSvc _reservationSvc;
        public ReservationController(ReservationSvc reservationSvc)
        {
            _reservationSvc = reservationSvc;
        }

        public IActionResult Index()
        {
            var reservations = _reservationSvc.GetReservations();
            return View();
        }

        public IActionResult GetReservationsPartial()
        {
            var reservations = _reservationSvc.GetReservations();
            return PartialView("~/Views/Reservation/_GetReservations.cshtml", reservations);
        }

        public IActionResult AddReservationPartial()
        {
            return PartialView("~/Views/Reservation/_AddReservation.cshtml");
        }
    }
}
