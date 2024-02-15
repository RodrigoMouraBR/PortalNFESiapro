using PortalNFE.Register.Company.Domain.Interfaces;
using System.ComponentModel.Design;

namespace PortalNFE.Register.Company.Domain.Models
{
    public class Company : Entity, IAgregateRoot
    {
        public Company(string companyName,
                       string fantasyName,
                       string document,
                       string phone,
                       string email)
        {
            CompanyName = companyName;
            FantasyName = fantasyName;
            Document = document;
            Phone = phone;
            Email = email;
        }
        protected Company() { }       
        public string CompanyName { get; private set; } = string.Empty;
        public string FantasyName { get; private set; } = string.Empty;
        public string Document { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public CompanyAddress CompanyAddress { get; private set; }


    }
}
