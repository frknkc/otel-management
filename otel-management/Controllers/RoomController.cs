using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;
using System.Security.Claims;

namespace otel_management.Controllers
{
	[Authorize]
	public class RoomController : Controller
	{
		private DatabaseCntx _databaseContext;
		private readonly IMapper _mapper;
        
        public RoomController(DatabaseCntx databaseContext, IMapper imapper)
		{
			_databaseContext = databaseContext;
			_mapper = imapper;

		}
		public IActionResult Index()
		{
			List<RoomViewModel> model = _databaseContext.Rooms
		.Select(x => new RoomViewModel
		{
			Id = x.Id,
			RoomDetail = x.RoomDetail,
			RoomNumber = x.RoomNumber,
			RoomPhoto = x.RoomPhoto,
			BedCount = x.BedCount,
			RoomPrice = x.RoomPrice,
			IsAvailable = x.IsAvailable,
			CheckOutDate = x.CheckOutDate,
			CheckInDate = x.CheckInDate,
			Lock=x.Lock,
		}).ToList();
				
			return View(model);
		}

	
        public IActionResult Odalar()
        {
            List<RoomViewModel> model = _databaseContext.Rooms
        .Select(x => new RoomViewModel
        {
            Id = x.Id,
            RoomDetail = x.RoomDetail,
            RoomNumber = x.RoomNumber,
            RoomPhoto = x.RoomPhoto,
            BedCount = x.BedCount,
            RoomPrice = x.RoomPrice,
            IsAvailable = x.IsAvailable,
			CheckOutDate = x.CheckOutDate,
			CheckInDate = x.CheckInDate,
			Lock=x.Lock,
        }).ToList();

            return View(model);
        }
		[HttpPost]
        public IActionResult Odalar(int id)
        {
			int odaId = id;	

            return View("Rezerv");
        }

        public IActionResult Reservation()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);
		
                var rezervas = (from rezerv in _databaseContext.Reservations
                                join uye in _databaseContext.Users on rezerv.UserId equals uye.Id
                                join oda in _databaseContext.Rooms on rezerv.RoomId equals oda.Id
                                join servis in _databaseContext.Services on rezerv.ServiceId equals servis.Id
                                where rezerv.UserId == userid
                                select new RezervModel
                                {
                                    Id = rezerv.Id,
                                    RoomNumber = oda.RoomNumber,
                                    BedCount = oda.BedCount,
                                    RoomPrice = oda.RoomPrice,
                                    ServiceName = servis.ServiceName,
                                    ServicePrice = servis.ServicePrice,
                                    CheckInDate = rezerv.CheckInDate,
                                    CheckOutDate = rezerv.CheckOutDate,
                                    TotalPrice = rezerv.TotalPrice
                                }).ToList();
                return View(rezervas);
           
			
        }

        public IActionResult AdminRezervation()
        {
            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);

            var rezervas = (from rezerv in _databaseContext.Reservations
                            join uye in _databaseContext.Users on rezerv.UserId equals uye.Id
                            join oda in _databaseContext.Rooms on rezerv.RoomId equals oda.Id
                            join servis in _databaseContext.Services on rezerv.ServiceId equals servis.Id
                            select new RezervModel
                            {
                                Id = rezerv.Id,
                                RoomNumber = oda.RoomNumber,
								username=uye.Username,
                                BedCount = oda.BedCount,
                                RoomPrice = oda.RoomPrice,
                                ServiceName = servis.ServiceName,
                                ServicePrice = servis.ServicePrice,
                                CheckInDate = rezerv.CheckInDate,
                                CheckOutDate = rezerv.CheckOutDate,
                                TotalPrice = rezerv.TotalPrice
                            }).ToList();
            return View(rezervas);


        }
        public IActionResult CreateRoom()
		{
			return View();
		}
		[HttpPost]
		public IActionResult CreateRoom(RoomViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (_databaseContext.Rooms.Any(x => x.RoomNumber.ToLower() == model.RoomNumber.ToLower()))
				{
					ModelState.AddModelError(nameof(model.RoomNumber), "Lütfen farklı bir oda numarası giriniz.");
					return View(model);
				}
				Room room = new Room();
				room.RoomDetail = model.RoomDetail;
				room.RoomNumber = model.RoomNumber;	
				room.IsAvailable = model.IsAvailable;
				room.RoomPhoto = model.RoomPhoto;
				room.RoomPrice = model.RoomPrice;
				room.BedCount = model.BedCount;
				room.CheckInDate = room.CheckInDate;
				room.CheckOutDate = room.CheckOutDate;

				_databaseContext.Rooms.Add(room);
				_databaseContext.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		public IActionResult EditRoom(int id)
		{
			Room rooms = _databaseContext.Rooms.Find(id);
            RoomViewModel model = _mapper.Map<RoomViewModel>(rooms);

			return View(model);
		}
		[HttpPost]
		public IActionResult EditRoom(int id, RoomViewModel model)
		{
			if (ModelState.IsValid)
			{
				if (_databaseContext.Rooms.Any(x => x.RoomNumber.ToLower() == model.RoomNumber.ToLower() && x.Id != id))
				{
					ModelState.AddModelError(nameof(model.RoomNumber), "Lütfen farklı bir oda numarası giriniz.");
					return View(model);
				}
				Room room = _databaseContext.Rooms.Find(id);

				_mapper.Map(model, room);
				_databaseContext.SaveChanges();

				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}
		public IActionResult DeleteRoom(int id)
		{
			Room rooms = _databaseContext.Rooms.Find(id);

			if (rooms != null)
			{
				if (rooms.Lock==true)
				{
					rooms.Lock = false;
                }
				else
				{
                    rooms.Lock = true;
                }
                _databaseContext.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
		}
		
		public IActionResult RezervRoom(int id)
		{
			Room rooms = _databaseContext.Rooms.Find(id);

			if (rooms != null)
			{
				if (rooms.IsAvailable==true)
				{
					rooms.IsAvailable = false;
				}
				else
				{
					rooms.IsAvailable=true;
				}
				_databaseContext.SaveChanges();
			}
			return RedirectToAction(nameof(Index));
		}
		public IActionResult DeleteReservation(int id)
		{
			Room room = _databaseContext.Rooms.FirstOrDefault(r => r.RoomNumber == id.ToString());
			room.IsAvailable = false; 
			_databaseContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Rezerv()
		{
            return View();
        }

		[HttpPost]
        public IActionResult Rezerv(int id ,CreateRezervModel model)
        {
            int odaId = id;

            int userid = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.Id == userid);
            Room rooms = _databaseContext.Rooms.Find(id);
            rooms.IsAvailable = true;
			
			//ServiceViewModel ser = (ServiceViewModel)_databaseContext.Services
			//.Select(x => new ServiceViewModel
			//{
			//	ServiceName = x.ServiceName,
			//	ServiceDetail = x.ServiceDetail,
			//	ServicePhoto = x.ServicePhoto,
			//	ServicePrice = x.ServicePrice,
			//	IsAvaliable = x.IsAvaliable,
			//	Id = x.Id,
			//});



			var rezarvasyon = new Reservation
			{
				UserId = userid,
				RoomId = odaId,
				CheckInDate = model.CheckInDate,
				CheckOutDate = model.CheckOutDate,
				TotalPrice = model.TotalPrice,
				ServiceId = 2
            };
            _databaseContext.Reservations.Add(rezarvasyon);
			_databaseContext.SaveChanges();


            return RedirectToAction(nameof(Reservation));
        }
    }
}
