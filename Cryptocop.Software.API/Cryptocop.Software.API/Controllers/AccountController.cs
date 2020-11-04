using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IJwtTokenService _jwtTokenService;
        public AccountController(IAccountService accountService, IJwtTokenService jwtTokenService)
        {
            _accountService = accountService;
            _jwtTokenService = jwtTokenService;
        }

        public IActionResult Register()
        {
            
        }
        // TODO: Setup routes
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            var user = _accountService.SignIn(login);
            if (user == null) { return Unauthorized(); }
            return Ok(_jwtTokenService.GenerateJwtToken(user));
        }

        [HttpGet]
        [Route("signout")]
        public IActionResult SignOut()
        {
            // TODO: retrieve token id from claim and blacklist token
            return NoContent();
        }
    }
}

/*

AccountController (3%)

• /api/account/register [POST] - Registers a user within the application, see Models
section for reference

• /api/account/signin [POST] - Signs the user in by checking the credentials provided
and issuing a JWT token in return, see Models section for reference

• /api/account/signout [GET] - Logs the user out by voiding the provided JWT token
using the id found within the claim


*/