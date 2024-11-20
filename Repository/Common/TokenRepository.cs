using Models.Common;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class TokenRepository : ITokenRepository
    {
        private readonly IMongoCollection<BlacklistedToken> _admincollection;

        public TokenRepository(MongoDbRepository context)
        {
            _admincollection = context.BlacklistedToken;
        }
        public async Task AddTokenToBlacklistAsync(string token, DateTime expiryDate)
        {
            var blacklistedToken = new BlacklistedToken
            {
                Token = token,
                ExpiryDate = expiryDate
            };
            await _admincollection.InsertOneAsync(blacklistedToken);
        }

        public async Task<bool> IsTokenBlacklistedAsync(string token)
        {
            var count = await _admincollection.CountDocumentsAsync(t => t.Token == token);
            return count > 0;
        }
    }
}
