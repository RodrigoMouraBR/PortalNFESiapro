using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNFE.Api.Controllers;
using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Companies.Application.Interfaces;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyAdd;
using PortalNFE.Register.Companies.Application.ViewModels.Companies.Requests.CompanyUpdate;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonAdd;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonUpdate;

namespace PortalNFE.Api.V1.Controllers
{
    
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/company")]
    public class CompanyController : MainController
    {
        private readonly ICompanyAppService _companyAppService;
        public CompanyController(ICompanyAppService companyAppService, INotifier notificador) : base(notificador)
        {
            _companyAppService = companyAppService;
        }

        #region Root

        /// <summary>
        ///  - Cria uma nova empresa matriz.
        /// </summary>
        /// <param name="CompanyViewModel">Dados do novo empresa.</param>
        /// <returns>a empresa criada.</returns>

        [HttpPost("CompanyRootAdd")]
        public async Task<ActionResult<CompanyAddViewModel>> CompanyRootAdd(CompanyAddViewModel CompanyViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _companyAppService.CompanyRootAdd(CompanyViewModel);

            return CustomResponse(CompanyViewModel);
        }
        #endregion

        #region Affiliate
        /// <summary>
        ///  - Cria uma nova empresa filial.
        /// </summary>
        /// <param name="companyAffiliateAddViewModel">Dados do novo empresa.</param>
        /// <returns>a empresa criada.</returns>
        
        [HttpPost("CompanyAffiliateAdd")]
        public async Task<ActionResult<CompanyAddViewModel>> CompanyAffiliateAdd(CompanyAffiliateAddViewModel companyAffiliateAddViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _companyAppService.CompanyAffiliateAdd(companyAffiliateAddViewModel);

            return CustomResponse(companyAffiliateAddViewModel);
        }

        #endregion

        /// <summary>
        ///  - Atualiza os detalhes de uma empresa existente.
        /// </summary>
        /// <param name="companyUpdateViewModel">Dados atualizados da empresa.</param>        
        /// <returns>A empresa atualizado.</returns>

        [HttpPut("CompanyUpdate")]
        public async Task<ActionResult<CompanyUpdateViewModel>> CompanyUpdate(CompanyUpdateViewModel companyUpdateViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse(companyUpdateViewModel);
        }

        /// <summary>
        ///  - Inativa uma empresa.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <returns>Resposta indicando sucesso ou falha.</returns>

        [HttpDelete("CompanyRemover")]
        public async Task<ActionResult<bool>> CompanyRemover(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            return CustomResponse("OK");
        }


    }
}
