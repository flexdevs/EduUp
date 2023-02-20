using EduUp.Domain.Entities.CourseVideos;
using EduUp.Service.Common.Attributes;
using EduUp.Service.Common.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Videos
{
	public class CreateVideoDto
	{
		[Required, MaxLength(50), MinLength(2)]
		public string Title { get; set; } = string.Empty;
		[Required]
		public string Description { get; set; } = string.Empty;
		public IFormFile? VideoPath { get; set; }

		[Required, MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
		public IFormFile? PosterImagePath { get; set; }

		public static implicit operator CourseVideo(CreateVideoDto createVideoDto)
		{
			return new CourseVideo()
			{
				Title = createVideoDto.Title,
				Description = createVideoDto.Description,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
