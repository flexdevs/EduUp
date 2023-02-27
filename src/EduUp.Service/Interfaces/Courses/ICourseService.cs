using EduUp.Domain.Entities.Categories;
using EduUp.Domain.Entities.Courses;
using EduUp.Service.Common.Utils;
using EduUp.Service.Dtos.Courses;
using EduUp.Service.ViewModels.Categories;
using EduUp.Service.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Courses
{
	public interface ICourseService
	{
		public Task<bool> CreateCourseAsync(CreateCourseDto createCourseDto);

		public Task<PagedList<CourseViewModel>> GetAllAsync(PagenationParams @params);
		public Task<PagedList<CourseViewModel>> GetAllBySearchAsync(string search, PagenationParams @params);
		public Task<CourseViewModel> GetAsync(long id);

		public Task<bool> DeleteAsync(long id);

		public Task<bool> UpdateAsync(long Id, CourseViewModel courseView);
	}
}
