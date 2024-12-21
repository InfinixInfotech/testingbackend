using Microsoft.AspNetCore.Http;
using Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BulkLeads
{
    public class _leads
    {
        public string CampaignName { get; set; }
        public string LeadSourceName { get; set; }
        public string SegmentName { get; set; }
        public IFormFile CsvLeadFile { get; set; }
      
    }
}
