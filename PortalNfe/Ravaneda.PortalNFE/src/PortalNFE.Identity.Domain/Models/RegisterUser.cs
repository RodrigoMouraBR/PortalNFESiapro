namespace PortalNFE.Identity.Domain.Models
{
    public class RegisterUser
    {      
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public Guid UserPersonId { get; set; }
    }
}
