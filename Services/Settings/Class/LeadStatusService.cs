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
    public class LeadStatusService : ILeadStatusService
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public LeadStatusService(ILeadStatusRepository leadStatusRepository, SequenceGenerator sequenceGenerator)
        {
            _leadStatusRepository = leadStatusRepository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> GetAllAsync()
        {
            var data = await _leadStatusRepository.GetAllAsync();
            return new Response
            {
                Success = true,
                Message = "Data retrieved successfully",
                Error = null,
                Data = data
                
            };
        }

        public async Task<Response> InsertAsync(LeadStatus leadStatus)
        {
            leadStatus.Id = _sequenceGenerator.GetNextSequence("Demo_lead", "Demolead  _Sequence");
            if (leadStatus == null || string.IsNullOrEmpty(leadStatus.Status))
            {
                return new Response
                {
                    Success = false,
                    Error = "Invalid data",
                    Message = null
                };
            }

            await _leadStatusRepository.InsertAsync(leadStatus);
            return new Response
            {
                Success = true,
                Message = "LeadStatus inserted successfully",
                Error = null
            };
        }

        public async Task<Response> UpdateAsync(int id, LeadStatus leadStatus)
        {
            var existing = await _leadStatusRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return new Response
                {
                    Success = false,
                    Error = "LeadStatus not found",
                    Message = null
                };
            }

            await _leadStatusRepository.UpdateByIdAsync(id,leadStatus);
            return new Response
            {
                Success = true,
                Message = "LeadStatus updated successfully",
                Error = null
            };
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var existing = await _leadStatusRepository.GetByIdAsync(id);
            if (existing == null)
            {
                return new Response
                {
                    Success = false,
                    Error = "LeadStatus not found",
                    Message = null
                };
            }

            await _leadStatusRepository.DeleteAsync(id);
            return new Response
            {
                Success = true,
                Message = "LeadStatus deleted successfully",
                Error = null
            };


        }
    }
}
