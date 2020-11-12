using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Models;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.DTOs;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ExchangeService : IExchangeService
    {
        public Task<Envelope<ExchangeDto>> GetExchanges(int pageNumber = 1)
        {
            throw new System.NotImplementedException();
        }
    }
}
/*
GetExchanges

• Call the external API with a paginated query and get all exchanges with fields
required for the ExchangeDto model

• Deserialize the response to a list - I would advise to use the HttpResponseMessageExtensions 
    which is located within Helpers/ to deserialize and flatten the response.

• Create an envelope and add the list to the envelope and return that

*/