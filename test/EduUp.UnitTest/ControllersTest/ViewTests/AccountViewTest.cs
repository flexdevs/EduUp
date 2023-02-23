using EduUp.Service.Dtos.Accounts;
using EduUp.Service.Dtos.Verify;
using EduUp.Service.Interfaces.Accounts;
using EduUp.Service.Interfaces.Verify;
using EduUp.Web.Controllers;
using Moq;
using Xunit;

namespace EduUp.UnitTest.ControllersTest.ViewTests
{
    public class AccountViewTest
    {
        private readonly IAccountService _accountService;
        private readonly IEmailService _emailService;
        private readonly IVerifyEmailService _verifyService;
        private readonly AccountsController _controller;

        public AccountViewTest()
        {
            this._accountService = new Mock<IAccountService>().Object;
            this._emailService = new Mock<IEmailService>().Object;
            this._verifyService = new Mock<IVerifyEmailService>().Object;
            this._controller = new AccountsController(_accountService, _emailService, _verifyService);
        }

        [Fact]
        public void ReturnLoginView()
        {
            var response = _controller.Login();
        }

        [Fact]
        public void ReturnLoginAsyncView()
        {
            var login = new AccountLoginDto
            {
                Email = "hggfg@gmail.com",
                Password = "12345678"
            };

            var resault = _controller.LoginAsync(login);
            Assert.NotNull(resault);
        }


        [Fact]
        public void ReturnRegisterView()
        {
            var response = _controller.Register();
        }

        [Fact]
        public void ReturnRegisterAsync()
        {
            var resgister = new AccountRegisterDto
            {
                FullName = "ahmad",
                Email = "hgvhv@gmil.com",
                Password = "aliyev"
            };

            var resault = _controller.RegisterAsync(resgister);
            Assert.NotNull(resault);
        }


        [Fact]
        public void ReturnVerifyEmail()
        {
            var response = _controller.VerifyEmail();
        }

        [Fact]
        public void ReturnVerifyEmailAsync()
        {
            var email = new VerifyEmailDto
            {
                Email = "asdbshj@gmail.com",
                Code = 12345,
            };

            var resault = _controller.VerifyEmailAsync(email);

            Assert.NotNull(resault);
        }





    }
}
