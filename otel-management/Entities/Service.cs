namespace otel_management.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServicePhoto { get; set; }
        public string ServiceDetail { get; set; }
        public string ServicePrice { get; set; }
        public bool IsAvaliable { get; set; }=true;
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
