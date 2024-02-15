using Microsoft.Extensions.DependencyInjection;
using PortalNFE.Register.Companies.Application.Interfaces;
using PortalNFE.Register.Companies.Application.Services;
using PortalNFE.Register.Companies.Data.Context;
using PortalNFE.Register.Companies.Data.Repositories;
using PortalNFE.Register.Companies.Domain.Interfaces.Repositories;
using PortalNFE.Register.Companies.Domain.Interfaces.Services;
using PortalNFE.Register.Companies.Domain.Services;

namespace PortalNFE.Register.Companies.Application.IoC
{
    public static class NativeInjectorCompaniesBootStrapper
    {
        public static void RegisterCompaniesIoCServices(this IServiceCollection services)
        {
            //Application
            services.AddScoped<ICompanyAppService, CompanyAppService>();

            //Domain Service
            services.AddScoped<ICompanyService, CompanyService>();

            //Domain Repositorio
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            //Context
            services.AddScoped<PortalNFECompaniesContext>();






        }
    }
}
