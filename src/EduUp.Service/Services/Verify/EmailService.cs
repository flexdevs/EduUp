using EduUp.DataAccess.DbContexts;
using EduUp.Service.Dtos.Verify;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Verify;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit.Text;
using MimeKit;
using Microsoft.EntityFrameworkCore;
using EduUp.Service.Security;
using MailKit.Net.Smtp;

namespace EduUp.Service.Services.Verify
{
	public class EmailService : IEmailService
	{
		private readonly AppDbContext _context;
		private readonly IConfiguration _config;

		public EmailService(IConfiguration configuration, AppDbContext appDbContext)
		{
			_context = appDbContext;
			_config = configuration.GetSection("Email");
		}

		public async Task SendAsync(EmailMessageDto emailMessage)
		{
			var email = new MimeMessage();

			email.From.Add(MailboxAddress.Parse(_config["Email"]));
			email.To.Add(MailboxAddress.Parse(emailMessage.To));
			email.Subject = emailMessage.Subject;
			email.Body = new TextPart(TextFormat.Html) { Text = emailMessage.Body.ToString() };

			var smtp = new SmtpClient();
			await smtp.ConnectAsync(_config["Host"], 587, SecureSocketOptions.StartTls);
			await smtp.AuthenticateAsync(_config["Email"], _config["Password"]);
			await smtp.SendAsync(email);
			await smtp.DisconnectAsync(true);
		}

		public async Task VerifyPasswordAsync(ResetPasswordDto password)
		{
			var admin = await _context.Users.FirstOrDefaultAsync(p => p.Email == password.Email);

			if (admin is null)
				throw new ModelErrorException(nameof(password.Email), "user not found!");

			var changedPassword = PasswordHasher.ChangePassword(password.Password, admin.Salt);

			admin.PasswordHash = changedPassword;

			_context.Users.Update(admin);

			await _context.SaveChangesAsync();
		}
	}
}
