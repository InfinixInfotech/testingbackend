using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SO;

namespace Repository.SO.IClass
{
    public interface ISORepository
     {

        Task<IEnumerable<So>> GetAllSO();
        Task InsertSO(So so);
        Task<So> GetByIdAsync(int id);
        Task UpdateSO(So model);
        Task DeleteSO(int id);
     }
}
