using EduUp.Domain.Entities.Courses;
using EduUp.Service.Common.Attributes;
using EduUp.Service.Common.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Courses
{
	public class CreateCourseDto
	{
		[Required, MaxLength(50), MinLength(2)]
		public string CourseName { get; set; } = string.Empty;
		[Required]
		public string Description { get; set; } = string.Empty;

		[Required, MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
		public IFormFile? Image { get; set; }

		[Required, Integer]
		public double Price { get; set; }
		[Required, Integer]
		public long AuthorId { get; set; }
		[Required]
		public long CategoryId { get; set; }
		[Required]
		public long IntroVideoId { get; set; }

		public static implicit operator Course(CreateCourseDto dto)
		{
			return new Course()
			{
				Name = dto.CourseName,
				Description = dto.Description,
				Price= dto.Price,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
