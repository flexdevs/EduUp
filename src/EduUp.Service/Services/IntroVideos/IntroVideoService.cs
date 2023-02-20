using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Courses;
using EduUp.Domain.Entities.IntroVideos;
using EduUp.Service.Dtos.Courses;
using EduUp.Service.Dtos.IntroVideos;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.IntroVideos;
using EduUp.Service.ViewModels.Courses;
using EduUp.Service.ViewModels.IntroVideos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.IntroVideos
{
	public class IntroVideoService : IIntroVideoService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;

		public IntroVideoService(IUnitOfWork unitOfWork, IFileService fileService)
		{
			this._unitOfWork = unitOfWork;
			this._fileService = fileService;
		}
		public async Task<bool> CreateIntroVideo(CreateIntroVideoDto createIntroVideoDto)
		{
			var res = await _unitOfWork.IntroVideos.FirstOrDefaultAsync(x => x.Title == createIntroVideoDto.Title);
			if (res is not null)
				throw new ModelErrorException(nameof(createIntroVideoDto.Title), "Intro Video name is already exist");

			IntroVideo introVideo = (IntroVideo)createIntroVideoDto;

			if (createIntroVideoDto.VideoPath is not null)
			{
				introVideo.VideoPath = await _fileService.SaveVideoAsync(createIntroVideoDto.VideoPath);
			}

			if (createIntroVideoDto.PosterImagePath is not null)
			{
				introVideo.PosterImagePath = await _fileService.SaveImageAsync(createIntroVideoDto.PosterImagePath);
			}

			_unitOfWork.IntroVideos.Add(introVideo);
			var result = await _unitOfWork.SaveChangesAsync();
			return result > 0;
		}

		public async Task<IntroVideoViewModel> GetAsync(long id)
		{
			var introVideo = await _unitOfWork.IntroVideos.FindByIdAsync(id);
			if (introVideo is null) throw new ModelErrorException(nameof(id), "Intro Video not found");

			return new IntroVideoViewModel()
			{
				Id= introVideo.Id,
				Title = introVideo.Title,
				Description= introVideo.Description,
				PosterImagePath= introVideo.PosterImagePath,
				VideoPath= introVideo.VideoPath,
			};
		}
	}
}
