using EduUp.Domain.Entities.IntroVideos;
using EduUp.Service.Common.Attributes;
using EduUp.Service.Common.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.IntroVideos
{
	public class CreateIntroVideoDto
	{
		[Required, MaxLength(50), MinLength(2)]
		public string Title { get; set; } = string.Empty;
		[Required]
		public string Description { get; set; } = string.Empty;
		[Required, AllowedFiles(new string[] { ".webm", ".mkv", ".vob", ".avi", ".mp4" })]
		public IFormFile? VideoPath { get; set; }

		[Required, MaxFileSize(2), AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
		public IFormFile? PosterImagePath { get; set; }

		public static implicit operator IntroVideo(CreateIntroVideoDto dto)
		{
			return new IntroVideo()
			{
				Title = dto.Title,
				Description = dto.Description,
				CreatedAt = TimeHelper.GetCurrentServerTime()
			};
		}
	}
}
