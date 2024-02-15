
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PortalNFE.Core.Interfaces;
using PortalNFE.Core.Services;
using PortalNFE.Identity.Domain.DTO;
using PortalNFE.Identity.Domain.Extensions;
using PortalNFE.Identity.Domain.Interfaces;
using PortalNFE.Identity.Domain.Models;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortalNFE.Identity.Domain.Services
{
    public class IdentityService : BaseService, IIdentityService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettings _appSettings;
        private readonly IEmailSenderService _emailSenderService;
        public IdentityService(SignInManager<AppUser> signInManager,
                               UserManager<AppUser> userManager,
                               IOptions<AppSettings> appSettings,
                               IEmailSenderService emailSenderService,
                               INotifier notifier) : base(notifier)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _emailSenderService = emailSenderService;
        }

        public async Task<RegisterUser> RegisterIdentityUser(RegisterUser registerUser)
        {
            var user = new AppUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true,
                UserPersonId = registerUser.UserPersonId.ToString()
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
                return registerUser;

            foreach (var error in result.Errors)
                Notify(error.Description);

            return registerUser;
        }
        public async Task<LoginResponse> Login(LoginUser loginUser)
        {
            var loginResponse = new LoginResponse();
            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
                return await GerarJwt(loginUser);

            if (result.IsLockedOut)
            {
                Notify("Usuário temporariamente bloqueado por tentativas inválidas.");
                return loginResponse;
            }

            Notify("Usuário ou Senha incorretos.");
            return loginResponse;
        }
        private async Task<LoginResponse> GerarJwt(LoginUser loginUser)
        {  
            var user = await _userManager.FindByNameAsync(loginUser.Email);
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));         

            foreach (var userRole in userRoles)            
                claims.Add(new Claim("role", userRole));
            
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);
            var response = new LoginResponse
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserToken
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                    Claims = claims.Select(c => new Claims { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }       
        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return false;

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // link de redefinição de senha
            var resetLink = $"https://sua-api.com/resetpassword?email={email}&token={resetToken}";

            var subject = "Redefinir senha";

            var body = $"Clique <a href=\"{resetLink}\">aqui</a> para redefinir sua senha.";

            await _emailSenderService.SendEmail(email, subject, body);

            return true;
        }
        public async Task InvalidateTokenAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // Atualize o security stamp do usuário
                await _userManager.UpdateSecurityStampAsync(user);
            }
        }
    }
}
