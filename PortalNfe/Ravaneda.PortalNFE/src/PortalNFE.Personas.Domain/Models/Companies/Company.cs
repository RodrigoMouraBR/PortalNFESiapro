using FluentValidation.Results;
using PortalNFE.Core.DomainObjects;
using PortalNFE.Core.Extensions;
using PortalNFE.Personas.Domain.Enums.Companies;
using PortalNFE.Personas.Domain.Interfaces;
using PortalNFE.Personas.Domain.Validations.Companies;

namespace PortalNFE.Personas.Domain.Models.Companies
{
    public class Company : Entity, IAgregateRoot
    {
        private object value;

        public Company(string companyName,
                       string fantasyName,
                       string document,
                       string documentRoot,
                       string stateRegistration,
                       string phone,
                       string email
                       )
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            Document = document;
            DocumentRoot = documentRoot;
            StateRegistration = stateRegistration;
            Phone = phone;
            Email = email;

            CompanyAffiliate = new List<CompanyAffiliate>();
        }
        protected Company() 
        {
            
        }      

        public string CompanyName { get; private set; } = string.Empty;
        public string FantasyName { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;       
        public string DocumentRoot { get; private set; } = string.Empty;
        public string StateRegistration { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public ECompanyType CompanyType { get; private set; }
        public ECompanyStatus CompanyStatus { get; private set; }
        public CompanyAddress CompanyAddress { get; private set; }
        public List<CompanyAffiliate> CompanyAffiliate { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public void SetCompanyTypeRoot()
        {
            CompanyType = ECompanyType.Root;
        }
        public void SetCompanyTypeAffiliate()
        {
            CompanyType = ECompanyType.Affiliate;
        }
        public void CompanyInactive()
        {
            CompanyStatus = ECompanyStatus.Inactive;
        }
        public void CompanyActive()
        {
            CompanyStatus = ECompanyStatus.Active;
        }
        public void RemovingCnpjMask()
        {
            var document = RegexMaskText.RemoveMask(Document);
            var documentRoot = RegexMaskText.RemoveMask(DocumentRoot);
            Document = document;
            DocumentRoot = documentRoot;
        }
        public void RelateAddress()
        {
            CompanyAddress.RelateAddressCompany(Id);
        }

        public bool CompanyIsValid()
        {
            ValidationResult = new CompanyValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool CompanyAffiliateIsValid()
        {
            ValidationResult = new CompanyAffiliateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public void SetCompanyDocumentAffiliate(string document)
        {
            DocumentRoot = document;
        }
    }
}
