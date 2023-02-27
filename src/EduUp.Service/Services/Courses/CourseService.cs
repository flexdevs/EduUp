using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Categories;
using EduUp.Domain.Entities.Courses;
using EduUp.Service.Common.Utils;
using EduUp.Service.Dtos.Courses;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.Courses;
using EduUp.Service.ViewModels.Categories;
using EduUp.Service.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Courses
{
	public class CourseService : ICourseService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IFileService _fileService;

		public CourseService(IUnitOfWork unitOfWork,
							 IFileService fileService)
		{
			_unitOfWork = unitOfWork;
			_fileService = fileService;
		}
		public async Task<bool> CreateCourseAsync(CreateCourseDto createCourseDto)
		{
			var res = await _unitOfWork.Courses.FirstOrDefaultAsync(x => x.Name == createCourseDto.CourseName);
			if (res is not null)
				throw new ModelErrorException(nameof(createCourseDto.CourseName), "Course name is already exist");

			var author = await _unitOfWork.Authors.FirstOrDefaultAsync(x => x.Id == createCourseDto.AuthorId);
			if (author is null)
				throw new ModelErrorException(nameof(createCourseDto.AuthorId), "Author not found");

			var category = await _unitOfWork.Categories.FirstOrDefaultAsync(x => x.Id == createCourseDto.CategoryId);
			if (category is null)
				throw new ModelErrorException(nameof(createCourseDto.CategoryId), "Category not found");

			var intro = await _unitOfWork.IntroVideos.FirstOrDefaultAsync(x => x.Id == createCourseDto.IntroVideoId);
			if (intro is null)
				throw new ModelErrorException(nameof(createCourseDto.IntroVideoId), "IntroVideo not found");

			Course course = (Course)createCourseDto;
			course.AuthorId = createCourseDto.AuthorId;
			course.CategoryId = createCourseDto.AuthorId;
			course.IntroVideoId = createCourseDto.IntroVideoId;

			if (createCourseDto.Image is not null)
			{
			    course.ImagePath = await _fileService.SaveImageAsync(createCourseDto.Image);
			}

			_unitOfWork.Courses.Add(course);
			await _unitOfWork.SaveChangesAsync();

			return true;
		}

		public Task<bool> DeleteAsync(long id)
		{
			throw new NotImplementedException();
		}

		public async Task<PagedList<CourseViewModel>> GetAllAsync(PagenationParams @params)
		{
			var query = _unitOfWork.Courses.GetAll()
			.OrderByDescending(x => x.CreatedAt).Join(_unitOfWork.Authors.GetAll(),course => course.AuthorId, author=>author.Id,
			(course, author) => new CourseViewModel()
			{
				Id= course.Id,
				Description= course.Description,
				ImagePath= course.ImagePath,
				Name= course.Name,
				Price = course.Price,	
				AuthorId= author.Id,
				AuthorName = author.FullName
			}
			);

			return await PagedList<CourseViewModel>.ToPagedListAsync(query,
				@params);
		}

		public async Task<PagedList<CourseViewModel>> GetAllBySearchAsync(string search, PagenationParams @params)
		{
			var query = _unitOfWork.Courses.GetAll().Where(x => x.Name.ToLower().Contains(search.ToLower()))
         .OrderByDescending(x => x.CreatedAt).Join(_unitOfWork.Authors.GetAll(), course => course.AuthorId, author => author.Id,
            (course, author) => new CourseViewModel()
            {
                Id = course.Id,
                Description = course.Description,
                ImagePath = course.ImagePath,
                Name = course.Name,
                Price = course.Price,
                AuthorId = author.Id,
                AuthorName = author.FullName
            }
            );

            return await PagedList<CourseViewModel>.ToPagedListAsync(query,
                @params);
        }

		public async Task<CourseViewModel> GetAsync(long id)
		{
			var category = await _unitOfWork.Courses.FindByIdAsync(id);
			if (category is null) throw new ModelErrorException(nameof(id), "Course not found");

			return new CourseViewModel()
			{
				Id = category.Id,
				Name= category.Name,
				Description= category.Description,
				Price= category.Price,
				ImagePath	= category.ImagePath,
			};
		}

		public Task<bool> UpdateAsync(long Id, CourseViewModel courseView)
		{
			throw new NotImplementedException();
		}
	}
}
