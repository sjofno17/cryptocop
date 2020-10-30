using Microsoft.AspNetCore.Mvc;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        // TODO: Setup routes
    }
}


/*

ShoppingCartController (4%)

• /api/cart [GET] - Gets all items within the shopping cart, see Models section for reference

• /api/cart [POST] - Adds an item to the shopping cart, see Models section for reference

• /api/cart/{id} [DELETE] - Deletes an item from the shopping cart

• /api/cart/{id} [PATCH] - Updates the quantity for a shopping cart item

• /api/cart [DELETE] - Clears the cart - all items within the cart should be deleted


*/