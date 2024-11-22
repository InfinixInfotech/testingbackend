using Common;
using Models.Common;
using Models.Leads;
using Models.Settings;
using Repository.Common;
using Repository.Leads.IClass;
using Services.Leads.IClass;

namespace Services.Leads.Class
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;
        public LeadService(ILeadRepository leadRepository,SequenceGenerator sequenceGenerator, IIdentifierService identifierService) 
        { 
            _leadRepository = leadRepository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
        }
        public async Task<Response> AddLead(Lead lead)
        {

            try
            {  
                var id = _sequenceGenerator.GetNextSequence("Demos_Leads", "DemoLeadss_Sequence");
                lead.Id = id;
                lead.LeadId = await GetNextIdentifierAsync();
                await _leadRepository.AddLead(lead);
                return new Response { Success = true, Message = "Lead added successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetLeadById(int id)
        {
            try
            {
                var user = await _leadRepository.GetLeadById(id);
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
        public async Task<Response> UpdateLeadById(Lead model)
        {
            try
            {
                await _leadRepository.UpdateLeadById(model);
                return new Response { Success = true, Message = "Lead updated successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetAllLead()
        {
            try
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
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> DeleteLeadById(int id)
        {
            try
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
