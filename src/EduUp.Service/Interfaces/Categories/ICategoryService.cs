using EduUp.Domain.Entities.Categories;
using EduUp.Service.Common.Utils;
using EduUp.Service.Dtos.Categories;
using EduUp.Service.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Categories
{
	public interface ICategoryService
	{
		public Task<bool> CreateCategoryAsync(CategoryCreateDto categoryDto);

		public Task<PagedList<Category>> GetAllAsync(PagenationParams @params);
		public Task<PagedList<Category>> GetAllBySearchAsync(string search, PagenationParams @params);

		public Task<CategoryViewModel> GetAsync(long id);

		public Task<bool> DeleteAsync(long id);

		public Task<bool> UpdateAsync(long Id, CategoryViewModel categoryView);
	}
}
