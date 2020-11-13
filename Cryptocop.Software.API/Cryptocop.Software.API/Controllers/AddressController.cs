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

        [HttpGet]
        [Route("")]
        public IActionResult GetAddresses()
        {
            // /api/addresses [GET] - Gets all addresses associated with authenticated user

            return Ok(_addressService.GetAllAddresses(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddAddress([FromBody] AddressInputModel address)
        {
            // /api/addresses [POST] - Adds a new address associated with authenticated user, 
            //                         see Models section for reference

            //return Ok(_addressService.AddAddress(User.Identity.Name, address));
            return NoContent();
        }

        [HttpDelete]
        [Route("addresses/:id")]
        public IActionResult DeleteAddress([FromBody] RegisterInputModel register)
        {
            // /api/addresses/{id} [DELETE] - Deletes an address by id 

            return NoContent();

        }
    }
}