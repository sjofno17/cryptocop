using System.Collections.Generic;
using System.Linq;
using System;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Contexts;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;

        public AddressRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddAddress(string email, AddressInputModel address)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            var entity = new AddressEntity
            {
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                ZipCode = address.ZipCode,
                Country = address.Country,
                City = address.City,
                UserId = user.Id            
            };
            _dbContext.Addresses.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            var addresses = _dbContext
                            .Addresses
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
            return addresses; 
        }

        public void DeleteAddress(string email, int addressId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if(user == null) { throw new Exception("User not found"); }

            _dbContext.Remove(_dbContext.Addresses.FirstOrDefault(a=> a.Id == addressId && a.UserId == user.Id));
            _dbContext.SaveChanges();
        }
    }
}