using System.Threading.Tasks;
using Domain.Identity;
using Domain.Identity.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SportsbookApp.DTO;

namespace SportsbookApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;

        public UserController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<UserController> logger, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest model)
        {
            var appUser = await _userManager.FindByEmailAsync(model.Email);
            
            if (appUser == null)
            {
                _logger.LogInformation("User not found.");
                return StatusCode(403);
            }
           
            var result = await _signInManager.CheckPasswordSignInAsync(appUser, model.Password, false);

            if (result.Succeeded)
            {
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = JwtHelper.GenerateJwt(
                    claimsPrincipal.Claims, 
                    _configuration["JWT:Key"], 
                    _configuration["JWT:Issuer"], 
                    int.Parse(_configuration["JWT:ExpireDays"]));
                _logger.LogInformation("Token generated for user");
                return Ok(new {token = jwt});
            }

            return StatusCode(403);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register([FromBody] RegisterRequest model)
        {
            var appUser = new AppUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("New user created.");
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = JwtHelper.GenerateJwt(
                    claimsPrincipal.Claims, 
                    _configuration["JWT:Key"], 
                    _configuration["JWT:Issuer"], 
                    int.Parse(_configuration["JWT:ExpireDays"]));
                _logger.LogInformation("Token generated for user");
                return Ok(new {token = jwt});

            }
            return StatusCode(406); 
        }
    }
}