using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Core.Communication.Mediator;
using PortalNFE.Core.Communication.Mediator;
using PortalNFE.Core.Interfaces;
using PortalNFE.Core.Messages.CommonMessages.Notifications;
using PortalNFE.Core.Notifications;
using PortalNFE.Core.SendEMail;

namespace PortalNFE.Core.IoC
{
    public static class NativeInjectorBootStrapperCore
    {
        public static void CoreIoCServices(IServiceCollection services)
        {
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            

        }
    }
}
