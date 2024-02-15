using System.ComponentModel.DataAnnotations;

namespace PortalNFE.Identity.Application.ViewModels
{
    public class RegisterUserViewModel
    {
        [EmailAddress(ErrorMessage = "O campo {0} não é um endereço de e-mail válido.")]
        public string Email { get; set; }     

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "O campo Confirmação de Senha é obrigatório.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
        public string ConfirmPassword { get; set; }
        public Guid UserPersonId { get; set; }
    }
}
