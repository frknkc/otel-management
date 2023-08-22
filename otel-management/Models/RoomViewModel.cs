namespace otel_management.Models
{
	public class RoomViewModel
	{
		public int Id { get; set; }
		public string? RoomNumber { get; set; }
		public string? RoomPhoto { get; set; } = "/images/default_img.png";
		public string? RoomDetail { get; set; }
		public int BedCount { get; set; } = 0;
		public string? RoomPrice { get; set; }

		public bool IsAvailable { get; set; } = true;
	}
}
