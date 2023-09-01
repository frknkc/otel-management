using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Models;
using otel_management.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace otel_management.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private DatabaseCntx _databaseContext;
        private readonly IMapper _mapper;
        public UserController(DatabaseCntx databaseContext,IMapper imapper) {
            _databaseContext = databaseContext;
            _mapper = imapper;
        }
        public IActionResult Index()
        {
            List<UserViewModel> model = _databaseContext.Users
        .Select(x => new UserViewModel
        {
            Id = x.Id,
            FullName = x.FullName,
            Username = x.Username,
            Email = x.Email,
            Role = x.Role,
            CreatedAt = x.CreatedAt,
            Lock=x.Lock,
        }).ToList();

            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Lütfen farklı bir kullanıcı adı giriniz.");
                    return View(model);

                }
                User user = new User();
                user.Username = model.Username;
                user.Email = model.Email;
                user.Role = model.Role;
                user.FullName = model.FullName;
                user.Password = model.Password;
                user.Lock=model.Lock;
                _databaseContext.Users.Add(user);
               _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            User user = _databaseContext.Users.Find(id);
            
            EditUserModel model = _mapper.Map<EditUserModel>(user);

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id,EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Kullanıcı adı daha önceden alınmış.");
                    return View(model);
                }

                User user = _databaseContext.Users.Find(id);

                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public IActionResult Delete(int id)
        {
            User user = _databaseContext.Users.Find(id);

            if (user!=null)
            {
                if (user.Lock==true)
                {
                    user.Lock = false;

                }
                else
                {
                    user.Lock = true;
                }
                _databaseContext.SaveChanges(); 
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
