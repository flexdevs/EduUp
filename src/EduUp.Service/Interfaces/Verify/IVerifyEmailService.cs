using EduUp.Service.Dtos.Verify;

namespace EduUp.Service.Interfaces.Verify
{
    public interface IVerifyEmailService
    {
        Task<bool> SendCodeAsync(SendCodeToEmailDto sendCodeToEmailDto);

        Task<string> VerifyEmailAsync(VerifyEmailDto verifyEmailDto);

        Task<bool> VerifyPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
