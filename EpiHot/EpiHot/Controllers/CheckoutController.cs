using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
