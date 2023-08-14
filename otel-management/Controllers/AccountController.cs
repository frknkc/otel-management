using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;

namespace otel_management.Controllers
{
    public class AccountController : Controller
    {
        private readonly DatabaseCntx _databaseCntx;

        public AccountController(DatabaseCntx databaseCntx)
        {
            _databaseCntx = databaseCntx;
        }

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
                User user = new()
                {
                    Username = model.KullanıcıAd,
                    Password = model.KullanıcıSifre,
                    Email = model.Email,
                    FullName = model.AdSoyad
                };

                _databaseCntx.Users.Add(user);
                //_databaseCntx.SaveChanges();
                int affectedRowCount = _databaseCntx.SaveChanges();

                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("KullanıcıAd", "Kullanıcı eklenemedi!!");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            return View();
        }
    }
}
