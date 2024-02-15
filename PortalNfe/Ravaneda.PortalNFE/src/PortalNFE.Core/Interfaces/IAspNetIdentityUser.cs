using System.Security.Claims;

namespace PortalNFE.Core.Interfaces
{
    public interface IAspNetIdentityUser
    {
        string Tenanty { get; }
        string Name { get; }
        Guid GetUserId();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
