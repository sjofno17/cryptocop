using System.Linq;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Models.Entities;
using Cryptocop.Software.API.Repositories.Contexts;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class TokenRepository : ITokenRepository
    {
        private readonly CryptocopDbContext _dbContext;
        public TokenRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public JwtToken CreateNewToken()
        {            
           // *** TODO ***
            throw new System.NotImplementedException();
        }

        public bool IsTokenBlacklisted(int tokenId)
        {
            // IsTokenBlacklisted => Check to see if the token is blacklisted within the database
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if(token == null) { return true; }

            return token.Blacklisted;
        }

        public void VoidToken(int tokenId)
        {
            // VoidToken => Set the token to blacklisted within the database
            var token = _dbContext.JwtTokens.FirstOrDefault(t => t.Id == tokenId);
            if (token == null) { return; }
            token.Blacklisted = true;
            _dbContext.SaveChanges();
        }
    }
}