namespace otel_management.Entities
{
    public class Service
    {
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServicePhoto { get; set; }
        public string ServiceDetail { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
