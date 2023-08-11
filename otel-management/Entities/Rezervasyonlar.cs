using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace otel_management.Entities
{
    public class Rezervasyonlar
    {
        [Key]
        public int RezId { get; set; }

        public int KullanıcıID { get; set; }

        public int OdaID { get; set; }

        [StringLength(50)]
        public string? GirisTarihi { get; set; }

        [StringLength(50)]
        public string? CıkısTarihi { get; set; }

        [StringLength(20)]
        public string? ToplamFiyat { get; set; }

    }
}
