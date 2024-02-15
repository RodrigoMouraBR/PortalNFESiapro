using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PortalNFE.Core.Messages.CommonMessages.IntegrationEvents.UserPerson;
using PortalNFE.Identity.Application.Event;
using PortalNFE.Identity.Application.Interfaces;
using PortalNFE.Identity.Application.Services;
using PortalNFE.Identity.Domain.Interfaces;
using PortalNFE.Identity.Domain.Services;

namespace PortalNFE.Identity.Application.IoC
{
    public static class NativeInjectorIdentityBootStrapper
    {
        public static void RegisterIdentityIoCServices(IServiceCollection services)
        {
            services.AddScoped<IIdentityAppService, IdentityAppService>();
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<INotificationHandler<CreateIdentityUserPersonEvent>, IdentityHandlerEvent>();


        }
    }
}
