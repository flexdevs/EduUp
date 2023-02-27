using EduUp.Domain.Common;
using EduUp.Domain.Entities.Authors;
using EduUp.Domain.Entities.Categories;
using EduUp.Domain.Entities.IntroVideos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.ViewModels.Courses
{
	public class CourseViewModel : BaseEntity
	{
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string ImagePath { get; set; } = string.Empty;
		public double Price { get; set; }
		public long AuthorId { get; set; }
		public string AuthorName { get; set; } = string.Empty;
	}
}
