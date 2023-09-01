using System.ComponentModel.DataAnnotations;

namespace otel_management.Models
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı maximum 30 karakter olabilir.")]
        public string? KullanıcıAd { get; set; }
        public string? AdSoyad { get; set; }
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")] 
        public string? Email { get; set; }
        public string? KullanıcıSifre { get; set; }

        [Required(ErrorMessage = "Şifre girmek zorunludur.")]
        [MaxLength(16, ErrorMessage = "Şifre maximum 16 karakter olabilir")]
        [MinLength(6, ErrorMessage = "Şifre minimum 6 karakter olabilir")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=!]).{8,}$",
    ErrorMessage = "Şifre en az 8 karakter uzunluğunda olmalı ve büyük harf, küçük harf, rakam, özel karakter içermelidir.")]
        [Compare(nameof(KullanıcıSifre))] 
        public string? KullanıcıSifreTekrar { get; set; }
    }
}
