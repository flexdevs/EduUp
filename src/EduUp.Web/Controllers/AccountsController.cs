using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Exceptions;
using EduUp.Service.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Controllers;
[Route("accounts")]

public class AccountsController : Controller
{
	private readonly IAccountService _accountService;

	public AccountsController(IAccountService accountService)
	{
		this._accountService = accountService;
	}

	[HttpGet("login")]
	public ViewResult Login()
	{
		return View("Login");
	}

	[HttpPost("login")]
	public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
	{
		if (ModelState.IsValid)
		{
			try
			{
				string token = await _accountService.AccountLoginAsync(accountLoginDto);
				HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
				{
					HttpOnly = true,
					SameSite = SameSiteMode.Strict
				});
				return RedirectToAction("Index", "Products", new { area = "" });
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
	public ViewResult Register()
	{
		return View("Register");
	}

	[HttpPost("register")]
	public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
	{
		if (ModelState.IsValid)
		{
			bool result = await _accountService.AccountRegisterAsync(accountRegisterDto);
			if (result)
			{
				return RedirectToAction("login", "accounts", new { area = "" });
			}
			else
			{
				return Register();
			}
		}
		else return Register();
	}
}


