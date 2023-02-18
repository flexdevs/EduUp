using EduUp.Service.Dtos.Verify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Interfaces.Verify
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessageDto emailMessageDto);

        Task VerifyPasswordAsync(ResetPasswordDto password);
    }
}
