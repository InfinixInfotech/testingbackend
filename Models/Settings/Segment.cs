using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class Segment
    {
        public int Id { get; set; }
        public string? SegmentName { get; set; }
        public string? TradeSegmentName { get; set; }
        public string? SegmentType { get; set; }
        public string? SegmentCategory { get; set; }
        public bool? HighRisk { get; set; }
        public bool? Status { get; set; }

    }
}
