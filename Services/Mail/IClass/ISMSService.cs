using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models.Mail;

namespace Services.Mail.IClass
{
    public interface ISMSService
    {
        Task<Response> AddSMS(SMS sMS, string groupName);
        Task<Response> GetSMSById(int id, string apiType, string accessType, string groupName);
        Task<Response> UpdateSMSById(Email model, string groupName);
        Task<Response> GetAllSMS(string apiType, string accessType, string groupName);
        Task<Response> DeleteSMSById(int id, string apiType, string accessType, string groupName);
    }
}
