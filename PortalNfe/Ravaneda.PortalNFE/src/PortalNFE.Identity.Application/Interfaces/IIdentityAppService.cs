using PortalNFE.Identity.Application.ViewModels;
using PortalNFE.Identity.Domain.DTO;
using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Application.Interfaces
{
    public interface IIdentityAppService
    {
        Task<RegisterUserViewModel> RegisterIdentityUser(RegisterUserViewModel registerUserViewModel);
        Task<LoginResponseViewModel> Login(LoginUserViewModel loginUserViewModel);
        Task<bool> ForgotPasswordAsync(string email);

        
    }
}
