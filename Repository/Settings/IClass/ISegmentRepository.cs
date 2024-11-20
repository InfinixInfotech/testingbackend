using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.IClass
{
    public interface ISegmentRepository
    {
        Task InsertSegmentAsync(Segment entity);
        Task UpdateSegmentByIdAsync(int id, Segment entity);
        Task DeleteSegmentByIdAsync(int id);
        Task<List<Segment>> GetAllSegmentAsync();
    }
}
