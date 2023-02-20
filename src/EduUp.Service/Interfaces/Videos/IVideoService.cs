using EduUp.Service.Dtos.IntroVideos;
using EduUp.Service.Dtos.Videos;
using EduUp.Service.ViewModels.IntroVideos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Videos
{
	public interface IVideoService
	{
		public Task<bool> CreateVideo(CreateVideoDto createVideoDto);
	}
}
