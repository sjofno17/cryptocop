using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly CryptocopDbContext _dbContext;
        public ShoppingCartRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            // Gets all cart items from the database associated with the authenticated user
            
            /*var cartItems = _dbContext
                            .ShoppingCartItems
                            .Where(a => a.User.Email == email)
                            .Select(a => new AddressDto
                            {
                                Id = a.Id,
                                StreetName = a.StreetName,
                                HouseNumber = a.HouseNumber,
                                ZipCode = a.ZipCode,
                                Country = a. Country,
                                City = a.City
                            }).ToList();            
            return cartItems;*/
            throw new System.NotImplementedException();
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem, float priceInUsd)
        {
            // Add a cart item to the database
            throw new System.NotImplementedException();
        }

        public void RemoveCartItem(string email, int id)
        {
            // Remove a cart item from the database
            throw new System.NotImplementedException();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            // Update a cart items quantity within the database
            throw new System.NotImplementedException();
        }

        public void ClearCart(string email)
        {
            // Clear all cart items from the shopping cart in the database
            throw new System.NotImplementedException();
        }

        public void DeleteCart(string email)
        {
            // The cart is deleted when the order is created, we can use that method then
            throw new System.NotImplementedException();
        }
    }
}