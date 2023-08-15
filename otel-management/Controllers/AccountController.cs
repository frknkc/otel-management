using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;
using System.Security.Claims;

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
                User user = _databaseCntx.Users.SingleOrDefault(x => x.Username.ToLower() == model.KullanıcıAd.ToLower() && x.Password == model.KullanıcıSifre);

                if (user != null )
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName ?? string.Empty));
                    claims.Add(new Claim("Username", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre yanlış!!!");
                }
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
                if (_databaseCntx.Users.Any(x => x.Username.ToLower() == model.KullanıcıAd.ToLower())) 
                {
                    ModelState.AddModelError(nameof(model.KullanıcıAd), "Lütfen farklı bir kullanıcı adı giriniz.");
                    return View(model);
                }
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
        [HttpPost]
        public IActionResult ProfileChangeFullName(string fullname)
        {

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }
    }
}
