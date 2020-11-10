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
                HashedPassword = inputModel.Password          
            };
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u => 
                        u.Email == loginInputModel.Email &&
                        u.HashedPassword == HashPassword(loginInputModel.Password));
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
/*
UserRepository (3%)
• CreateUser => Check if user with same email exists within the database - if it does do not continue
                Add a user to the database where the password has been hashed using the hashing function 
                provided
                Create a new token within the database
                Return the user

• AuthenticateUser => Check if user has provided the correct credentials by comparing the email and password 
                        - if it is not correct do not continue
                        Create a new token within the database
                        Return the user
*/