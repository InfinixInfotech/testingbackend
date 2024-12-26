using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.Class
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly IMongoCollection<Designation> _collection;
        public DesignationRepository(MongoDbRepository context) 
        {
            _collection = context.Designation;
        }
        public async Task<IEnumerable<Designation>> GetAllDesignation()
        {
            return await _collection.Find(designation => true).ToListAsync();
        }

        public async Task<Designation> GetDesignationById(int id)
        {
            return await _collection.Find(designation => designation.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateDesignation(Designation designation)
        {
            await _collection.InsertOneAsync(designation);
        }

        public async Task UpdateDesignation(Designation designation)
        {
            await _collection.ReplaceOneAsync(d => d.Id == designation.Id, designation);
        }

        public async Task DeleteDesignation(int id)
        {
            await _collection.DeleteOneAsync(d => d.Id == id);
        }
    }
}
