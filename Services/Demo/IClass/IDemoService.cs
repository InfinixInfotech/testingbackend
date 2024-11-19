using Models.Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Demo.IClass
{
    public interface IDemoService
    {
        Task<IEnumerable<Demos>> GetAllAsync();
        Task<Demos> GetByIdAsync(int id);
        Task AddAsync(Demos demo);
    }
}
