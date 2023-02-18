using EduUp.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
