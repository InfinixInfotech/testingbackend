using Common;
using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.IClass
{
    public interface IDesignationService
    {
        Task<Response> CreateDesignation(Designation designation);
        Task<Response> UpdateDesignation(Designation designation);
        Task<Response> DeleteDesignation(int id);
        Task<Response> GetAllDesignation();
        Task<Response> GetDesignationById(int id);
    }
}
