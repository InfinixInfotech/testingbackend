using Common;
using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.IClass
{
    public interface IDepartmentService
    {
        Task<Response> CreateDepartmentAsync(Department department);
        Task<Response> UpdateDepartmentAsync(Department department);
        Task<Response> DeleteDepartmentAsync(int id);
        Task<Response> GetAllDepartmentAsync();
        Task<Response> GetDepartmentById(int id);
    }
}
