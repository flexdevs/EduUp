using EduUp.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Dtos.Verify
{
    public class ResetPasswordDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;

        [Required]
        public uint Code { get; set; }

        [Required(ErrorMessage = "Password is required"), MinLength(8), MaxLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
