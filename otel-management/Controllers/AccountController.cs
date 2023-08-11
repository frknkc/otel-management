using Microsoft.AspNetCore.Mvc;
using otel_management.Models;

namespace otel_management.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // login işlemleri
            }
            return View(model);
        }
        

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // register işlemleri
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
