using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.IClass
{
    public interface IQualificationRepository
    {
        Task InsertQualificationAsync(Qualification qualification);
        Task UpdateQualificationByIdAsync(Qualification qualification);
        Task DeleteQualificationByIdAsync(int id);
        Task<List<Qualification>> GetAllQualificationAsync();
        Task<Qualification> GetQualificationById(int id);
    }
}
