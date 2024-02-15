using System.ComponentModel.DataAnnotations;

namespace PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanySelect
{
    public class CompanyAffiliateSelectViewModel
    {
        [Key]
        public Guid CompanyAffiliateId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string FantasyName { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string DocumentRoot { get; set; } = string.Empty;
        public string StateRegistration { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
