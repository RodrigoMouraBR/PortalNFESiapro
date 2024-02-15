namespace PortalNFE.Identity.Domain.DTO
{
    public class UserToken
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<Claims> Claims { get; set; }
    }
}
