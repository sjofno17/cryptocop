using Microsoft.AspNetCore.Mvc;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Controllers
{
    [ApiController]
    [Route("api/cryptocurrencies")]
    public class CryptoCurrencyController : ControllerBase
    {
        private readonly  ICryptoCurrencyService _cryptoCurrencyService;
        
        public CryptoCurrencyController(ICryptoCurrencyService cryptoCurrencyService)
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetPaymentCards()
        {
            // Gets all available cryptocurrencies - the only available cryptocurrencies in this 
            //     platform are BitCoin (BTC), Ethereum (ETH), Tether (USDT) and Monero (XMR)


            //return Ok(_cryptoCurrencyService.GetAvailableCryptocurrencies(User.Identity.Name));
            return NoContent();
        }
    }
}