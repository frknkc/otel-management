using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace otel_management.Entities
{
    public class Hizmetler
    {
        [Key]
        public int HizmetId { get; set; }

        [StringLength(50)]
        public string? HizmetAdı { get; set; }

        [StringLength(100)]
        public string? HizmetFoto { get; set; }

        [StringLength(500)]
        public string? HizmetDetay { get; set; }
        
    }
   
}
