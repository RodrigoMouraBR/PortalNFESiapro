using FluentValidation;
using PortalNFE.Core.Validations.Documents;
using PortalNFE.Register.Companies.Domain.Models;

namespace PortalNFE.Register.Companies.Domain.Validations
{
    public class CompanyValidation : AbstractValidator<Company>
    {
        public CompanyValidation()
        {
            RuleFor(f => f.CompanyName)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.FantasyName)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.Email != "" || f.Email != string.Empty, () =>
            {
                RuleFor(s => s.Email).EmailAddress().WithMessage("É necessário um e - mail válido");
            });

            When(f => f.StateRegistration != "Isento" || f.StateRegistration != string.Empty, () =>
            {
                RuleFor(f => f.StateRegistration)
                 .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                 .Length(2, 14)
                 .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            });

            RuleFor(f => f.Document)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(14, 14)
              .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(f => f.Document.Length).Equal(CnpjValidation.TamanhoCnpj)
            .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
            RuleFor(f => CnpjValidation.Validar(f.Document)).Equal(true)
                .WithMessage("O documento fornecido é inválido.");


            When(f => f.DocumentRoot != string.Empty || f.DocumentRoot != "", () =>
            {
                RuleFor(f => f.DocumentRoot)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(14, 14)
               .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

                RuleFor(f => f.DocumentRoot.Length).Equal(CnpjValidation.TamanhoCnpj)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidation.Validar(f.DocumentRoot)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });

        }
    }
}
