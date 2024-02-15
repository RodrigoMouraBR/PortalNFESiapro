using AutoMapper;
using MediatR;
using PortalNFE.Core.Messages.CommonMessages.IntegrationEvents.UserPerson;
using PortalNFE.Identity.Application.ViewModels;
using PortalNFE.Identity.Domain.Interfaces;
using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Application.Event
{
    public class IdentityHandlerEvent : INotificationHandler<CreateIdentityUserPersonEvent>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public IdentityHandlerEvent(IMapper mapper, IIdentityService identityService)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        // Criar usuário sistema
        public async Task Handle(CreateIdentityUserPersonEvent notification, CancellationToken cancellationToken)
        {
            var registerUserViewModel = new RegisterUserViewModel()
            {
                Email = notification.Email,
                Password = notification.Password,
                ConfirmPassword = notification.ConfirmPassword,
                UserPersonId = notification.UserPersonId
            };

            await _identityService.RegisterIdentityUser(_mapper.Map<RegisterUser>(registerUserViewModel));
        }
    }
}
