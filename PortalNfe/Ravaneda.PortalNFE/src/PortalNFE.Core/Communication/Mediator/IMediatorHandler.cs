using PortalNFE.Core.Messages;
using PortalNFE.Core.Messages.CommonMessages.DomainEvents;
using PortalNFE.Core.Messages.CommonMessages.Notifications;

namespace PortalNFE.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}