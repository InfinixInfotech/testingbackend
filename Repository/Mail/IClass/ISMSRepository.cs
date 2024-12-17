using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Mail;

namespace Repository.Mail.IClass
{
    public interface ISMSRepository
    {
        Task AddSMS(Email sMS);
        Task<bool> DeleteSMSById(int id);
        Task<List<Email>> GetAllSMS();
        Task UpdateSMSById(Email model);
        Task<Email> GetSMSById(int id);
        Task<List<Email>> GetAllSMSByEmployeeCode(string employeeCode);
        Task<List<Email>> GetAllSMSByisImportant(bool isImportant);

    }
}
