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
        Task<Response> AddSMS(SMS sms);
        Task<Response> GetSMSById(int id);
        Task<Response> UpdateSMSById(Email model);
        Task<Response> GetAllSMS();
        Task<Response> DeleteSMSById(int id);
        Task<Response> GetAllSMSByEmployeeCode(string employeeCode);
    }
}
