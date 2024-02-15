using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PortalNFE.Register.Users.Application.Interfaces;
using PortalNFE.Register.Users.Application.Services;
using PortalNFE.Register.Users.Data.Context;
using PortalNFE.Register.Users.Data.Repositories;
using PortalNFE.Register.Users.Domain.Intefaces.Repository;
using PortalNFE.Register.Users.Domain.Intefaces.Service;
using PortalNFE.Register.Users.Domain.Services;

namespace PortalNFE.Register.Users.Application.IoC
{
    public static class NativeInjectorUserPersonBootStrapper
    {
        public static void RegisterUserPersonIoCServices(this IServiceCollection services)
        {
            //Application
            services.AddScoped<IUserPersonAppService, UserPersonAppService>();
            //Domain Service
            services.AddScoped<IUserPersonService, UserPersonService>();    
            //Domain Repository
            services.AddScoped<IUserPersonRepository, UserPersonRepository>();
            //Data
            services.AddScoped<PortalNFEUserPersonContext>();

            
        }
    }
}
