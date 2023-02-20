using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Service.Interfaces.Accounts;
using EduUp.Service.Services.Accounts;

namespace EduUp.Web.Configurations;

public static class ServiceConfiguration
{
    public static void AddService(this IServiceCollection services)
    {
        //services.AddHttpContextAccessor();
		services.AddScoped<IUnitOfWork, UnitOfWork>();

		services.AddScoped<IAccountService, AccountService>();

	}
}
