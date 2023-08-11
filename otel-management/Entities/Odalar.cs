using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace otel_management.Entities
{
    public class Odalar
    {
        [Key]
        public int OdaId { get; set; }

        [StringLength(10)]
        public string? OdaNumarası { get; set; }

        [StringLength(100)]
        public string? OdaFoto { get; set; }

        [StringLength(500)]
        public string? OdatDetay { get; set; }
        public int YatakSayısı { get; set; }

        public bool KullanılabilirMi { get; set; } = false;

    }
}
