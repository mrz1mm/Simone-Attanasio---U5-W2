using EpiHot.Models;
using EpiHot.Models.Dto;
using EpiHot.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EpiHot.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserSvc _userSvc;
        private readonly AuthSvc _authSvc;

        public AuthController(UserSvc service, AuthSvc authService)
        {
            _userSvc = service;
            _authSvc = authService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [Authorize(Policy = Policies.Admin)]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Password")] LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Errore nei dati inseriti";
                return View();
            }

            var user = _userSvc.GetUser(model);

            if (user == null)
            {
                TempData["error"] = "Account non esistente";
                return View();
            }
            _authSvc.Login(user);

            TempData["Success"] = "Login effettuato con successo";
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            _authSvc.Logout();

            TempData["success"] = "Sei stato disconnesso";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Register([Bind("Username, Password, RoleType")] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Errore nei dati inseriti";
                return View();
            }

            try
            {
                _userSvc.AddUser(model);
                TempData["success"] = "Registrazione effettuata con successo";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }
    }
}
