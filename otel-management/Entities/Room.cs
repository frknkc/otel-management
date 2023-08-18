namespace otel_management.Entities
{
    public class Room
    {
        public  Guid Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomPhoto { get; set; }
        public string RoomDetail { get; set; }
        public int BedCount { get; set; }
        public bool IsAvailable { get; set; } = false;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
