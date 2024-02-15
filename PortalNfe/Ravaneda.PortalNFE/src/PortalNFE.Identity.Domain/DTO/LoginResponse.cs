namespace PortalNFE.Identity.Domain.DTO
{
    public class LoginResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public double ExpiresIn { get; set; }
        public UserToken UserToken { get; set; }
    }
}
