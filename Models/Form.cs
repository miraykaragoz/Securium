using System.ComponentModel.DataAnnotations;

namespace PasswordGenerator.Models
{
    public class Form
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçersiz e-posta adresi.")]
        public string Email { get; set; } 
    }
}