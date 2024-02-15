using AutoMapper;
using PortalNFE.Register.Companies.Application.Interfaces;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyAdd;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyUpdate;
using PortalNFE.Register.Companies.Domain.Interfaces.Repositories;
using PortalNFE.Register.Companies.Domain.Interfaces.Services;
using PortalNFE.Register.Companies.Domain.Models;

namespace PortalNFE.Register.Companies.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyAppService(ICompanyService companyService,
                                 ICompanyRepository companyRepository,
                                 IMapper mapper)
        {
            _companyRepository = companyRepository;
            _companyService = companyService;
            _mapper = mapper;
        }
        public async Task<bool> CompanyRootAdd(CompanyAddViewModel companyAddViewModel)
        {

            return await _companyService.CompanyAdd(_mapper.Map<Company>(companyAddViewModel));
        }

        public async Task<bool> CompanyAffiliateAdd(CompanyAffiliateAddViewModel companyAffiliateAddViewModel)
        {     
            return await _companyService.CompanyAdd(_mapper.Map<Company>(companyAffiliateAddViewModel));
        }

        public Task<bool> CompanyRemover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompanyUpdate(CompanyUpdateViewModel companyUpdateViewModel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _companyRepository.Dispose();
            _companyService.Dispose();
        }
    }
}
