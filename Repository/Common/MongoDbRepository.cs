using Microsoft.Extensions.Configuration;
using Models.Demo;
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
    }
}
