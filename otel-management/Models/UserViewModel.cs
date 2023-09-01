using System.ComponentModel.DataAnnotations;

namespace otel_management.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FullName { get; set; }

		[Required(ErrorMessage = "E-posta adresi gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
		public string? Email { get; set; }
        public string Role { get; set; } = "user";
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool  Lock { get; set; }
    }

    public class CreateUserModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı maximum 30 karakter olabilir.")]
        public string Username { get; set; }
        public string? FullName { get; set; }
		[Required(ErrorMessage = "E-posta adresi gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
		public string? Email { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "user";

        [Required(ErrorMessage = "Şifre girmek zorunludur.")]
        [MaxLength(16, ErrorMessage = "Şifre maximum 16 karakter olabilir")]
        [MinLength(6, ErrorMessage = "Şifre minimum 6 karakter olabilir")]
        [Compare(nameof(Password))]
        public string? KullanıcıSifreTekrar { get; set; }
        public bool Lock { get; set; }

    }

    public class EditUserModel  {

        [Required(ErrorMessage = "Kullanıcı adı girmek zorunludur.")]
        [StringLength(30, ErrorMessage = "Kullanıcı adı maximum 30 karakter olabilir.")]
        public string Username { get; set; }
        public string? FullName { get; set; }
		[Required(ErrorMessage = "E-posta adresi gereklidir.")]
		[EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
		public string? Email { get; set; }
        public string Role { get; set; } = "user";
        public bool Lock { get; set; }

    }
}
