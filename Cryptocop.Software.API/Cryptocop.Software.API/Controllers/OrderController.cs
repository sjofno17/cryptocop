using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // TODO: Setup routes
        [HttpGet]
        [Route("")]
        public IActionResult GetOrders()
        {
            // Gets all orders associated with the authenticated user
            return Ok(_orderService.GetOrders(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddOrder([FromBody] OrderInputModel order)
        {
            // Adds a new order associated with the authenticated user, see Models section for reference

            //var newOrder = _orderService.AddOrder(order, User.Identity.Name);
            //return CreatedAtRoute();
            return NoContent();
        }
    }
}