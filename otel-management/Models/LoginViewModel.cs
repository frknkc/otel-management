using System.ComponentModel.DataAnnotations;

namespace otel_management.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı maximum 30 karakter olabilir.")]
        public string? KullanıcıAd { get; set; }

        [Required(ErrorMessage = "Şifre girmek zorunludur.")]
        [MaxLength(16, ErrorMessage = "Şifre maximum 16 karakter olabilir")]
        [MinLength(6, ErrorMessage = "Şifre minimum 6 karakter olabilir")]
        public string? KullanıcıSifre { get; set; }
    }
}
