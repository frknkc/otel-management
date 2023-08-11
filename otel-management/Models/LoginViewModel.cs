using System.ComponentModel.DataAnnotations;

namespace otel_management.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı maximum 30 kareketer olabilir.")]
        public string? KullanıcıAd { get; set; }

        [Required(ErrorMessage = "Şifre girmek zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre maximum 30 kareketer olabilir")]
        [MaxLength(16, ErrorMessage = "Şifre minimum 6 kareketer olabilir")]
        public string? KullanıcıSifre { get; set; }
    }
}
