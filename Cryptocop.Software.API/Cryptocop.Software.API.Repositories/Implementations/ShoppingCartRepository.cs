using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Models.Entities;

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
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var shoppingCart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == user.Id);

            var cartItems = _dbContext
                            .ShoppingCartItems
                            .Where(c => c.ShoppingCartId == shoppingCart.Id)
                            .Select(a => new ShoppingCartItemDto
                            {
                                Id = a.Id,
                                ProductIdentifier = a.ProductIdentifier,
                                Quantity = a.Quantity,
                                UnitPrice = a.UnitPrice,
                                TotalPrice = a.UnitPrice * a.Quantity
                            }).ToList();  
            return cartItems; 
        }

        public void AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItem, float priceInUsd)
        {
            // Add a cart item to the database
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            var cartItem =  new ShoppingCartItemEntity
            {
                ShoppingCartId = user.ShoppingCart.Id,
                ProductIdentifier = shoppingCartItem.ProductIdentifier,
                Quantity = shoppingCartItem.Quantity,
                UnitPrice = priceInUsd
            };

            _dbContext.ShoppingCartItems.Add(cartItem);
            _dbContext.SaveChanges();
        }

        public void RemoveCartItem(string email, int id)
        {
            // Remove a cart item from the database
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var cartItem = _dbContext.ShoppingCartItems.FirstOrDefault(i => i.Id == id);
            if(cartItem == null) { throw new Exception("Shoppingcart item not found"); }
            if(user.ShoppingCart.Id != cartItem.ShoppingCartId) { throw new Exception("User does not have this item"); }

            _dbContext.ShoppingCartItems.Remove(cartItem);
            _dbContext.SaveChanges();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            // Update a cart items quantity within the database
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var cart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.Id == id);
            if(cart == null) { throw new Exception("Shoppingcart not found"); }
            //if(user.ShoppingCart.Id != cart.ShoppingCartId) { throw new Exception("User does not have this item"); }

            var item = _dbContext.ShoppingCartItems.FirstOrDefault(i => i.Id == id && i.ShoppingCartId == cart.Id);
            item.Quantity = quantity;
            
            _dbContext.ShoppingCartItems.Update(item);
            _dbContext.SaveChanges();
        }

        public void ClearCart(string email)
        {
            // Clear all cart items from the shopping cart in the database
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var shoppingCart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == user.Id);
            var cartItems = _dbContext.ShoppingCartItems.Where(i => i.ShoppingCartId == shoppingCart.Id);

            foreach(ShoppingCartItemEntity item in cartItems)
            {
                _dbContext.ShoppingCartItems.Remove(item);
                _dbContext.SaveChanges();
            }
        }

        public void DeleteCart(string email)
        {
            // The cart is deleted when the order is created, we can use that method then
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var shoppingCart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.Id == user.ShoppingCart.Id);
            _dbContext.ShoppingCarts.Remove(shoppingCart);
            _dbContext.SaveChanges();
        }
    }
}