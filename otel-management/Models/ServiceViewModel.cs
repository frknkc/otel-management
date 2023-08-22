using otel_management.Entities;

namespace otel_management.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string ServicePhoto { get; set; }
        public string ServiceDetail { get; set; }
		public string? ServicePrice { get; set; }
        public bool IsAvaliable { get; set; } 


    }
}
