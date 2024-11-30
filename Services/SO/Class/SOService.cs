using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models.Common;
using Models.Leads;
using Models.Settings;
using Models.SO;
using Repository.Common;
using Repository.Leads.Class;
using Repository.Leads.IClass;
using Repository.Settings.Class;
using Repository.Settings.IClass;
using Repository.SO.Class;
using Repository.SO.IClass;
using Services.SO.IClass;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.SO.Class
{
    public class SOService : ISOService
    {
        private readonly ISORepository _repository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;
        private readonly IGroupsRepository _groupsRepository;
        public SOService(ISORepository repository, SequenceGenerator sequenceGenerator, IIdentifierService identifierService, IGroupsRepository groupsRepository)
        {
            _repository = repository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
            _groupsRepository = groupsRepository;
        }
        public async Task<Response> GetAllSO(string apitype , string accessType,string groupName)
        {
            var isAccessType = await _groupsRepository.GetAccessKey(apitype, accessType, groupName);
            if (isAccessType == true)
            {
                var data = await _repository.GetAllSO();
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
                return new Response
                {
                    Success = false,
                    Message = "Unauthorize cradential",
                    Error = null,
                };
            }
        }

        public async Task<Response> InsertSO(So sO, string groupName)
        {
            try
            {
                
                var isAccessType = await _groupsRepository.GetAccessKey(sO.apiType, sO.accessType, groupName);
                if (isAccessType == true)
                {
                    sO.Id = _sequenceGenerator.GetNextSequence("Demo_lead", "Demolead  _Sequence");
                    sO.SoId = await GetNextIdentifierAsync();
                    if (sO == null || string.IsNullOrEmpty(sO.EmployeeCode))
                    {
                        return new Response
                        {
                            Success = false,
                            Error = "Invalid data",
                            Message = null
                        };
                    }
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }

                await _repository.InsertSO(sO);
                return new Response
                {
                    Success = true,
                    Message = "SO inserted successfully",
                    Error = null
                };
            }
            catch
            {
                return new Response { Success = false, Message = "Unauthorize cradential" };
            }
        }
             

        public async Task<Response> UpdateSO(So sO, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(sO.apiType, sO.accessType, groupName);
                if (isAccessType == true)
                {
                    var existing = await _repository.GetByIdAsync(sO.Id);
                    if (existing == null)
                    {
                        await _repository.UpdateSO(sO);
                        return new Response
                        {
                            Success = true,
                            Message = "SO updated successfully",
                            Error = null
                        };
                    }
                    else
                    {
                        return new Response { Success = false, Message = "Unauthorize cradential" };
                    }
                }
                return new Response { Success = false, Message = "Unauthorize cradential" };
            }
            catch
            {
                return new Response { Success = false, Message = "Unauthorize cradential" };
            }
         }

        public async Task<Response> DeleteSO(int id, string apiType, string accessType, string groupName)
        {

            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var existing = await _repository.GetByIdAsync(id);
                    if (existing == null)
                    {
                        return new Response
                        {
                            Success = false,
                            Error = "SO not found",
                            Message = null
                        };
                    }
                    await _repository.DeleteSO(id);
                    return new Response
                    {
                        Success = true,
                        Message = "LeadStatus deleted successfully",
                        Error = null
                    };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
            }
            catch
            {
                return new Response { Success = false, Message = "Unauthorize cradential" };

            }
        }            
        
            
        public async Task<Response> GetSOById(int id, string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var user = await _repository.GetByIdAsync(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "Lead Status not found." };
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
        public async Task<string> GetNextIdentifierAsync()
        {
            long nextIdNumber = _sequenceGenerator.GetNextSequence("Demo_SONo", "SONo");
            var nextId = $"SO{nextIdNumber:D2}";
            await _identifierService.InsertIdentifierAsync(new InfinixId { Id = nextId });

            return nextId;
        }
    }
}
