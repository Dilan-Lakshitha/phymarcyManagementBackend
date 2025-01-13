/*using phymarcyManagement.Application.Interfaces;
using phymarcyManagement.Application.Services;
using phymarcyManagement.Infrastructure.Data;
using phymarcyManagement.Infrastructure.Services;
using IAuthenticationService = phymarcyManagement.Application.Interfaces.IAuthenticationService;

namespace phymarcyManagement.CrossCutting.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<DapperContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<UserService>();
        }
    }
}
*/