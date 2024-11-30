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
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IMongoCollection<Department> _collection;
        public DepartmentRepository(MongoDbRepository context)
        {
            _collection = context.Department;
        }
        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _collection.Find(department => true).ToListAsync();
        }

        public async Task<Department> GetByIdDepartmentAsync(int id)
        {
            return await _collection.Find(department => department.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateDepartmentAsync(Department department)
        {
            await _collection.InsertOneAsync(department);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _collection.ReplaceOneAsync(d => d.Id == department.Id, department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _collection.DeleteOneAsync(d => d.Id == id);
        }
        
    }
}
