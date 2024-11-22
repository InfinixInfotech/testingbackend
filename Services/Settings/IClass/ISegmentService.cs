using Common;
using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.IClass
{
    public interface ISegmentService
    {
        Task<Response> InsertSegmentAsync(Segment segment);
        Task<Response> UpdateSegmentByIdAsync(int id, Segment segment);
        Task<Response> DeleteSegmentByIdAsync(int id);
        Task<Response> GetAllSegmentAsync();
        Task<Response> GetSegmentById(int id);
    }
}
