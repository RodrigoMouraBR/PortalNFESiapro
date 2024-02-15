using PortalNFE.Register.Users.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonAdd
{
    public class UserPersonAddViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Nome da empresa")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "O endereço de email é inválido")]
        public string Email { get; set; }

        [RegularExpression(@"^\(\d{2}\)\s*\d{5}-\d{4}$", ErrorMessage = "O número de celular não é válido.")]
        public string CellPhone { get; set; }    

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmação de Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
        public string ConfirmPassword { get; set; }

        public IList<UserPersonCompanyAddViewModel> UserPersonCompanies { get; set; }



    }
}
