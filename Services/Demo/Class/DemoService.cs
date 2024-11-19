using Models.Demo;
using Repository.Demo.IClass;
using Services.Demo.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demo.Class
{
    public class DemoService : IDemoService
    {
        private readonly IDemoRepository _demo;
        public DemoService(IDemoRepository demoRepository)
        {
            _demo = demoRepository;
        }
        public async Task<IEnumerable<Demos>> GetAllAsync()
        {
            return await _demo.GetAllAsync();
        }

        public async Task<Demos> GetByIdAsync(int id)
        {
            return await _demo.GetByIdAsync(id);
        }

        public async Task AddAsync(Demos demo)
        {
            await _demo.AddAsync(demo);
        }
    }
}
