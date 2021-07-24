using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using StreetWorkoutApp.Data.Models;
using StreetWorkoutApp.Server.Features.Identity.Models;
using StreetWorkoutApp.Services.Identity;

namespace StreetWorkoutApp.Server.Features.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IIdentityService identityService;
        private readonly AppSettings appSettings;

        public IdentityController(
            UserManager<AppUser> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.identityService = identityService;
            this.appSettings = appSettings.Value;
        }

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new AppUser
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok("user created");
            }

            return Unauthorized(result.Errors);
        }

        [HttpPost(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return Unauthorized("no such user");
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized("wrong password");
            }

            var encryptedToken = identityService.GenerateJwtToken(user.Id, user.UserName, this.appSettings.Secret);

            return new LoginResponseModel { Token = encryptedToken };
        }
    }
}
