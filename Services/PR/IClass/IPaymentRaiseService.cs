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
        Task<Response> LeadPR(PaymentRaise model);
        Task<Response> GetLeadPRById(int id);
        Task<Response> UpdateLeadPRById(PaymentRaise model);
        Task<Response> DeleteLeadPRById(int id);
        Task<Response> GetAllLeadPR();
    }
}
