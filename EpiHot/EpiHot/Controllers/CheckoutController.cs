using EpiHot.Models.Dto;
using EpiHot.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    [Authorize(Policy = "UserOrAdmin")]

    public class CheckoutController : Controller
    {
        private readonly CheckoutSvc _checkoutSvc;

        public CheckoutController(CheckoutSvc checkoutSvc)
        {
            _checkoutSvc = checkoutSvc;
        }

        public IActionResult Index(int reservationId)
        {
            var checkoutDetails = _checkoutSvc.GetCheckoutDetails(reservationId);
            return View(checkoutDetails);
        }
    }
}
