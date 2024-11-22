using Common;
using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.IClass
{
    public interface IQualificationService
    {
        Task<Response> InsertQualificationAsync(Qualification qualification);
        Task<Response> UpdateQualificationByIdAsync(int id, Qualification qualification);
        Task<Response> DeleteQualificationByIdAsync(int id);
        Task<Response> GetAllQualificationAsync();
        Task<Response> GetQualificationById(int id);
    }
}
