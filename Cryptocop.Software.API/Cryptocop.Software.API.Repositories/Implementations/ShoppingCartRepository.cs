using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
                            .Join(_dbContext.Users, u => u.Email == email)
                            .Join(_dbContext.ShoppingCarts,
                            s => s.ShoppingCartId == id)
                            .Where(a => )
                            .Select(a => new ShoppingCartItemDto
                            {
                                Id = a.Id,
                                ProductIdentifier = a.ProductIdentifier,
                                Quantity = a.Quantity,
                                UnitPrice = a.UnitPrice//,
                                //TotalPrice = a. TotalPrice 
                                // shoppingcartItemEntity á ekki totalprice
                            }).ToList();            
            return cartItems;*/
            throw new System.NotImplementedException();
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem, float priceInUsd)
        {
            // Add a cart item to the database

            // join shoppingcart to get the user?
            
            /*var cartItem = _dbContext
                            .ShoppingCartItems
                            .Where(a => a.Id == email)
                            .Select(a => new PaymentCardDto
                            {
                                Id = a.Id,
                                CardholderName = a.CardHolderName,
                                CardNumber = a.CardNumber,
                                Month= a.Month,
                                Year = a.Year
                            }).ToList();    */
                            
        }

        public void RemoveCartItem(string email, int id)
        {
            // Remove a cart item from the database
            
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            //if(user == null) { throw new Exception("User not found"); }

            // ég er að remova shopping cart hér en hvernig fer ég að því að eyða bara item?
            _dbContext.Remove(_dbContext.ShoppingCarts.FirstOrDefault(a=> a.Id == id && a.UserId == user.Id));
            _dbContext.SaveChanges();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            // Update a cart items quantity within the database

            // when new item is put in cart then add 1 to the quantity? and minus when removed
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