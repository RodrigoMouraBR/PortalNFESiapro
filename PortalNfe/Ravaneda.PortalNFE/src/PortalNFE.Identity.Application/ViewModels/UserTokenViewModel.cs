namespace PortalNFE.Identity.Application.ViewModels
{
    public class UserTokenViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<ClaimsViewModel> Claims { get; set; }
    }
}
