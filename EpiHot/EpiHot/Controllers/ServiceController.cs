﻿using EpiHot.Models;
using EpiHot.Models.Dto;
using EpiHot.Models.MW;
using EpiHot.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    [Authorize(Policy = "UserOrAdmin")]

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

        public IActionResult UpdateServicePartial(int serviceId)
        {
            var service = _serviceSvc.GetService(serviceId);
            return PartialView("~/Views/Service/_UpdateService.cshtml", service);
        }

        public IActionResult AddServiceToReservationPartial(int? reservationId)
        {
            var model = new AddReservationServiceMW
            {
                ReservationService = new ReservationServiceDto { ReservationId = reservationId ?? 0 },
                Reservations = _reservationSvc.GetReservations(),
                Services = _serviceSvc.GetServices()
            };
            return PartialView("_AddServiceToReservation", model);
        }

        public IActionResult UpdateServiceToReservationPartial(int reservationServiceId)
        {
            return PartialView("~/Views/Service/_UpdateServiceToReservation.cshtml");
        }


        public IActionResult AddService([Bind("ServiceType")] ServiceDto serviceDto)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("AddServicePartial");
            }

            _serviceSvc.AddService(serviceDto);

            TempData["Success"] = "Servizio aggiunto";
            return RedirectToAction("Index", "Service");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateService([Bind("ServiceId, ServiceType")] Service service)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("Index");
            }

            _serviceSvc.UpdateService(service);
            return RedirectToAction("Index", "Service");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteService(int serviceId)
        {
            _serviceSvc.DeleteService(serviceId);
            return Json(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddServiceToReservation(AddReservationServiceMW model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Errore nei dati inseriti";
                return RedirectToAction("AddServiceToReservationPartial");
            }

            _serviceSvc.AddServiceToReservation(model.ReservationService);

            TempData["Success"] = "Servizio aggiunto alla prenotazione";
            return RedirectToAction("Index", "Service");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateServiceToReservation(AddReservationServiceMW model)
        {
            return RedirectToAction("Index", "Service");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteServiceToReservation(int reservationServiceId)
        {
            _serviceSvc.DeleteServiceToReservation(reservationServiceId);
            return Json(new { success = true });
        }
    }
}
