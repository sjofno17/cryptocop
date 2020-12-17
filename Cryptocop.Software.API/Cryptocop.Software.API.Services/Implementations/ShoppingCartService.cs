using Cryptocop.Software.API.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Helpers;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private static readonly HttpClient client = new HttpClient();
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            return _shoppingCartRepository.GetCartItems(email);
        }

        public Task AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItem)
        {
            // *** TODO ***
           /* var price = 0;
            // Call the external API using the product identifier as an URL parameter to receive the
            //        current price in USD for this particular cryptocurrency
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("x-messari-api-key", "13d40275-6ada-445f-89c1-8809470621e8");
            var shop = shoppingCartItem.ProductIdentifier;
            var js = client.GetStringAsync("https://data.messari.io/api/v1/assets/"+ shop +"/metrics/market-data");
            
            //Deserialize the response to a CryptoCurrencyDto model     
            var des = new CryptoCurrencyDto {
                Id = shoppingCartItem.ProductIdentifier,

            } = HttpResponseMessageExtensions.DeserializeJsonToObject<CryptoCurrencyDto>(js);
                price = des.PriceInUsd;
            //Add it to the database using the appropriate repository class
            return _shoppingCartRepository.AddCartItem(email, shoppingCartItem, price);
            */
            throw new System.NotImplementedException();
        }

        public void RemoveCartItem(string email, int id)
        {
            _shoppingCartRepository.RemoveCartItem(email, id);
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            _shoppingCartRepository.UpdateCartItemQuantity(email, id, quantity);
        }

        public void ClearCart(string email)
        {
            _shoppingCartRepository.ClearCart(email);
        }
    }
}