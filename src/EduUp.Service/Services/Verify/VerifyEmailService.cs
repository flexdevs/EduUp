using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Common;
using EduUp.Service.Dtos.Verify;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces;
using EduUp.Service.Interfaces.Verify;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace EduUp.Service.Services.Verify
{
	public class VerifyEmailService : IVerifyEmailService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMemoryCache _cache;
		private readonly IEmailService _emailService;
		private readonly AppDbContext _context;
		private readonly IAuthManager _authManager;

		public VerifyEmailService(IUnitOfWork unitOfWork,
								  IMemoryCache cache,
								  IEmailService email,
								  AppDbContext appDbContext,
								  IAuthManager authManager)
		{
			_unitOfWork = unitOfWork;
			_cache = cache;
			_emailService = email;
			_context = appDbContext;
			_authManager = authManager;
		}
		public async Task<bool> SendCodeAsync(SendCodeToEmailDto sendCodeToEmailDto)
		{
			int code = new Random().Next(1000, 9999);

			_cache.Set(sendCodeToEmailDto.Email, code, TimeSpan.FromMinutes(3));

			var message = new EmailMessageDto()
			{
				To = sendCodeToEmailDto.Email,
				Subject = "Verification code",
				Body = code.ToString(),
			};

			await _emailService.SendAsync(message);

			return true;
		}

		public async Task<string> VerifyEmailAsync(VerifyEmailDto verifyEmailDto)
		{
			if (_cache.TryGetValue(verifyEmailDto.Email, out int exceptedCode))
			{
				if (exceptedCode != verifyEmailDto.Code)
					throw new ModelErrorException(nameof(verifyEmailDto.Code), message: "Code is wrong!");

				else
				{
					var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == verifyEmailDto.Email);
					if (user is null) { throw new ModelErrorException(nameof(verifyEmailDto.Email), "User not found"); }
					user.EmailVerify = true;
					_unitOfWork.Users.Update(user.Id, user);
					var result = await _unitOfWork.SaveChangesAsync();
					if (result > 0)
					{
						return _authManager.GenerateToken(user);
					}
					else { throw new ModelErrorException(nameof(verifyEmailDto.Code), message: "Code is wrong!"); }

				}
			}
			else
				throw new ModelErrorException(nameof(verifyEmailDto.Code), message: "Code is expired");
		}

		public async Task<bool> VerifyPasswordAsync(ResetPasswordDto resetPasswordDto)
		{
			var user = await _context.Users.FirstOrDefaultAsync(p => p.Email == resetPasswordDto.Email);

			if (user is null)
				throw new ModelErrorException(nameof(resetPasswordDto.Email), message: "user not found");

			if (_cache.TryGetValue(resetPasswordDto.Email, out int code))
			{
				if (code != resetPasswordDto.Code)
					throw new ModelErrorException(nameof(resetPasswordDto.Code), message: "Code is wrong");
			}
			else
				throw new ModelErrorException(nameof(resetPasswordDto.Code), message: "Code is expired");

			return true;
		}
	}
}
