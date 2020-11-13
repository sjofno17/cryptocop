using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [Route("api/exchanges")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly  IExchangeService _exchangeService;
        
        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetExhanges()
        {
            // Gets all exchanges in a paginated envelope. This routes accepts a single query 
            // parameter called pageNumber which is used to paginate the results


            //return Ok(_cryptoCurrencyService.GetAvailableCryptocurrencies(User.Identity.Name));
            return NoContent();
        }
    }
}