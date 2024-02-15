using AutoMapper;
using PortalNFE.Identity.Application.Interfaces;
using PortalNFE.Identity.Application.ViewModels;
using PortalNFE.Identity.Domain.Interfaces;
using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Application.Services
{
    public class IdentityAppService : IIdentityAppService
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;
        public IdentityAppService(IMapper mapper, IIdentityService identityService)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<RegisterUserViewModel> RegisterIdentityUser(RegisterUserViewModel registerUserViewModel)
        {
            var result = await _identityService.RegisterIdentityUser(_mapper.Map<RegisterUser>(registerUserViewModel));

            var map = _mapper.Map<RegisterUserViewModel>(result);

            return map;
        }

        public async Task<LoginResponseViewModel> Login(LoginUserViewModel loginUserViewModel)
        {
            var result = await _identityService.Login(_mapper.Map<LoginUser>(loginUserViewModel));

            var map = _mapper.Map<LoginResponseViewModel>(result);

            return map;
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            return await _identityService.ForgotPasswordAsync(email);
        }        
    }
}
