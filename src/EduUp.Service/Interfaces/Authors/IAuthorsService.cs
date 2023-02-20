using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Dtos.Authors;
using EduUp.Service.ViewModels.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Authors
{
	public interface IAuthorsService
	{
		public Task<bool> AuthorRegisterAsync(AuthorsRegisterDto authorsRegisterDto);

		public Task<AuthorViewModel> GetAsync(long id);
	}
}
