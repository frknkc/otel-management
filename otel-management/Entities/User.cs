using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace otel_management.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(30)]
        public string? KullanıcıAdı { get; set; }

        [Required]
        [StringLength(100)]
        public string? KullanıcıSifre { get; set; }
       
        
        [StringLength(50)]
        public string? AdSoyad { get; set; } = null;

        [StringLength(50)]
        public string? KullanıcıMail { get; set; } = null;

        public bool isAdmin { get; set; } = false;

        public DateTime CreateAt { get; set; }=DateTime.Now;
    }
    
}
