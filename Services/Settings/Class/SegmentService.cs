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

    public class SegmentService : ISegmentService
    {
        private readonly ISegmentRepository _segmentRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public SegmentService(ISegmentRepository segmentRepository, SequenceGenerator sequenceGenerator)
        {
            _segmentRepository = segmentRepository;
            _sequenceGenerator = sequenceGenerator;
        }

        public async Task<Response> InsertSegmentAsync(Segment segment)
        {
            try
            {
                segment.Id = _sequenceGenerator.GetNextSequence("Demo_segment", "segment_Sequence");
                await _segmentRepository.InsertSegmentAsync(segment);
                return new Response { Success = true, Message = "Segment inserted successfully." };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateSegmentByIdAsync(int id, Segment segment)
        {
            try
            {
                segment.Id = id; // Ensure the Id matches
                await _segmentRepository.UpdateSegmentByIdAsync(id, segment);
                return new Response { Success = true, Message = "Segment updated successfully." };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> DeleteSegmentByIdAsync(int id)
        {
            try
            {
                await _segmentRepository.DeleteSegmentByIdAsync(id);
                return new Response { Success = true, Message = "Segment deleted successfully." };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetAllSegmentAsync()
        {
            try
            {
                var segments = await _segmentRepository.GetAllSegmentAsync();
                return new Response { Success = true, Data = segments };
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
                var user = await _segmentRepository.GetSegmentById(id);
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
