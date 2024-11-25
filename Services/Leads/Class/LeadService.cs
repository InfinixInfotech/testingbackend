using Common;
using Models.Common;
using Models.Leads;
using Repository.Common;
using Repository.Leads.IClass;
using Repository.Settings.IClass;
using Services.Leads.IClass;
//using Microsoft.AspNetCore.Http;
using System.Text;

namespace Services.Leads.Class
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;
        private readonly IGroupsRepository _groupsRepository;

        public LeadService(ILeadRepository leadRepository,SequenceGenerator sequenceGenerator, IIdentifierService identifierService, IGroupsRepository groupsRepository) 
        { 
            _leadRepository = leadRepository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
            _groupsRepository = groupsRepository;
        }
        public async Task<Response> AddLead(Lead lead, string groupName)
        {

            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(lead.apiType, lead.accessType, groupName);
                if (isAccessType == true)
                {
                    var id = _sequenceGenerator.GetNextSequence("Demos_Leads", "DemoLeadss_Sequence");
                    lead.Id = id;
                    lead.LeadId = await GetNextIdentifierAsync();
                    await _leadRepository.AddLead(lead);
                    return new Response { Success = true, Message = "Lead added successfully" };
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
        public async Task<Response> GetLeadById(int id,string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var user = await _leadRepository.GetLeadById(id);
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
        public async Task<Response> UpdateLeadById(Lead model, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(model.apiType, model.accessType, groupName);
                if (isAccessType == true)
                {

                    await _leadRepository.UpdateLeadById(model);
                    return new Response { Success = true, Message = "Lead updated successfully" };
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
        public async Task<Response> GetAllLead(string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var lead = await _leadRepository.GetAllLead();
                    var data = lead.Select(lead => new GetLead
                    {
                        LeadId = lead.LeadId,
                        ClientName = lead.ClientName,
                        AssignedTo = lead.AssignedTo,
                        EmployeeCode = lead.EmployeeCode,
                        LeadSource = lead.LeadSource,
                        Mobile = lead.Mobile,
                        AlternateMobile = lead.AlternateMobile,
                        OtherMobile1 = lead.OtherMobile1,
                        OtherMobile2 = lead.OtherMobile2,
                        Email = lead.Email,
                        City = lead.City,
                        State = lead.State,
                        Dob = lead.Dob,
                        Language = lead.Language,
                        FollowupDetail = lead.FollowupDetail
                    }).ToList();

                    return new Response { Success = true, Data = data };
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
        public async Task<Response> DeleteLeadById(int id, string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var user = await _leadRepository.GetLeadById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "Lead not found." };
                    }

                    var result = await _leadRepository.DeleteLeadById(id);
                    if (result)
                    {
                        return new Response { Success = true, Data = "Lead deleted successfully." };
                    }

                    return new Response { Success = false, Error = "Failed to delete the lead." };
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
            var nextId = $"LED{nextIdNumber:D2}";
            await _identifierService.InsertIdentifierAsync(new InfinixId { Id = nextId });

            return nextId;
        }     
    }
}
