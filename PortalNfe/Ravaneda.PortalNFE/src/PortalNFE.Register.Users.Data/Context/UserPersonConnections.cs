using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PortalNFE.Register.Users.Data.Context
{
    public static class UserPersonConnections
    {
        public static IServiceCollection AddUserPersonConnectionUseNpgsql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<PortalNFEUserPersonContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            return services;
        }
    }
}
