
using Models.Common;
using MongoDB.Driver;

namespace Repository.Common
{
    public class IdentifierService : IIdentifierService

    {
        private readonly IMongoCollection<InfinixId> _collectionCollection;

        public IdentifierService(MongoDbRepository context)
        {
            _collectionCollection = context.InfinixId;
        }
        public async Task<long> GetCountAsync()
        {
            return await _collectionCollection.CountDocumentsAsync(FilterDefinition<InfinixId>.Empty);
        }

        public async Task InsertIdentifierAsync(InfinixId identifier)
        {
            await _collectionCollection.InsertOneAsync(identifier);
        }
    }
}
