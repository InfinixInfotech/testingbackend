using Common;
using Models.PR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PR.IClass
{
    public interface IPaymentRaiseService
    {
        Task<Response> LeadPR(PaymentRaise model, string groupName);
        Task<Response> GetLeadPRById(int id, string apiType, string accessType, string groupName);
        Task<Response> UpdateLeadPRById(PaymentRaise model, string groupName);
        Task<Response> DeleteLeadPRById(int id, string apiType, string accessType, string groupName);
        Task<Response> GetAllLeadPR(string apiType, string accessType, string groupName);
    }
}
