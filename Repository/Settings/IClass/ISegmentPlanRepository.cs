using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.IClass
{
    public interface ISegmentPlanRepository
    {
        Task InsertSegmentPlanAsync(SegmentPlan segmentPlan);
        Task UpdateSegmentPlanByIdAsync(SegmentPlan segmentPlan);
        Task DeleteSegmentPlanByIdAsync(int id);
        Task<List<SegmentPlan>> GetAllSegmentPlanAsync();
        Task<SegmentPlan> GetSegmentById(int id);
    }
}
