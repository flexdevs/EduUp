using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.Users;
using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.Accounts;
using EduUp.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Accounts
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;
        private IAuthManager _authManager;
        private IFileService _fileService;

        public AccountService(IUnitOfWork unitOfWork,
                            IAuthManager authManager,
                            IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _authManager = authManager;
            _fileService = fileService;
        }
        public async Task<string> AccountLoginAsync(AccountLoginDto accountLoginDto)
        {
            var res = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Email == accountLoginDto.Email);
            if (res == null) { throw new ModelErrorException(nameof(accountLoginDto.Email), "User not found, Email is incorrect!"); }

            if (PasswordHasher.Verify(accountLoginDto.Password, res.Salt, res.PasswordHash))
                return _authManager.GenerateToken(res);

            throw new ModelErrorException(nameof(accountLoginDto.Password), message: "Password is wrong");
        }

        public async Task<bool> AccountRegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            var res = await _unitOfWork.Users.FirstOrDefaultAsync(x => x.Email == accountRegisterDto.Email);
            if (res is not null)
                throw new ModelErrorException(nameof(accountRegisterDto.Email), "Email is already exist");

            User user = (User)accountRegisterDto;

            //if (accountRegisterDto.Image is not null)
            //{
            //    user.ImagePath = await _fileService.SaveImageAsync(accountRegisterDto.Image);
            //}

            var hashResult = PasswordHasher.Hash(accountRegisterDto.Password);

            user.Salt = hashResult.Salt;

            user.PasswordHash = hashResult.Hash;

            _unitOfWork.Users.Add(user);
            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
