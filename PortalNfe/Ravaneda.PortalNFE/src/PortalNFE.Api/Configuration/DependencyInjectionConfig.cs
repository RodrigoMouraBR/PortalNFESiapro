using Microsoft.Extensions.Options;
using PortalNFE.Api.Extensions;
using PortalNFE.Core.Interfaces;
using PortalNFE.Core.IoC;
using PortalNFE.Identity.Application.IoC;
using PortalNFE.Register.Companies.Application.IoC;
using PortalNFE.Register.Users.Application.IoC;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PortalNFE.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            NativeInjectorCompaniesBootStrapper.RegisterCompaniesIoCServices(services);
            NativeInjectorUserPersonBootStrapper.RegisterUserPersonIoCServices(services);
            NativeInjectorBootStrapperCore.CoreIoCServices(services);
            NativeInjectorIdentityBootStrapper.RegisterIdentityIoCServices(services);

            #region Implementação para obter o User nas camadas
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetIdentityUser, AspNetIdentityUser>();
            #endregion

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            return services;
        }
    }
}