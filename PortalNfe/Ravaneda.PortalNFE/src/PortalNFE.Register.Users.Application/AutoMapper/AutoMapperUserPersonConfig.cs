using AutoMapper;
using PortalNFE.Register.Users.Application.ViewMoldes;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonAdd;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonUpdate;
using PortalNFE.Register.Users.Domain.Models;

namespace PortalNFE.Register.Users.Application.AutoMapper
{
    public class AutoMapperUserPersonConfig : Profile
    {
        public AutoMapperUserPersonConfig()
        {
            CreateMap<UserPerson, UserPersonAddViewModel>().ReverseMap();
            CreateMap<UserPersonCompany, UserPersonCompanyAddViewModel>().ReverseMap();
            CreateMap<UserPerson, UserPersonUpdateViewModel>().ReverseMap();
        }
    }
}
