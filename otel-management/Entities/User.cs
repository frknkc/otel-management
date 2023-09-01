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
        public string? FullName { get; set; } 
        public string? Email { get; set; }
        public bool Lock { get; set; }
        public string Role { get; set; } = "user";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
