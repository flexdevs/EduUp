using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Users
{
	public interface IUserService
	{
		public Task<bool> UserUpdateAsync(UserUpdateDto userUpdateDto);
	}
}
