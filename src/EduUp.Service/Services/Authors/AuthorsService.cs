using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Authors;
using EduUp.Domain.Entities.Users;
using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Dtos.Authors;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.Authors;
using EduUp.Service.Security;
using EduUp.Service.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Authors
{
	public class AuthorsService : IAuthorsService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;

		public AuthorsService(IUnitOfWork unitOfWork,
							  IFileService fileService)
		{
			this._unitOfWork = unitOfWork;
			this._fileService = fileService;
		}
		public async Task<bool> AuthorRegisterAsync(AuthorsRegisterDto authorsRegisterDto)
		{
			var res = await _unitOfWork.Authors.FirstOrDefaultAsync(x => x.FullName == authorsRegisterDto.Fullname);
			if (res is not null)
				throw new ModelErrorException(nameof(authorsRegisterDto.Fullname), "Author is already exist");

			Author author = (Author)authorsRegisterDto;
				
			if (authorsRegisterDto.Image is not null)
			{
			    author.ImagePath = await _fileService.SaveImageAsync(authorsRegisterDto.Image);
			}

			_unitOfWork.Authors.Add(author);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}

		public async Task<AuthorViewModel> GetAsync(long id)
		{
			var author = await _unitOfWork.Authors.FindByIdAsync(id);
			if (author is not null)
			{
				AuthorViewModel authorViewModel = new AuthorViewModel()
				{
					Id = author.Id,
					FullName = author.FullName,
					Description = author.Description,
					ImagePath = author.ImagePath,
				};

				return authorViewModel;
			}
			else throw new ModelErrorException(nameof(id), "Product not found");
		}
	}
}
