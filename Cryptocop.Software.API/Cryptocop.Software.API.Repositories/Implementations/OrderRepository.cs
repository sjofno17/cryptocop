using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Helpers;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly CryptocopDbContext _dbContext;

        public OrderRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            var orders = _dbContext
                            .Orders
                            .Where(e => e.User.Email == email)
                            .Select(o => new OrderDto
                            {
                                Id = o.Id,
                                Email = o.Email,
                                FullName = o.FullName,
                                StreetName = o.StreetName,
                                HouseNumber = o.HouseNumber,
                                ZipCode = o.ZipCode,
                                Country = o. Country,
                                City = o.City,
                                CardholderName = o.CardHolderName,
                                CreditCard = o.MaskedCreditCard,
                                OrderDate = o.OrderDate.ToString("dd.MM.yyyy"),
                                TotalPrice = o.TotalPrice,
                                //OrderItems = o.OrderItems.Select(oi => new OrderItemDto { /* Here things should be mapped */ }).ToList()
                                OrderItems = _dbContext.OrderItems
                                    .Where(oId => oId.OrderId == oId.OrderId)
                                    .Select(oItem => new OrderItemDto
                                    {
                                        Id = o.OrderItems.Id,
                                        ProductIdentifier = o.OrderItems.ProductIdentifier,
                                        Quantity = o.OrderItems.Quantity,
                                        UnitPrice = o.OrderItems.UnitPrice,
                                        TotalPrice = o.OrderItems.TotalPrice
                                    }).ToList()
                            }).ToList();
            return orders;
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            // Retrieve information for the user with the email passed in
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            // Retrieve information for the address with the address id passed in
            var address = _dbContext.Addresses.FirstOrDefault(a => a.Id == order.AddressId);
            // Retrieve information for the payment card with the payment card id passed in
            var card = _dbContext.PaymentCards.FirstOrDefault(c => c.Id == order.PaymentCardId);
            var cardNumber = card.CardNumber;
            var shoppingCart = _dbContext.ShoppingCarts.FirstOrDefault(s => s.UserId == user.Id);
            var fullName = user.FullName;

            float totalPrice = 0;
            for(int i = 0; i < shoppingCart.ShoppingCartItems.Count(); i++)
            {
                totalPrice += shoppingCart.ShoppingCartItems[i].UnitPrice * shoppingCart.ShoppingCartItems[i].Quantity;
            }
            
            // Create a new order where the credit card number has been masked, e.g. ************5555 
            var entity = new OrderEntity
            {
                Email = user.Email,
                FullName = fullName,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                ZipCode = address.ZipCode,
                Country = address.Country,
                City = address.City,
                CardHolderName = card.CardHolderName,
                MaskedCreditCard = PaymentCardHelper.MaskPaymentCard(card.CardNumber),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice 
            };       
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();

            // Return the order but here the credit card number should not be masked
            return new OrderDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                StreetName = entity.StreetName,
                HouseNumber = entity.HouseNumber,
                ZipCode = entity.ZipCode,
                Country = entity.Country,
                CardholderName = entity.CardHolderName,
                CreditCard = cardNumber,
                OrderDate = entity.OrderDate.ToString("dd.MM.yyyy"),
                TotalPrice = entity.TotalPrice
            };
        }
    }
}