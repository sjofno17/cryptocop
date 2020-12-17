using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
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

        [HttpGet]
        [Route("")]
        public IActionResult GetAddresses()
        {
            return Ok(_addressService.GetAllAddresses(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddAddress([FromBody] AddressInputModel address)
        {
            if(!ModelState.IsValid) { return BadRequest("Address is not properly constructed!"); }

            _addressService.AddAddress(User.Identity.Name, address);
            return StatusCode(201, address);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteAddress(int addressId)
        {
            _addressService.DeleteAddress(User.Identity.Name, addressId);
            return NoContent();
        }
    }
}