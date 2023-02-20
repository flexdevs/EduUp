using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Dtos.Verify;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Accounts;
using EduUp.Service.Interfaces.Verify;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Controllers;
[Route("accounts")]

public class AccountsController : Controller
{
    private readonly IAccountService _service;
	private readonly IEmailService _emailService;
	private readonly IVerifyEmailService _verifyEmail;

	public AccountsController(IAccountService accountService,
                              IEmailService emailService,
                              IVerifyEmailService verifyEmail)
    {
        this._service = accountService;
        this._emailService = emailService;
        this._verifyEmail = verifyEmail;

	}

    [HttpGet("login")]
    public ViewResult Login() => View("Login");

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
				SendCodeToEmailDto sendCodeToEmailDto = new SendCodeToEmailDto()
				{
					Email = accountLoginDto.Email
				};
				bool res = await _verifyEmail.SendCodeAsync(sendCodeToEmailDto);
				if (res)
				{
					TempData["email"] = accountLoginDto.Email;
					return RedirectToAction("verify-email", "accounts", new { area = "" });
				}
				else
				{
					return Login();
				}
			}
            catch (ModelErrorException modelError)
            {
                ModelState.AddModelError(modelError.Property, modelError.Message);
                return Login();
            }
            catch
            {
                return Login();
            }
        }
        else return Login();
    }


    [HttpGet("register")]
    public ViewResult Register() => View("Register");

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
    {
        if (ModelState.IsValid)
        {
			try
			{
				bool result = await _service.AccountRegisterAsync(accountRegisterDto);
				if (result)
				{
					SendCodeToEmailDto sendCodeToEmailDto = new SendCodeToEmailDto()
					{
						Email = accountRegisterDto.Email
					};
					bool res = await _verifyEmail.SendCodeAsync(sendCodeToEmailDto);
					if (res)
					{
						TempData["email"] = accountRegisterDto.Email;
						return RedirectToAction("verify-email", "accounts", new { area = "" });
					}
					else
					{
						return Register();
					}

				}
				else
				{
					return Register();
				}
			}
			catch (ModelErrorException modelError)
			{
				ModelState.AddModelError(modelError.Property, modelError.Message);
				return Register();
			}
		}
		else return Register();
	}

	[HttpGet("verify-email")]
	public ViewResult VerifyEmail()
	{
		return View("VerifyEmail");
	}

	[HttpPost("verify-email")]
	public async Task<IActionResult> VerifyEmailAsync(VerifyEmailDto emailVerifyDto)
	{

		if (ModelState.IsValid)
		{
            try
            {
				string token = await _verifyEmail.VerifyEmailAsync(emailVerifyDto);
				HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
				{
					HttpOnly = true,
					SameSite = SameSiteMode.Strict
				});
				return RedirectToAction("Index", "Home", new { area = "" });
            }
			catch (ModelErrorException modelError)
			{
				ModelState.AddModelError(modelError.Property, modelError.Message);
				TempData["email"] = emailVerifyDto.Email;
				return VerifyEmail();
			}
			catch
			{
				TempData["email"] = emailVerifyDto.Email;
				return VerifyEmail();
			}
		}
		TempData["email"] = emailVerifyDto.Email;
		return VerifyEmail();

	}
}
