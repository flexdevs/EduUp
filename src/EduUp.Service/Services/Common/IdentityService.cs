using EduUp.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Common
{

    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _accessor;
        public IdentityService(IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
        }
        public long? Id
        {
            get
            {
                var res = _accessor.HttpContext!.User.FindFirst("Id");
                return res is not null ? long.Parse(res.Value) : null;
            }
        }

        public string FullName 
             {
        get
        {
            var result = _accessor.HttpContext!.User.FindFirst("FullName");
            return (result is null) ? String.Empty : result.Value;
        }
}

        public string Email
        {
            get
            {
                var result = _accessor.HttpContext!.User.FindFirst("Email");
                return (result is null) ? String.Empty : result.Value;
            }

        }

        public bool Role
        {
            get
            {
                var result = _accessor.HttpContext!.User.FindFirst("Role");
                return (result is null) ? false : (result.Value == "true")? true : false;
            }
        }
    }
}
