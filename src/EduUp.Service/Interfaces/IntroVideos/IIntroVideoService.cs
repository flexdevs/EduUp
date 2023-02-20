using EduUp.Service.Dtos.Courses;
using EduUp.Service.Dtos.IntroVideos;
using EduUp.Service.ViewModels.Courses;
using EduUp.Service.ViewModels.IntroVideos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.IntroVideos
{
	public interface IIntroVideoService
	{
		public Task<bool> CreateIntroVideo(CreateIntroVideoDto createIntroVideoDto);
		public Task<IntroVideoViewModel> GetAsync(long id);

	}
}
