using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models.Settings;
using Repository.Settings.IClass;
using Services.Settings.IClass;

namespace Services.Settings.Class
{
    public class LeadSourceService : ILeadSourceService
    {
        private readonly ILeadSourceRepository _repository;
        private readonly SequenceGenerator _sequenceGenerator;
        public LeadSourceService(ILeadSourceRepository repository, SequenceGenerator sequenceGenerator)
        {
            _repository = repository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> GetAllAsync()
        {
            var leadSources = await _repository.GetAllAsync();
            return new Response
            {
                Success = true,
                Message = "Data retrieved successfully",
                Error = null,
                Data = leadSources
            };
        }

        public async Task<Response> InsertAsync(LeadSource leadSource)
        {
            leadSource.Id = _sequenceGenerator.GetNextSequence("Demo_leadSource", "DemoleadSource_Sequence");
            if (leadSource == null || string.IsNullOrEmpty(leadSource.LeadSourceValue))
            {
                return new Response
                {
                    Success = false,
                    Error = "Invalid input",
                    Message = null
                };
            }

            await _repository.InsertAsync(leadSource);
            return new Response
            {
                Success = true,
                Message = "LeadSource inserted successfully",
                Error = null
            };
        }

        public async Task<Response> UpdateAsync(LeadSource leadSource)
        {
            var existing = await _repository.GetByIdAsync(leadSource.Id);
            if (existing == null)
            {
                return new Response
                {
                    Success = false,
                    Error = "LeadSource not found",
                    Message = null
                };
            }

            await _repository.UpdateAsync(leadSource);
            return new Response
            {
                Success = true,
                Message = "LeadSource updated successfully",
                Error = null
            };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                return new Response
                {
                    Success = false,
                    Error = "LeadSource not found",
                    Message = null
                };
            }

            await _repository.DeleteAsync(id);
            return new Response
            {
                Success = true,
                Message = "LeadSource deleted successfully",
                Error = null
            };
        }
        public async Task<Response> GetLeadSourceById(int id)
        {
            try
            {
                var user = await _repository.GetByIdAsync(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "Lead Source not found." };
                }
                return new Response { Success = true, Data = user };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
    }
}
