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

        Task<Response> InsertSO(So sO, string groupName);
        Task<Response> UpdateSO(So sO, string groupName);
        Task<Response> DeleteSO(int id, string apiType, string accessType, string groupName);
        Task<Response> GetSOById(int id, string apiType, string accessType, string groupName);
        Task<Response> GetAllSO(string apitype, string accessType, string groupName);

        }
}
