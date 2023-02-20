using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Users;
using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Dtos.Users;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Common;
using EduUp.Service.Interfaces.Users;
using EduUp.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Users
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IIdentityService _identityService;

		public UserService(IUnitOfWork unitOfWork, IIdentityService identityService)
		{
			this._unitOfWork = unitOfWork;
			this._identityService = identityService;
		}
		public async Task<bool> UserUpdateAsync(UserUpdateDto userUpdateDto)
		{
			var res = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Id == _identityService.Id!.Value);
			if (res is null)
				throw new ModelErrorException(nameof(userUpdateDto), "User not found");

			User user = (User)userUpdateDto;

			if(userUpdateDto.FullName is not null)
			{
				user.FullName = userUpdateDto.FullName;
			} else { user.FullName = res.FullName; }

			if(userUpdateDto.Email is not null)
			{
				user.Email = userUpdateDto.Email;
			} else { user.Email = res.Email; }

			if(userUpdateDto.NewPassword is not null)
			{
				if(userUpdateDto.OldPassword is not null)
				{
					if(PasswordHasher.Verify(userUpdateDto.NewPassword, res.Salt, res.PasswordHash))
					{
						var hashResult = PasswordHasher.Hash(userUpdateDto.NewPassword);

						res.Salt = hashResult.Salt;

						res.PasswordHash = hashResult.Hash;
					}
				}
			}

			_unitOfWork.Users.Add(user);
			var result = await _unitOfWork.SaveChangesAsync();

			return result > 0;
		}
	}
}
