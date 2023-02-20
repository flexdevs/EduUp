using EduUp.Domain.Entities.Users;
using EduUp.Service.Common.Attributes;
using EduUp.Service.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Users
{
	public class UserUpdateDto
	{
		[MaxLength(60), MinLength(2)]
		public string? FullName { get; set; }

		[Email]
		public string? Email { get; set; }

		[StrongPassword]
		public string? OldPassword { get; set; }

		[StrongPassword]
		public string? NewPassword { get; set; }

		public static implicit operator User(UserUpdateDto dto)
		{
			return new User()
			{
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
