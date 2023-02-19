using EduUp.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Dtos.Verify
{
    public class SendCodeToEmailDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;
    }
}
