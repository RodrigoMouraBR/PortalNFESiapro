using Microsoft.AspNetCore.Identity;

namespace PortalNFE.Identity.Domain.Extensions
{
    public class AppUser : IdentityUser<Guid>
    {
        public AppUser()
        {
            UserPersonId = Guid.NewGuid().ToString();
        }
        public string UserPersonId { get; set; }
    }
}
