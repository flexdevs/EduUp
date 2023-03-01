using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Service.Dtos.Verify;
using EduUp.Service.Interfaces.Verify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.Service.Services.Verify
{
    public class SendMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;

        public SendMessageService(IUnitOfWork unitOfWork, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }
        public async Task<bool> SendAllUsersMessageAsync(EmailMessageDto message)
        {
            var delayTime = TimeSpan.FromMilliseconds(10);
            var counter = 0;

            foreach (var user in _unitOfWork.Users.GetAll())
            {
                message.To = user.Email;

                await _emailService.SendAsync(message);

                counter++;
                if (counter == 100)
                {
                    counter = 0;
                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
                else
                {
                    await Task.Delay(delayTime);
                }
            }

            return true;
        }
    }
}
