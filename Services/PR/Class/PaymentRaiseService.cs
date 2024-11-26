using Common;
using Models.Common;
using Models.Leads;
using Models.PR;
using Repository.Common;
using Repository.PR.IClass;
using Repository.Settings.IClass;
using Services.PR.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.PR.Class
{
    public class PaymentRaiseService : IPaymentRaiseService
    {
        private readonly IPaymentRaiseRepository _repository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;
        private readonly IGroupsRepository _groupsRepository;
        public PaymentRaiseService(IPaymentRaiseRepository repository, SequenceGenerator sequenceGenerator, IIdentifierService identifierService, IGroupsRepository groupsRepository)
        {
            _repository = repository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
            _groupsRepository = groupsRepository;
        }

        public async Task<Response> LeadPR(PaymentRaise model, string groupName)
        {

            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(model.apiType, model.accessType, groupName);
                if (isAccessType == true)
                {
                    model.Id = _sequenceGenerator.GetNextSequence("Demos_PR", "DemoPr_Sequence");
                    model.PrId = await GetNextIdentifierAsync();
                    await _repository.LeadPR(model);
                    return new Response { Success = true, Message = "PR added successfully" };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }  
        public async Task<string> GetNextIdentifierAsync()
        {
            long nextIdNumber = _sequenceGenerator.GetNextSequence("Demo_LeadNo", "LeadNo");
            var nextId = $"PR{nextIdNumber:D2}";
            await _identifierService.InsertIdentifierAsync(new InfinixId { Id = nextId });

            return nextId;
        }

        public async Task<Response> GetLeadPRById(int id, string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var user = await _repository.GetLeadPRById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "User not found." };
                    }
                    return new Response { Success = true, Data = user };
                }

                else
                {
                    return new Response { Success = false, Error = "Unauthorize cradential" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> UpdateLeadPRById(PaymentRaise model, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(model.apiType, model.accessType, groupName);
                if (isAccessType == true)
                {
                    await _repository.UpdateLeadPRById(model);
                    return new Response { Success = true, Message = "=Lead Pr updated successfully" };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
                
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> DeleteLeadPRById(int id, string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {

                    var result = await _repository.DeleteLeadPRById(id);
                    if (result)
                    {
                        return new Response { Success = true, Data = "Lead Pr deleted successfully." };
                    }

                    return new Response { Success = false, Error = "Failed to delete the lead Pr." };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
                
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetAllLeadPR(string apiType, string accessType, string groupName)
        {
            var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
            if (isAccessType == true)
            {
                var data = await _repository.GetAllLeadPR();
            return new Response
            {
                Success = true,
                Message = "Data retrieved successfully",
                Error = null,
                Data = data

            };
            }
            else
            {
                return new Response { Success = false, Message = "Unauthorize cradential" };
            }
        }

        
    }
}
