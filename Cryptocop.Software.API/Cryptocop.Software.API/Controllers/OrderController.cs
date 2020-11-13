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
        
        [HttpGet]
        [Route("")]
        public IActionResult GetOrders()
        {
            return Ok(_orderService.GetOrders(User.Identity.Name));
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddOrder([FromBody] OrderInputModel order)
        {
            // Adds a new order associated with the authenticated user, see Models section for reference
            if(!ModelState.IsValid) { return BadRequest("Order is not properly constructed!"); }

            _orderService.CreateNewOrder(User.Identity.Name, order);
            return StatusCode(201, order);
        }
    }
}