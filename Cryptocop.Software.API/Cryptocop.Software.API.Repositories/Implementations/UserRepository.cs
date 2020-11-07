using System;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;

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
            throw new NotImplementedException();
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new NotImplementedException();
        }
    }
}

/*
UserRepository (3%)

• CreateUser => Check if user with same email exists within the database - if it does do not continue
                Add a user to the database where the password has been hashed using the hashing function provided
                Create a new token within the database
                Return the user

• AuthenticateUser => Check if user has provided the correct credentials by comparing the email and password - if it is not correct do not continue
                        Create a new token within the database
                        Return the user
*/