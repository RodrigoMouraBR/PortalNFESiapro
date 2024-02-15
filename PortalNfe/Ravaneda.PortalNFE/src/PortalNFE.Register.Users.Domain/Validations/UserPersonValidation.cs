using FluentValidation;
using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Domain.Validations
{
    public class UserPersonValidation : AbstractValidator<UserPerson>
    {
        public UserPersonValidation()
        {
            RuleFor(f => f.Name)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 50)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(s => s.Email).EmailAddress().WithMessage("É necessário um e - mail válido");

            RuleFor(f => f.CellPhone)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(11, 11)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


            RuleFor(f => f.Password)
           .NotEmpty().WithMessage("O campo Senha é obrigatório.")
           .MinimumLength(6).WithMessage("A senha deve ter pelo menos 6 caracteres.");

            RuleFor(f => f.ConfirmPassword)
                .NotEmpty().WithMessage("O campo Confirmação de Senha é obrigatório.")
                .Equal(usuario => usuario.Password).WithMessage("A senha e a confirmação de senha não coincidem.");
        }
    }
}
