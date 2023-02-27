using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Categories;
using EduUp.Service.Common.Utils;
using EduUp.Service.Dtos.Categories;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Categories;
using EduUp.Service.ViewModels.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<bool> CreateCategoryAsync(CategoryCreateDto categoryDto)
		{
			var res = await _unitOfWork.Categories.FirstOrDefaultAsync(x => x.CategoryName == categoryDto.CategoryName);
			if (res is not null)
				throw new ModelErrorException(nameof(categoryDto.CategoryName),"Category name is already exist");

			Category category = (Category)categoryDto;

			_unitOfWork.Categories.Add(category);
			await _unitOfWork.SaveChangesAsync();

			return true;
		}

		public Task<bool> DeleteAsync(long id)
		{
			throw new NotImplementedException();
		}

		public async Task<PagedList<Category>> GetAllAsync(PagenationParams @params)
		{
			var query = _unitOfWork.Categories.GetAll()
			.OrderBy(x => x.CreatedAt);

			return await PagedList<Category>.ToPagedListAsync(query,
				@params);
		}

		public async Task<PagedList<Category>> GetAllBySearchAsync(string search, PagenationParams @params)
		{
			var query = _unitOfWork.Categories.GetAll().Where(x => x.CategoryName.ToLower().Contains(search.ToLower()))
		  .OrderBy(x => x.CreatedAt);

			return await PagedList<Category>.ToPagedListAsync(query,
				@params);
		}

		public async Task<CategoryViewModel> GetAsync(long id)
		{
			var category = await _unitOfWork.Categories.FindByIdAsync(id);
			if (category is null) throw new ModelErrorException(nameof(id), "Category not found");

			return new CategoryViewModel()
			{
				Id = category.Id,
				CategoryName = category.CategoryName,
			};
		}

		public Task<bool> UpdateAsync(long Id, CategoryViewModel categoryView)
		{
			throw new NotImplementedException();
		}
	}
}
