using System.ComponentModel.DataAnnotations;

namespace otel_management.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı maximum 30 karakter olabilir.")]
        public string? KullanıcıAd { get; set; }

       
        public string? KullanıcıSifre { get; set; }



        [Required(ErrorMessage = "Şifre girmek zorunludur.")]
        [MaxLength(6, ErrorMessage = "Şifre maximum 30 karakter olabilir")]
        [MinLength(16, ErrorMessage = "Şifre minimum 6 karakter olabilir")]
        [Compare(nameof(KullanıcıSifreTekrar))]
        public string? KullanıcıSifreTekrar { get; set; }
    }
}
