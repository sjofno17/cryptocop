using System;
using System.Linq;
using System.Collections.Generic;
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
                                OrderDate = o.OrderDate,
                                TotalPrice = o.TotalPrice,
                                OrderItems = o.OrderItems
                            }).ToList();            
            return orders;
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var entity = new OrderEntity
            {
                Email= order.Email,

            };
            _dbContext.Addresses.Add(entity);
            _dbContext.SaveChanges();

            return new OrderDto
            {
                Id = entity.Id,
                FullName = entity.FullName,
                Email = entity.Email,
                StreetName = entity.StreetName,
                
            };
        }
    }
}

/*
OrderRepository (4%)

• GetOrders => Gets all orders from the database associated with the authenticated user

• CreateNewOrder => Retrieve information for the user with the email passed in
                    Retrieve information for the address with the address id passed in
                    Retrieve information for the payment card with the payment card id passed in
                    Create a new order where the credit card number has been masked, e.g. ************5555
                    Return the order but here the credit card number should not be masked
*/