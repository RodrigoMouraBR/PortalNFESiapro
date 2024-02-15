using PortalNFE.Core.Communication.Mediator;
using PortalNFE.Core.Interfaces;
using PortalNFE.Core.Messages.CommonMessages.IntegrationEvents.UserPerson;
using PortalNFE.Core.Services;
using PortalNFE.Register.Users.Domain.Intefaces.Repository;
using PortalNFE.Register.Users.Domain.Intefaces.Service;
using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Domain.Services
{
    public class UserPersonService : BaseService, IUserPersonService
    {
        private readonly IUserPersonRepository _userPersonRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAspNetIdentityUser _AspNetIdentityUser;
        bool commit;

        public UserPersonService(IUserPersonRepository userPersonRepository,
                                 IMediatorHandler mediatorHandler,
                                 IAspNetIdentityUser AspNetIdentityUser,
                                 INotifier notifier) : base(notifier)
        {
            _userPersonRepository = userPersonRepository;
            _mediatorHandler = mediatorHandler;
            _AspNetIdentityUser = AspNetIdentityUser;
        }

        public async Task<bool> UserPersonAdd(UserPerson userPerson)
        {
            if (_userPersonRepository.SearchPerson(f => f.Email == userPerson.Email).Result.Any())
            {
                Notify("Já existe um usuário cadastrado com este documento.");
                return (false);
            }

            await _userPersonRepository.UserPersonAdd(userPerson);

            commit = await _userPersonRepository.UnitOfWork.Commit();

            if (commit)
                await _mediatorHandler.PublishEvent(new CreateIdentityUserPersonEvent(userPerson.Email, userPerson.Password, userPerson.ConfirmPassword, userPerson.Id));

            return commit;
        }
        public async Task<bool> UserPersonRemover(Guid id)
        {
            var result = await _userPersonRepository.UserPersonRemover(id);
            if (result == 1) return true;

            return false;
        }
        public async Task<bool> UserPersonUpdate(UserPerson userPerson)
        {
            var result = await _userPersonRepository.UserPersonUpdate(userPerson);
            if (result == 1)
                return true;

            return false;
        }
        public void Dispose()
        {
            _userPersonRepository.Dispose();
        }
    }
}
