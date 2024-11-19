using Models.Demo;
using MongoDB.Driver;
using Repository.Common;
using Repository.Demo.IClass;

namespace Repository.Demo.Class
{
    public class DemoRepository : IDemoRepository
    {
        private readonly IMongoCollection<Demos> _admincollection;

        public DemoRepository(MongoDbRepository context)
        {
            _admincollection = context.Demos;
        }
        public async Task<IEnumerable<Demos>> GetAllAsync()
        {
            return await _admincollection.Find(_ => true).ToListAsync(); // Fetch all documents.
        }

        // Get a document by ID
        public async Task<Demos> GetByIdAsync(int id)
        {
            return await _admincollection.Find(d => d.Id == id).FirstOrDefaultAsync();
        }

        // Add a new document
        public async Task AddAsync(Demos demo)
        {
            await _admincollection.InsertOneAsync(demo); // Insert a single document.
        }
    }
}
