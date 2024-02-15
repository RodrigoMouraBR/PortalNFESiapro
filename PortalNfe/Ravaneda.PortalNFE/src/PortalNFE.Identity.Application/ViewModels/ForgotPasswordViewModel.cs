using System.ComponentModel.DataAnnotations;

namespace PortalNFE.Identity.Application.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "O campo {0} não é um endereço de e-mail válido.")]
        public string Email { get; set; }
    }
}
