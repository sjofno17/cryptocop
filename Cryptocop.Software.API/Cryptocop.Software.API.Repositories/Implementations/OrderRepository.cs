using System;
using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            throw new NotImplementedException();
        }

        public OrderDto CreateNewOrder(string email, OrderInputModel order)
        {
            throw new NotImplementedException();
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