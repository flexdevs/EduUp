using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.CourseVideos;
using EduUp.Domain.Entities.IntroVideos;
using EduUp.Service.Dtos.IntroVideos;
using EduUp.Service.Dtos.Videos;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.Videos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Videos
{
	public class VideoService : IVideoService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;

		public VideoService(IUnitOfWork unitOfWork, IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_fileService = fileService;
		}
		public async Task<bool> CreateVideo(CreateVideoDto createVideoDto)
		{
			var res = await _unitOfWork.IntroVideos.FirstOrDefaultAsync(x => x.Title == createVideoDto.Title);
			if (res is not null)
				throw new ModelErrorException(nameof(createVideoDto.Title), "Intro Video name is already exist");
			CourseVideo courseVideo = (CourseVideo)createVideoDto;

			if (createVideoDto.VideoPath is not null)
			{
				courseVideo.VideoPath = await _fileService.SaveVideoAsync(createVideoDto.VideoPath);
			}

			if (createVideoDto.PosterImagePath is not null)
			{
				courseVideo.PosterImagePath = await _fileService.SaveImageAsync(createVideoDto.PosterImagePath);
			}

			_unitOfWork.CourseVideos.Add(courseVideo);
			var result = await _unitOfWork.SaveChangesAsync();
			return result > 0;
		}
	}
}
