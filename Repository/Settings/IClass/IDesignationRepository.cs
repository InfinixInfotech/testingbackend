using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.IClass
{
    public interface IDesignationRepository
    {
        Task<IEnumerable<Designation>> GetAllDesignation();
        Task<Designation> GetDesignationById(int id);
        Task CreateDesignation(Designation designation);
        Task UpdateDesignation(Designation designation);
        Task DeleteDesignation(int id);
    }
}
