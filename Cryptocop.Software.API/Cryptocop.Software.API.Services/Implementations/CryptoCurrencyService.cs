using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using System;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class CryptoCurrencyService : ICryptoCurrencyService
    {
        private static readonly HttpClient client = new HttpClient();

        public  Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("x-messari-api-key", "13d40275-6ada-445f-89c1-8809470621e8");

                var js = client.GetStringAsync("https://data.messari.io/api/v2/assets");
                Console.WriteLine(js);

                var responseFlat = HttpResponseMessageExtensions.DeserializeJsonToList<String>(js, true);

            return responseFlat;
        }
    }


}
/*
• Call the external API and get all cryptocurrencies with fields required for the CryptoCurrencyDto model

• Deserializes the response to a list - I would advise to use the HttpResponseMessageExtensions 
 to deserialize and flatten the response.

• Return a filtered list where only the available cryptocurrencies BitCoin (BTC),
Ethereum (ETH), Tether (USDT) and Monero (XMR) are within the list

*/