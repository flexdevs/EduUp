using EduUp.Domain.Entities.Users;
using EduUp.Service.Common.Attributes;
using EduUp.Service.Common.Helpers;
using System.ComponentModel.DataAnnotations;

namespace EduUp.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MaxLength(60), MinLength(2)]
        public string FullName { get; set; } = string.Empty;

        [Required, Email]
        public string Email { get; set; } = string.Empty;

        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;

        public static implicit operator User(AccountRegisterDto dto)
        {
            return new User()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                UserRole = false,
                CreatedAt = TimeHelper.GetCurrentServerTime()
            };
        }
    }
}
