using System.Collections.Generic;
using Cryptocop.Software.API.Repositories.Helpers;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        public void AddPaymentCard(string email, PaymentCardInputModel paymentCard)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PaymentCardDto> GetStoredPaymentCards(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}

/*
PaymentRepository (2%)

• AddPaymentCard => Add a payment card to the database

• GetStoredPaymentCards => Gets all stored payment cards from the database associated with the authenticated user
*/