using AutoMapper;
using PortalNFE.Identity.Application.ViewModels;
using PortalNFE.Identity.Domain.DTO;
using PortalNFE.Identity.Domain.Models;

namespace PortalNFE.Identity.Application.AutoMapper
{
    public class AutomapperIdentityConfig : Profile
    {
        public AutomapperIdentityConfig()
        {

            CreateMap<LoginUser, LoginUserViewModel>().ReverseMap();
            CreateMap<LoginResponse, LoginResponseViewModel>().ReverseMap();
            CreateMap<UserToken, UserTokenViewModel>().ReverseMap();
            CreateMap<Claims, ClaimsViewModel>().ReverseMap();
            CreateMap<RegisterUser, RegisterUserViewModel>().ReverseMap();
        }  
    }
}
