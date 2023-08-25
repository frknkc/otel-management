using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;

namespace otel_management.Controllers
{
    [Authorize]
    public class ReservationController : Controller
    {
        private DatabaseCntx _databaseContext;
        private readonly IMapper _mapper;

        public ReservationController(DatabaseCntx databaseContext, IMapper imapper)
        {
            _databaseContext = databaseContext;
            _mapper = imapper;

        }
        public IActionResult Index()
        {
            List<ReservationViewModel> model = _databaseContext.Reservations
        .Select(x => new ReservationViewModel
        {
            Id = x.Id,
            RoomId = x.RoomId,  
            CheckInDate = x.CheckInDate,
            CheckOutDate = x.CheckOutDate,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId,
            
        }).ToList();

            return View(model);
        }

        public IActionResult CreateReservation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateReservation(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Reservations.Any(x => x.Id == model.Id))
                {
                    ModelState.AddModelError(nameof(model.Id), "Lütfen farklı rezervasyon numarası giriniz.");
                    return View(model);
                }
                Reservation rez = new Reservation();    
                rez.Id = model.Id;
                rez.RoomId = model.RoomId;
                rez.UserId = model.UserId;
                rez.CheckInDate = model.CheckInDate;
                rez.CheckOutDate = model.CheckOutDate;
                rez.TotalPrice = model.TotalPrice;

                _databaseContext.Reservations.Add(rez);
                _databaseContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public IActionResult Rezervation(int id)
        {
            return View();
        }
    }
}
