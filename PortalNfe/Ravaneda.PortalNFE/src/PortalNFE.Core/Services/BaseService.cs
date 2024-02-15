using FluentValidation;
using FluentValidation.Results;
using PortalNFE.Core.DomainObjects;
using PortalNFE.Core.Interfaces;
using PortalNFE.Core.Notifications;


namespace PortalNFE.Core.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;     

        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool PerformValidations<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
