using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.IClass
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<Department> GetByIdDepartmentAsync(int id);
        Task CreateDepartmentAsync(Department department);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
    }
}
