using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.DTOs;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class AccountService : IAccountService
    {
        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            throw new System.NotImplementedException();
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            throw new System.NotImplementedException();
        }
         public void Logout(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}

/*

AccountService.cs (1%)

• CreateUser => Creates the user using the appropriate repository class

• AuthenticateUser => Authenticates the user using the appropriate repository class

• Logout => Voids the JWT token using the appropriate repository class

*/