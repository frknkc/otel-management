using System.ComponentModel.DataAnnotations;

namespace otel_management.Entities
{
    public class Room
    {
        public  int Id { get; set; }
        [Required]
        public string? RoomNumber { get; set; }
        public string? RoomPhoto { get; set; }
        public string? RoomDetail { get; set; }
		public string? RoomPrice { get; set; }
		public int BedCount { get; set; } = 0;
        public bool IsAvailable { get; set; } = true;
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}