using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models.SO;

namespace Services.SO.IClass
{
    public interface ISOService
    {

        Task<Response> InsertSO(So sO);
        Task<Response> UpdateSO(So sO);
        Task<Response> DeleteSO(int id);
        Task<Response> GetSOById(int id);
        Task<Response> GetAllSO();

        }
}
