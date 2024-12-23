using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class SegmentPlan
    {
        public int Id { get; set; }
        public string? SegmentName { get; set; }
        public string? Term { get; set; }
        public Amount? Amount { get; set; }

    }
}
public class Amount
{
    public string? Currency { get; set; }
    public int? Value { get; set; }
}

