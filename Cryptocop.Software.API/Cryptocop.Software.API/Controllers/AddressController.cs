using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly ITokenService _tokenService;
        public AddressController(IAddressService addressService, ITokenService tokenService)
        {
            _addressService = addressService;
            _tokenService = tokenService;
        }

        // TODO: Setup routes

        /*[HttpGet]
        [Route("addresses")]
        public IActionResult GetAddresses([FromBody] AddressInputModel address)
        {

        }

        [HttpPost]
        [Route("addresses")]
        public IActionResult AddAddress([FromBody] AddressInputModel address)
        {
            var adding = _addressService.AddAddress(address);
            //if (user == null) { return Unauthorized(); }
            return Ok(_tokenService.GenerateJwtToken(adding));
        }

        [HttpDelete]
        [Route("addresses/:id")]
        public IActionResult DeleteAddress([FromBody] RegisterInputModel register)
        {

        }*/
    }
}
/*
AddressController (2%)
• /api/addresses [GET] - Gets all addresses associated with authenticated user
• /api/addresses [POST] - Adds a new address associated with authenticated user, see Models section for reference
• /api/addresses/{id} [DELETE] - Deletes an address by id 
*/