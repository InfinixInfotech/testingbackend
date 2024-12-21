using Microsoft.AspNetCore.Http;
using Models.Common;
using Models.Leads;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BulkLeads
{
    public class _BulkLead
    {
        public int Id {  get; set; }
        public string CampaignName { get; set; }
        public string LeadSourceName { get; set; }
        public string SegmentName { get; set; }
        public FileContent CsvLeadFile { get; set; }
        public List<LeadDetail> Leads { get; set; } 
        public class LeadDetail
        {
           public Lead Lead { get; set; }   
        }
    }
}
