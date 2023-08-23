using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using otel_management.Data;
using otel_management.Entities;
using otel_management.Models;

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
        }).ToList();

            return View(model);
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
				_databaseContext.Rooms.Remove(rooms);
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
	}
}
