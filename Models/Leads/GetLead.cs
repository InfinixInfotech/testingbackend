using Models.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Leads
{
    public class GetLead
    {
        public string LeadId { get; set; }
        public string ClientName { get; set; }
        public string AssignedTo { get; set; }
        public string EmployeeCode { get; set; }
        public string LeadSource { get; set; }
        public string Mobile { get; set; }
        public string AlternateMobile { get; set; }
        public string OtherMobile1 { get; set; }
        public string OtherMobile2 { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Dob { get; set; }
        public string Language { get; set; }
        public FollowupDetail FollowupDetail { get; set; }
    }
}
