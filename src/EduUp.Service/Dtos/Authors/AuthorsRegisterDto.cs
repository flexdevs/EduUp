using EduUp.Domain.Entities.Authors;
using EduUp.Service.Common.Attributes;
using EduUp.Service.Common.Helpers;
using Microsoft.AspNetCore.Http;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Authors
{
	public class AuthorsRegisterDto
	{
		[Required, MaxLength(60), MinLength(2)]
		public string Fullname { get; set; } = string.Empty;

		[Required]
		public string Description { get; set; } = string.Empty;

		[Required, MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
		public IFormFile? Image { get; set; }

		public static implicit operator Author(AuthorsRegisterDto dto)
		{
			return new Author()
			{
				FullName = dto.Fullname,
				Description = dto.Description,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
