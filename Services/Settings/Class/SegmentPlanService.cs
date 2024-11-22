using Common;
using Models.Settings;
using Repository.Settings.IClass;
using Services.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.Class
{
    public class SegmentPlanService : ISegmentPlanService
    {
        private readonly ISegmentPlanRepository _segmentPlanRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public SegmentPlanService(ISegmentPlanRepository segmentPlanRepository, SequenceGenerator sequenceGenerator)
        {
            _segmentPlanRepository = segmentPlanRepository;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<Response> InsertSegmentPlanAsync(SegmentPlan segmentPlan)
        {
            try
            {
                segmentPlan.Id = _sequenceGenerator.GetNextSequence("Demo_segmentPlan", "segmentPlan_Sequence");
                await _segmentPlanRepository.InsertSegmentPlanAsync(segmentPlan);
                return new Response { Success = true, Message = "Segment plan inserted successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateSegmentPlanByIdAsync(int id, SegmentPlan segmentPlan)
        {
            try
            {
                await _segmentPlanRepository.UpdateSegmentPlanByIdAsync(id, segmentPlan);
                return new Response { Success = true, Message = "Segment plan updated successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> DeleteSegmentPlanByIdAsync(int id)
        {
            try
            {
                await _segmentPlanRepository.DeleteSegmentPlanByIdAsync(id);
                return new Response { Success = true, Message = "Segment plan deleted successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetAllSegmentPlanAsync()
        {
            try
            {
                var result = await _segmentPlanRepository.GetAllSegmentPlanAsync();
                return new Response { Success = true, Data = result };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetSegmentById(int id)
        {
            try
            {
                var user = await _segmentPlanRepository.GetSegmentById(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "Segment not found." };
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
