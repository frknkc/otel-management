using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;

namespace otel_management.Controllers
{
    public class ServiceController : Controller
    {
        private DatabaseCntx _databaseContext;
        private readonly IMapper _mapper;

        public ServiceController(DatabaseCntx databaseContext, IMapper imapper)
        {
            _databaseContext = databaseContext;
            _mapper = imapper;

        }
        public IActionResult Index()
        {
            List<ServiceViewModel> model = _databaseContext.Services
        .Select(x => new ServiceViewModel
        {
            ServiceName=x.ServiceName,
            ServiceDetail=x.ServiceDetail,  
            ServicePhoto=x.ServicePhoto,
            ServicePrice=x.ServicePrice,
            Id=x.Id,
        }).ToList();

            return View(model);
        }

        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Services.Any(x => x.ServiceName.ToLower() == model.ServiceName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.ServiceName), "Lütfen farklı bir hizmet adı giriniz.");
                    return View(model);
                }
                Service service = new Service();
                service.ServiceName = model.ServiceName;
                service.ServiceDetail = model.ServiceDetail;
                service.ServicePhoto = model.ServicePhoto;
                service.ServicePrice= model.ServicePrice; 
                service.Id=model.Id;

               
                _databaseContext.Services.Add(service);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult EditService(int id)
        {
            Service service = _databaseContext.Services.Find(id);
            ServiceViewModel model = _mapper.Map<ServiceViewModel>(service);

            return View(model);
        }
        [HttpPost]
        public IActionResult EditService(int id, ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Services.Any(x => x.ServiceName.ToLower() == model.ServiceName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.ServiceName), "Lütfen farklı bir hizmet adı giriniz.");
                    return View(model);
                }
                Service service = _databaseContext.Services.Find(id);

                _mapper.Map(model, service);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult DeleteService(int id)
        {
            Service service = _databaseContext.Services.Find(id);

            if (service != null)
            {
                _databaseContext.Services.Remove(service);
                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RezervService(int id)
        {
            Service service = _databaseContext.Services.Find(id);

            if (service != null)
            {
                if (service.IsAvaliable == true)
                {
                    service.IsAvaliable = false;
                }
                else
                {
                    service.IsAvaliable = true;
                }
                _databaseContext.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
