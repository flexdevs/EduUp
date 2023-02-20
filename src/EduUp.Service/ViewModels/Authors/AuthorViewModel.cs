using EduUp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.ViewModels.Authors
{
	public class AuthorViewModel : BaseEntity
	{
		public string FullName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;

		public string ImagePath { get; set; } = string.Empty;
	}
}
