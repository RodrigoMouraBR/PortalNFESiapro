using PortalNFE.Identity.Domain.DTO;
using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Domain.Interfaces
{
    public interface IIdentityService
    {
        Task<RegisterUser> RegisterIdentityUser(RegisterUser registerUser);
        Task<LoginResponse> Login(LoginUser loginUser);
        Task<bool> ForgotPasswordAsync(string email);
        Task InvalidateTokenAsync(string userId);
    }
}
