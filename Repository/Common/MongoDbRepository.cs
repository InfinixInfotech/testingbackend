using Microsoft.Extensions.Configuration;
using Models.Common;
using Models.Demo;
using Models.Login;
using Models.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public class MongoDbRepository
    {
        private readonly IMongoDatabase _database;
        public MongoDbRepository(IConfiguration configuration)
        {

            var client = new MongoClient(configuration.GetSection("MongoDBSettings:ConnectionString").Value);

            _database = client.GetDatabase(configuration.GetSection("MongoDBSettings:DatabaseName").Value);
        }
        public IMongoCollection<Demos> Demos => _database.GetCollection<Demos>("Demos");
        public IMongoCollection<User> Users => _database.GetCollection<User>("User");
        public IMongoCollection<Groups> Groups => _database.GetCollection<Groups>("Groups");
        public IMongoCollection<BlacklistedToken> BlacklistedToken => _database.GetCollection<BlacklistedToken>("BlacklistedToken");
        public IMongoCollection<Department> Department => _database.GetCollection<Department>("Department");
        public IMongoCollection<Qualification> Qualification => _database.GetCollection<Qualification>("Qualification");
        public IMongoCollection<Segment> Segment => _database.GetCollection<Segment>("Segment");
        public IMongoCollection<SegmentPlan> SegmentPlan => _database.GetCollection<SegmentPlan>("SegmentPlan");
    }
}
