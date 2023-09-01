using otel_management.Entities;

namespace otel_management.Models
{
	public class RoomViewModel
	{
		public int Id { get; set; }
		public string? RoomNumber { get; set; }
		public string? RoomPhoto { get; set; } = "default_img.png";
		public string? RoomDetail { get; set; }
		public int BedCount { get; set; } = 0;
		public string? RoomPrice { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }
        public bool Lock { get; set; }
    }

	public class ReservationViewModel
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int RoomId { get; set; }
		public string CheckInDate { get; set; }
		public string CheckOutDate { get; set; }
		public string TotalPrice { get; set; }

		public virtual User User { get; set; }
		public virtual Room Room { get; set; }
		public virtual Service Service { get; set; }
	}
}
