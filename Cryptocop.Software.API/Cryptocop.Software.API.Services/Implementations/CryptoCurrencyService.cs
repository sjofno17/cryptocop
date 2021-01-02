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
        public async Task<IEnumerable<CryptoCurrencyDto>> GetAvailableCryptocurrencies()
        {
            HttpClient client = new HttpClient();

            // Call the external API and get all cryptocurrencies with fields required for the CryptoCurrencyDto model
            var getCurrencies = "https://data.messari.io/api/v2/assets?fields=id,name,slug,symbol,metrics/market_data/price_usd,profile/general/overview/project_details";

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(getCurrencies);
            // Deserializes the response to a list - I would advise to use the HttpResponseMessageExtensions to deserialize and flatten the response.
            var responseFlat = await HttpResponseMessageExtensions.DeserializeJsonToList<CryptoCurrencyDto>(response, true);

            // Return a filtered list where only the available cryptocurrencies BitCoin (BTC), Ethereum (ETH), Tether (USDT) and Monero (XMR) are within the list
            return responseFlat.Where(s => s.Symbol == "BTC" || s.Symbol == "ETH" || s.Symbol == "USDT" || s.Symbol == "XMR"); 
        }
    }


}



