
namespace otel_management.Entities
{
    public class Reservation
    {
        public Guid Id { get; set; }
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
