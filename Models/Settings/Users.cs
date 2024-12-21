using Models.Common;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmployeeCode { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Target { get; set; }
        public string ReportingTo { get; set; }
        public string GroupName { get; set; }
        public string GroupId { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string QualificationName { get; set; }
        public Access Access { get; set; }
        public Extension Extension { get; set; }
        public string DIDNumber { get; set; }
        public List<string> SegmentAccess { get; set; }
        public List<string> PoolAccess { get; set; }
        public List<string> GroupAccess { get; set; }
        public List<string> VendorAccess { get; set; }
        public List<string> ExceptVendorAccess { get; set; }
        public List<string> CustomFetch { get; set; }
        public List<FetchedLeads> FetchedLeads { get; set; } = null;
        public string CustomFetchRatio { get; set; }
        public int OTPNumber { get; set; }
        [BsonElement("DateOfBirth")]
        [BsonSerializer(typeof(CustomDateTimeSerializer))]
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Branch { get; set; }
        public string PanNumber { get; set; }
        public string AadharNumber { get; set; }
        public string LocalAddress { get; set; }
        public string PermanentAddress { get; set; }
        public BankDetails BankDetails { get; set; }
        public string EsslID { get; set; }
        public List<string> ChatGroup { get; set; }
    }
}
public class Access
{
    public bool Status { get; set; }
    public bool AllRights { get; set; }
    public bool SalesHead { get; set; }
    public bool NumberHide { get; set; }
    public bool ClickToCall { get; set; }
    public bool ExportPermission { get; set; }
    public bool CustomSMS { get; set; }
    public bool MailBox { get; set; }
    public bool Chat { get; set; }
    public bool Invoice { get; set; }
    public bool Dashboard { get; set; }
    public bool BackDateSO { get; set; }
    public bool PopupDisabled { get; set; }
}

public class Extension
{
    public string CallingExt { get; set; }
}

public class BankDetails
{
    public string BankName { get; set; }
    public string IFSC { get; set; }
    public string AccountNumber { get; set; }
}
public class FetchedLeads
{
    private string _createDate;
    public string FetchedDate { get; set; }
    public int TotalFetchedLeads { get; set; }
}
