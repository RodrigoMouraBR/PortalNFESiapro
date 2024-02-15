using FluentValidation;
using PortalNFE.Core.Validations.Documents;
using PortalNFE.Personas.Domain.Models.Companies;

namespace PortalNFE.Personas.Domain.Validations.Companies
{
    public class CompanyAffiliateValidation : AbstractValidator<Company>
    {
        public CompanyAffiliateValidation()
        {
            RuleFor(f => f.DocumentRoot)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(14, 14)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            When(f => f.DocumentRoot != "Isento" || f.DocumentRoot != string.Empty, () =>
            {
                RuleFor(f => f.DocumentRoot.Length).Equal(CnpjValidation.TamanhoCnpj)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
                RuleFor(f => CnpjValidation.Validar(f.DocumentRoot)).Equal(true)
                    .WithMessage("O documento fornecido é inválido.");
            });
        }
    }
}
