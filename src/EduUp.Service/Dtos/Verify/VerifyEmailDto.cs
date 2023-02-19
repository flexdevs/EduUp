using EduUp.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Dtos.Verify
{
    public class VerifyEmailDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Code { get; set; }
    }
}
