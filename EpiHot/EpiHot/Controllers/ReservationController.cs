﻿using EpiHot.Models;
using EpiHot.Models.Dto;
using EpiHot.Services;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationSvc _reservationSvc;
        private readonly CustomerSvc _customerSvc;
        private readonly RoomSvc _roomSvc;

        public ReservationController(ReservationSvc reservationSvc, CustomerSvc customerSvc, RoomSvc roomSvc)
        {
            _reservationSvc = reservationSvc;
            _customerSvc = customerSvc;
            _roomSvc = roomSvc;
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
            var customers = _customerSvc.GetCustomers();
            var rooms = _roomSvc.GetRooms();
            var model = new Models.MW.AddReservationMW
            {
                Customers = customers,
                Rooms = rooms,
                Reservation = new ReservationDto()
            };
            return PartialView("~/Views/Reservation/_AddReservation.cshtml", model);
        }

        [HttpGet]
        public IActionResult GetReservationsByFiscalCode(string fiscalCode)
        {
            var reservations = _reservationSvc.GetReservationsByFiscalCode(fiscalCode);
            return PartialView("_ReservationsByFiscalCodeResults", reservations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddReservation(Models.MW.AddReservationMW model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("Index");
            }

            _reservationSvc.AddReservation(model.Reservation);

            TempData["Success"] = "Prenotazione aggiunta con successo";
            return RedirectToAction("Index");
        }


        public IActionResult UpdateReservation(Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("Index");
            }

            _reservationSvc.UpdateReservation(reservation);

            TempData["Success"] = "Prenotazione aggiornata con successo";
            return RedirectToAction("Index");
        }


        public IActionResult DeleteReservation(int reservationId)
        {
            _reservationSvc.DeleteReservation(reservationId);

            TempData["Success"] = "Prenotazione eliminata con successo";
            return RedirectToAction("Index");
        }


    }
}
