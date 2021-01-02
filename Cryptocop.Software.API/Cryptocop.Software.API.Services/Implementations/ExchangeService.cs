using System.Net.Http;
using System.Threading.Tasks;
using System;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.DTOs;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        public async Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            HttpClient client = new HttpClient();

            // Call the external API with a paginated query and get all exchanges with fields required for the ExchangeDto model
            var getExhanges = "https://data.messari.io/api/v1/markets?page={pageNumber}&fields=id,exchange_name,exchange_slug,quote_asset_symbol,price_usd,last_trade_at";

            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(getExhanges);
            // Deserialize the response to a list - I would advise to use the HttpResponseMessageExtensions to deserialize and flatten the response
            var responseFlat = await HttpResponseMessageExtensions.DeserializeJsonToList<ExchangeDto>(response, true);

            // Create an envelope and add the list to the envelope and return that
            /*var envelope = new Envelope<ExchangeDto> 
            {
                Items = new List<ExchangeDto>(responseFlat);

            };*/
            //return envelope;    
            return null;
        }
    }
}

