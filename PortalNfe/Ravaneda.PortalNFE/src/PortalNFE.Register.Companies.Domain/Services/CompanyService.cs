using PortalNFE.Core.Interfaces;
using PortalNFE.Core.Services;
using PortalNFE.Register.Companies.Domain.Enums;
using PortalNFE.Register.Companies.Domain.Interfaces.Repositories;
using PortalNFE.Register.Companies.Domain.Interfaces.Services;
using PortalNFE.Register.Companies.Domain.Models;
using PortalNFE.Register.Companies.Domain.Validations;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PortalNFE.Register.Companies.Domain.Services
{
    public class CompanyService : BaseService, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository, INotifier notifier) : base(notifier)
        {
            _companyRepository = companyRepository;
        }
        public async Task<bool> CompanyRemover(Guid id)
        {
            var company = await _companyRepository.CompanyById(id);

            if (company == null) return false;

            company.CompanyInactive();

            _companyRepository.CompanyUpdate(company);

            return await _companyRepository.UnitOfWork.Commit();
        }
        public async Task<bool> CompanyUpdate(Company company)
        {
            var companyResponse = await _companyRepository.CompanyById(company.Id);

            if (companyResponse == null) return false;

            companyResponse.CompanyInactive();

            _companyRepository.CompanyUpdate(companyResponse);

            return await _companyRepository.UnitOfWork.Commit();
        }
        public async Task<bool> CompanyAdd(Company company)
        {
            company.CompanyActive();
            company.RemovingCnpjMask();

            if (!PerformValidations(new CompanyValidation(), company))
            {
                Notify("Existem incosistencias no cadastro");
                return false;
            }

            if (company.DocumentRoot != string.Empty)
            {
                if (_companyRepository.SearchCompany(f => f.Document == company.DocumentRoot && f.CompanyType == ECompanyType.Root).Result.Any())
                {
                    var companyRoot = _companyRepository
                        .SearchCompany(f => f.Document == company.DocumentRoot && f.CompanyType == ECompanyType.Root)
                        .Result.FirstOrDefault();

                    var companyAffiliate = new CompanyAffiliate(company.Id, companyRoot.Id, ECompanyStatus.Active);
                    company.CompanyAffiliate.Add(companyAffiliate);
                    company.SetCompanyTypeAffiliate();
                }
            }
            else
            {
                company.SetCompanyTypeRoot();
            }

            #region Company Address
            if (company.CompanyAddress != null)
            {
                company.RelateAddress();

                if (!PerformValidations(new CompanyAddressValidation(), company.CompanyAddress))
                {
                    Notify("Existem incosistencias para realizar o cadastro");
                    return false;
                }
            }
            #endregion

            var result = await _companyRepository.CompanyAdd(company);
            if (result == 1)
                return true;

            return false;
        }

        public void Dispose()
        {
            _companyRepository.Dispose();
        }
    }
}
