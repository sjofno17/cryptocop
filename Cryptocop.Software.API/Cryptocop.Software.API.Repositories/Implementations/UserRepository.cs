using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Helpers;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        public UserRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        public UserDto CreateUser(RegisterInputModel inputModel)
        {   
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == inputModel.Email);
            if(user != null) { throw new Exception("User already exist"); }

            var entity = new UserEntity
            {
                Email = inputModel.Email,
                FullName = inputModel.FullName,
                HashedPassword = HashingHelper.HashPassword(inputModel.Password)          
            };
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            var token = new JwtToken();
            _dbContext.JwtTokens.Add(token);
            _dbContext.SaveChanges();

            return new UserDto
            {
                Id = _dbContext.Users.FirstOrDefault(u => u.Email == inputModel.Email).Id,
                FullName = entity.FullName,
                Email = entity.Email,
                TokenId = token.Id
            };
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => 
                        u.Email == loginInputModel.Email &&
                        u.HashedPassword == HashingHelper.HashPassword(loginInputModel.Password));
            if(user == null) {return null; }

            var token = new JwtToken();
            _dbContext.JwtTokens.Add(token);
            _dbContext.SaveChanges();
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                TokenId = token.Id
            };
        }
    }
}