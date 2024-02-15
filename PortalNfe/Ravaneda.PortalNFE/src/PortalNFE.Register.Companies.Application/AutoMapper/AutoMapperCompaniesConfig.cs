using AutoMapper;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyAdd;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanySelect;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyUpdate;
using PortalNFE.Register.Companies.Domain.Models;

namespace PortalNFE.Register.Companies.Application.AutoMapper
{
    public class AutoMapperCompaniesConfig : Profile
    {
        public AutoMapperCompaniesConfig()
        {
            CreateMap<Company, CompanyAddViewModel>().ReverseMap();
            CreateMap<Company, CompanyUpdateViewModel>().ReverseMap();
            CreateMap<Company, CompanySelectViewModel>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressAddViewModel>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressUpdateViewModel>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressSelectViewModel>().ReverseMap();

            CreateMap<CompanyAffiliateAddViewModel, Company>().ReverseMap();
            CreateMap<CompanyAddress, CompanyAddressAffiliateAddViewModel>().ReverseMap();
        }
    }
}
