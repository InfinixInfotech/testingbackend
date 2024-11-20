using Common;
using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.IClass
{
    public interface ISegmentPlanService
    {
        Task<Response> InsertSegmentPlanAsync(SegmentPlan segmentPlan);
        Task<Response> UpdateSegmentPlanByIdAsync(int id, SegmentPlan segmentPlan);
        Task<Response> DeleteSegmentPlanByIdAsync(int id);
        Task<Response> GetAllSegmentPlanAsync();
    }
}
