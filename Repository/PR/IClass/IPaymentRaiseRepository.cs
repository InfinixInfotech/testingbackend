

using Models.PR;

namespace Repository.PR.IClass
{
    public interface IPaymentRaiseRepository
    {
        Task LeadPR(PaymentRaise model);
        Task<PaymentRaise> GetLeadPRById(int id);
        Task UpdateLeadPRById(PaymentRaise model);
        Task<List<PaymentRaise>> GetAllLeadPR();
        Task<bool> DeleteLeadPRById(int id);
    }
}
