using EduUp.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Accounts
{
    public interface IAccountService
    {
        public Task<string> AccountLoginAsync(AccountLoginDto accountLoginDto);
        public Task<bool> AccountRegisterAsync(AccountRegisterDto accountRegisterDto);
    }
}
