using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.DTOs;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        public Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            throw new System.NotImplementedException();
        }
    }
}

/*

GetAvailableCryptocurrencies

• Call the external API and get all cryptocurrencies with fields required for the
CryptoCurrencyDto model

• Deserializes the response to a list - I would advise to use the HttpResponseMessageExtensions 
which is located within Helpers/ to deserialize and flatten the response.

• Return a filtered list where only the available cryptocurrencies BitCoin (BTC),
Ethereum (ETH), Tether (USDT) and Monero (XMR) are within the list

*/