using System.ComponentModel.DataAnnotations;

namespace PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyAdd
{
    public class CompanyAffiliateAddViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome da empresa")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo Nome fantasia")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string FantasyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(20, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(1, ErrorMessage = "Mínimo {0} caracteres")]
        public string Document { get; set; } = string.Empty;
        public string DocumentRoot { get; set; } = string.Empty; //Preeencher cadastro Filial
        public string StateRegistration { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "O endereço de email é inválido")]
        public string Email { get; set; } = string.Empty;       
        public CompanyAddressAffiliateAddViewModel CompanyAddress { get; set; }
    }
}
