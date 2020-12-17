using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;
        
        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetCartItems()
        {
            return Ok(_shoppingCartService.GetCartItems(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddCartItem([FromBody] ShoppingCartItemInputModel item)
        {
            if(!ModelState.IsValid) { return BadRequest("Cart item is not properly constructed!"); }

            _shoppingCartService.AddCartItem(User.Identity.Name, item);
            return StatusCode(201, item);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCartItem(int cartItemId)
        {
            _shoppingCartService.RemoveCartItem(User.Identity.Name, cartItemId);
            return NoContent();
        }

        [HttpPatch]
        [Route("{id}")]
        public IActionResult UpdateQuantity(float quantity, int id)
        {
            if(!ModelState.IsValid){ return BadRequest(); }
            
            _shoppingCartService.UpdateCartItemQuantity(User.Identity.Name, id, quantity);
            return Ok();
        }

        [HttpDelete]
        [Route("")]
        public IActionResult ClearCart()
        {
            _shoppingCartService.ClearCart(User.Identity.Name);
            return NoContent();
        }
    }
}