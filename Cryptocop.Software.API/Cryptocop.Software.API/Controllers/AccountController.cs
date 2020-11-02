using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    //[Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // TODO: Setup routes
        //[AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult SignIn([FromBody] LoginInputModel login)
        {
            // TODO: call a authenticationService && return valid JWT Token
            return Ok();
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