using EpiHot.Models.Dto;
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
            var reservations = _reservationSvc.GetReservationsDetails();
            return View(reservations);
        }

        public IActionResult GetReservationsPartial()
        {
            var reservations = _reservationSvc.GetReservationsDetails();
            return PartialView("~/Views/Reservation/_GetReservations.cshtml", reservations);
        }

        public IActionResult GetReservationsByFiscalCodePartial()
        {
            return PartialView("~/Views/Reservation/_GetReservationsByFiscalCode.cshtml");
        }

        public IActionResult GetReservationsByFullBoardPartial()
        {
            var reservations = _reservationSvc.GetReservationsByFullBoard();
            return PartialView("~/Views/Reservation/_GetReservationsByFullBoard.cshtml", reservations);
        }

        public IActionResult AddReservationPartial()
        {
            return PartialView("~/Views/Reservation/_AddReservation.cshtml");
        }

        [HttpGet]
        public IActionResult GetReservationsByFiscalCode(string fiscalCode)
        {
            var reservations = _reservationSvc.GetReservationsByFiscalCode(fiscalCode);
            return PartialView("_ReservationsByFiscalCodeResults", reservations);
        }
    }
}
