using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortalNFE.Api.Controllers;
using PortalNFE.Core.Interfaces;
using PortalNFE.Identity.Application.Constants;
using PortalNFE.Identity.Application.Interfaces;
using PortalNFE.Identity.Application.ViewModels;

namespace PortalNFE.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/auth")]
    public class AuthController : MainController
    {
        private readonly IIdentityAppService _identityAppService;
        public AuthController(IIdentityAppService identityAppService, INotifier notificador) : base(notificador)
        {
            _identityAppService = identityAppService;
        }

        /// <summary>
        ///  - Login do usuário no Identity.
        /// </summary>
        /// <param name="loginUserViewModel">Dados do login usuário.</param>
        /// <returns>Token.</returns>

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUserViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _identityAppService.Login(loginUserViewModel);

            return CustomResponse(result);
        }

        /// <summary>
        ///  - Criar um novo usuário no Identity.
        /// </summary>
        /// <param name="registerUserViewModel">Dados do novo usuário.</param>
        /// <returns>O usuário criado.</returns>

        [Authorize(Roles = Roles.Admin)]
        [HttpPost("register-identity-user")]
        public async Task<ActionResult> RegisterIdentityUser(RegisterUserViewModel registerUserViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _identityAppService.RegisterIdentityUser(registerUserViewModel);

            return CustomResponse(result);
        }

        /// <summary>
        ///  - Recupera o login do usuáro no Identity.
        /// </summary>
        /// <param name="forgotPasswordViewModel">Dados do email do usuário.</param>
        /// <returns>Usuário irá receber um email.</returns>

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _identityAppService.ForgotPasswordAsync(forgotPasswordViewModel.Email);

            if (result) return Ok();

            return NotFound();
        }
    }
}
