using System.Threading;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RevInfotech.Models;
using RevInfotech.Services;

namespace RevInfotech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<UserEntity> _usermanager;
        
        private readonly IUserServices _userService;
        private IConfiguration _configuration;

        public AccountController(UserManager<UserEntity> userManager, IUserServices userServices, IConfiguration configuration)
        {
            _usermanager = userManager;
            
            _userService = userServices;
            configuration = _configuration;
        }

        [HttpPost("signin")]
        public IActionResult SignIn([FromBody] Credentials Credentials,
            CancellationToken ct)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct credentials");
            var (result, succeeded) = _userService.SignIn(Credentials);
            if (succeeded) return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Register")]
        //POST : api/Home/Register
        public IActionResult Register([FromBody]UserModel userModel)
        {
            if (!ModelState.IsValid) return BadRequest("Enter the correct Value");
            var (result, succeeded) = _userService.CreateUserAsync(userModel);
            if (succeeded) return Ok(result);
            return BadRequest(result);
            
        }
    }
}