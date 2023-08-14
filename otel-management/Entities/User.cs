using System.ComponentModel.DataAnnotations;

namespace otel_management.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; } = null;
        public string Email { get; set; } = null;
        public bool IsAdmin { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
