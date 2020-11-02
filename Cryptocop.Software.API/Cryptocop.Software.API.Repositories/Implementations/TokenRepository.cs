using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        public JwtToken CreateNewToken()
        {
            throw new System.NotImplementedException();
        }

        public bool IsTokenBlacklisted(int tokenId)
        {
            throw new System.NotImplementedException();
        }

        public void VoidToken(int tokenId)
        {
            throw new System.NotImplementedException();
        }
    }
}

/*
TokenRepository (2%)

• CreateNewToken => Add a new token to the database

• IsTokenBlacklisted => Check to see if the token is blacklisted within the database

• VoidToken => Set the token to blacklisted within the database
*/