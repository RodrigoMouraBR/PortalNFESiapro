using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNFE.Api.Controllers;
using PortalNFE.Core.Interfaces;
using PortalNFE.Identity.Application.Constants;
using PortalNFE.Identity.Application.Extensions;
using PortalNFE.Register.Users.Application.Interfaces;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonAdd;
using PortalNFE.Register.Users.Application.ViewMoldes.Requests.UserPersonUpdate;

namespace PortalNFE.Api.V1.Controllers
{
    //[Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/userperson")]
    public class UserPersonController : MainController
    {
        private readonly IUserPersonAppService _userPersonAppService;     
        public UserPersonController(IUserPersonAppService userPersonAppService, INotifier notificador) : base(notificador)
        {
            _userPersonAppService = userPersonAppService;
        }

        /// <summary>
        ///  - Cria um novo usuário.
        /// </summary>
        /// <param name="userPersonAddViewModel">Dados do novo usuário.</param>
        /// <returns>O usuário criado.</returns>

        //[Authorize(Roles = Roles.Admin)]       
        //[ClaimsAuthorizeAttribute(ClaimTypes.UserPerson, "UserPersonAdd")]
        [HttpPost("UserPersonAdd")]
        public async Task<ActionResult<UserPersonAddViewModel>> UserPersonAdd(UserPersonAddViewModel userPersonAddViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _userPersonAppService.UserPersonAdd(userPersonAddViewModel);

            return CustomResponse(userPersonAddViewModel);
        }

        /// <summary>
        ///  - Atualiza os detalhes de um usuário existente.
        /// </summary>
        /// <param name="userPersonUpdateViewModel">ID do usuário a ser atualizado.</param>        
        /// <returns>O usuário atualizado.</returns>

        [Authorize(Roles = Roles.Admin)]
        //[ClaimsAuthorizeAttribute(ClaimTypes.UserPerson, "UserPersonUpdate")]
        [HttpPut("UserPersonUpdate")]
        public async Task<ActionResult<UserPersonUpdateViewModel>> UserPersonUpdate(UserPersonUpdateViewModel userPersonUpdateViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _userPersonAppService.UserPersonUpdate(userPersonUpdateViewModel);

            return CustomResponse(userPersonUpdateViewModel);
        }

        /// <summary>
        ///  - Exclui um usuário existente.
        /// </summary>
        /// <param name="id">ID do usuário a ser excluído.</param>
        /// <returns>Resposta indicando sucesso ou falha.</returns>

        [Authorize(Roles = Roles.Admin)]
        //[ClaimsAuthorizeAttribute(ClaimTypes.UserPerson, "UserPersonRemover")]
        [HttpDelete("UserPersonRemover")]
        public async Task<ActionResult<bool>> UserPersonRemover(Guid id)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _userPersonAppService.UserPersonRemover(id);

            return CustomResponse("OK");
        }
    }
}
