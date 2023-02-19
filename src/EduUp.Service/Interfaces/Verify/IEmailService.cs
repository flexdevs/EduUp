using EduUp.Service.Dtos.Verify;

namespace EduUp.Service.Interfaces.Verify
{
    public interface IEmailService
    {
        public Task SendAsync(EmailMessageDto emailMessageDto);

        Task VerifyPasswordAsync(ResetPasswordDto password);
    }
}
