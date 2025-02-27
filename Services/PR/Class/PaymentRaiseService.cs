﻿using Common;
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

        public async Task<Response> LeadPR(PaymentRaise model)
        {

            try
            {
               
                    model.Id = _sequenceGenerator.GetNextSequence("Demos_PR", "DemoPr_Sequence");
                    model.PrId = await GetNextIdentifierAsync();
                    await _repository.LeadPR(model);
                    return new Response { Success = true, Message = "PR added successfully" };
               
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

        public async Task<Response> GetLeadPRById(int id)
        {
            try
            {
                
                    var user = await _repository.GetLeadPRById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "User not found." };
                    }
                    return new Response { Success = true, Data = user };
              
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> UpdateLeadPRById(PaymentRaise model)
        {
            try
            {
               
                    await _repository.UpdateLeadPRById(model);
                    return new Response { Success = true, Message = "Lead Pr updated successfully" };
              
                
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> DeleteLeadPRById(int id)
        {
            try
            {
                
                    var result = await _repository.DeleteLeadPRById(id);
                    if (result)
                    {
                        return new Response { Success = true, Data = "Lead Pr deleted successfully." };
                    }

                    return new Response { Success = false, Error = "Failed to delete the lead Pr." };
                
                
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetAllLeadPR()
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
    }
}
