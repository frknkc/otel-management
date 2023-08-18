using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace otel_management.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DatabaseCntx _databaseCntx;

        public AccountController(DatabaseCntx databaseCntx)
        {
            _databaseCntx = databaseCntx;
        }
        [AllowAnonymous]

        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _databaseCntx.Users.SingleOrDefault(x => x.Username.ToLower() == model.KullanıcıAd.ToLower());
                    //Users.SingleOrDefault(x => x.Username.ToLower() == model.KullanıcıAd.ToLower() && x.Password == model.KullanıcıSifre);

                if (user != null )
                {
                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.FullName ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role ));
                    claims.Add(new Claim("Username", user.Username));

                    ClaimsIdentity identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                    ViewData["result"] = "LoginOk";

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adı veya Şifre yanlış!!!");
                    ViewData["result"] = "LoginX";

                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseCntx.Users.Any(x => x.Username.ToLower() == model.KullanıcıAd.ToLower())) 
                {
                    ModelState.AddModelError(nameof(model.KullanıcıAd), "Lütfen farklı bir kullanıcı adı giriniz.");
                    ViewData["result"] = "RegisterX";

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
                ViewData["result"] = "RegisterOk";

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
            ProfileLoader();
            return View("Profile");

            
        }
        void ProfileLoader()
        {
            Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseCntx.Users.SingleOrDefault(x => x.Id == userid);
            ViewData["FullName"] = user.FullName;
            ViewData["Email"] = user.Email;

        }
        [HttpPost]
        public IActionResult ProfileChangeFullName([Required][StringLength(50)] string? fullname)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseCntx.Users.SingleOrDefault(x => x.Id == userid);

                user.FullName = fullname;
                _databaseCntx.SaveChanges(); 
                ViewData["result"] = "FullNameChanged";
            }
            ProfileLoader();
            return View("Profile");
        }
        
        [HttpPost]
        public IActionResult ProfileChangePassword([Required][MinLength(6)][MaxLength(16)] string? password)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseCntx.Users.SingleOrDefault(x => x.Id == userid);

                user.Password = password;
                _databaseCntx.SaveChanges();

                ViewData["result"] = "PasswordChanged";
            }
            ProfileLoader();
            return View("Profile");
        }

        [HttpPost]
        public IActionResult ProfileChangeMail([Required]string? mail)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseCntx.Users.SingleOrDefault(x => x.Id == userid);

                user.Email = mail;
                _databaseCntx.SaveChanges();
                ViewData["result"] = "MailChanged";

            }
            ProfileLoader();
            return View("Profile");
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }
    }
}
