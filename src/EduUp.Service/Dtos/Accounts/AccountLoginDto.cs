using EduUp.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Dtos.Accounts
{
    public class AccountLoginDto
    {
        [Required, Email]
        public string Email { get; set; } = string.Empty;
        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;

    }
}
