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
    public class OrderRepository : IOrderRepository
    {
        private readonly CryptocopDbContext _dbContext;

        public OrderRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            //Comment frá Arnari
            // Eina sem ég myndi bæta við þarna væri að setja inn OrderItems og mappa yfir í OrderItemDto úr entity model sem kemur í gegnum
            // o.OrderItems.Select(oi => new OrderItemDto { /* Here things should be mapped */ })
            // Eitt sem er gott að nota hér er Include() (https://docs.microsoft.com/en-us/ef/core/querying/related-data/eager)

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
                                TotalPrice = o.TotalPrice//,
                                //OrderItems = o.OrderItems.Select(oi => new OrderItemDto { /* Here things should be mapped */ }).ToList()
                            }).ToList();            
            return orders;
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            // Retrieve information for the user with the email passed in
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);

            // ef notandinn er ekki til þá er ekkert gert
            if(user == null) { throw new Exception("User not found"); }

            // *** TODO ***
            // Retrieve information for the address with the address id passed in

            // Retrieve information for the payment card with the payment card id passed in


            // Create a new order where the credit card number has been masked, e.g. ************5555            
            // hér bý ég til order, en hvernig sæki ég þessar upplýsingar?
            var entity = new OrderEntity
            {
                //CardHolderName = order.PaymentCardId.,




            };
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();

            // Return the order but here the credit card number should not be masked
            // á að de-maska það þá?
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
                CreditCard = entity.MaskedCreditCard,
                OrderDate = entity.OrderDate.ToString("dd.MM.yyyy"),
                TotalPrice = entity.TotalPrice
            };
        }
    }
}