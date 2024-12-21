using Models.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Leads
{
    public class Lead
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string SegmentName { get; set; }
        public string groupName { get; set; }
        public string apiType { get; set; } 
        public string accessType { get; set; }  
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
        [BsonElement("Dob")]
        [BsonSerializer(typeof(CustomDateTimeSerializer))]
        public DateTime Dob { get; set; }
        public InvestmentDetail InvestmentDetail { get; set; }
        public string Language { get; set; }
        public FollowupDetail FollowupDetail { get; set; }
    }
}
public class InvestmentDetail
{
    public string Investment { get; set; }
    public string Profile { get; set; }
    public string Trading { get; set; }
    public int Lot { get; set; }
    public string TradingExp { get; set; }
    public string AnnualIncome { get; set; }
    public string InvestmentGoal { get; set; }
    public string MarketValue { get; set; }
    public string MinInvestment { get; set; }
    public string SourceOfIncome { get; set; }
    public string PanNo { get; set; }
    public string UidAadhaar { get; set; }
    public string AmountCapping { get; set; }
}

public class FollowupDetail
{
    public string LeadStatus { get; set; }
    public string Segment { get; set; }
    [BsonElement("FreeTrialStartDate")]
    [BsonSerializer(typeof(CustomDateTimeSerializer))]
    public DateTime FreeTrialStartDate { get; set; }
    [BsonElement("FreeTrialEndDate")]
    [BsonSerializer(typeof(CustomDateTimeSerializer))]
    public DateTime FreeTrialEndDate { get; set; }
    [BsonElement("FollowUpDate")]
    [BsonSerializer(typeof(CustomDateTimeSerializer))]
    public DateTime FollowUpDate { get; set; }
    public string Comment { get; set; }
}

