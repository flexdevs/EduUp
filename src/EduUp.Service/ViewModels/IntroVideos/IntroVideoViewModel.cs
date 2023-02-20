using EduUp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.ViewModels.IntroVideos
{
	public class IntroVideoViewModel : BaseEntity
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string VideoPath { get; set; } = string.Empty;
		public string PosterImagePath { get; set; } = string.Empty;
	}
}
