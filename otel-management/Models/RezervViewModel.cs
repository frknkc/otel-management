using otel_management.Entities;

namespace otel_management.Models
{
    public class RezervModel
    {
        public int Id { get; set; }
        public string? RoomNumber { get; set; }
        public int BedCount { get; set; }
        public string? RoomPrice { get; set; }
        public string ServiceName { get; set; }
        public string ServicePrice { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string TotalPrice { get; set; }

    }
    public class CreateRezervModel
    {
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public string TotalPrice { get; set; }
        public int ServiceId { get; set; }

    }
}
