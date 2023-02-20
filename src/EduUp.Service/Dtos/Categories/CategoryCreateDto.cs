using EduUp.Domain.Entities.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Dtos.Categories
{
	public class CategoryCreateDto
	{
		[Required, MaxLength(50), MinLength(2)]
		public string CategoryName { get; set; } = string.Empty;

		public static implicit operator Category(CategoryCreateDto category)
		{
			return new Category()
			{
				CategoryName = category.CategoryName,

			};
		}
	}
}
