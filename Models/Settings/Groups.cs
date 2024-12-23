using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class Groups
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? GroupId { get; set; }
        public Dashboard? Dashboard { get; set; }
        public Leadss? Leads { get; set; }
        public Contact? Contact { get; set; }
        public MutualFund? MutualFund { get; set; }
        public FreeTrial? FreeTrial { get; set; }
        public _SO? SO { get; set; }
        public Compliance? Compliance { get; set; }
        public LeadTemplate? LeadTemplate { get; set; }
        public ClientTemplate? ClientTemplate { get; set; }
        public HRExtra? HRExtra { get; set; }
        public SupportModule? SupportModule { get; set; }
        public TeamMembers? TeamMembers { get; set; }
        public SMSModule? SMSModule { get; set; }
        public CallingModule? CallingModule { get; set; }
        public Reports? Reports { get; set; }
        public Logs? Logs { get; set; }
        public Extra? Extra { get; set; }
        public MIS? MIS { get; set; }
        public Whatsapp? Whatsapp { get; set; }
        public Export? Export { get; set; }
        public int? FreeTrialDays { get; set; }
        public int? FreeTrialPerContact { get; set; }
        public int? TotalCRMLeadLimit { get; set; }
        public LeadFetch? LeadFetch { get; set; }
        public ClientFetch? ClientFetch { get; set; }
        public int? UnreadFetch { get; set; }
    }
}
public class Dashboard
{
    [DefaultValue(false)]
    public bool? SalesDashboard { get; set; } = false;
    [DefaultValue(false)]
    public bool? CallingDashboard { get; set; } = false;
}

public class Leadss
{
    [DefaultValue(false)]
    public bool? Create { get; set; } = false;
    [DefaultValue(false)]
    public bool? View { get; set; } = false;
    [DefaultValue(false)]
    public bool? MarketingLeads { get; set; } = false;
    [DefaultValue(false)]
    public bool? Edit { get; set; } = false;
    [DefaultValue(false)]
    public bool? Delete { get; set; } = false;
    [DefaultValue(false)]
    public bool? Dispose { get; set; } = false;
    [DefaultValue(false)]
    public bool? DisposeClients { get; set; } = false;
    [DefaultValue(false)]
    public bool? Upload { get; set; } = false;
    [DefaultValue(false)]
    public bool? InternalAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? OuterAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? GlobalAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? ViewFollowUp { get; set; } = false;
    [DefaultValue(false)]
    public bool? DeleteFollowUp { get; set; } = false;
    [DefaultValue(false)]
    public bool? FollowAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? BulkLeadOperation { get; set; } = false;
    [DefaultValue(false)]
    public bool? LeadAction { get; set; } = false;
    [DefaultValue(false)]
    public bool? LeadActionAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? CreateAgreement { get; set; } = false;
    [DefaultValue(false)]
    public bool? AddRPM { get; set; } = false;
}

public class Contact
{
    [DefaultValue(false)]
    public bool? Create { get; set; } = false;
    [DefaultValue(false)]
    public bool? View { get; set; } = false;
    [DefaultValue(false)]
    public bool? ContactAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? ContactAction { get; set; } = false;
    [DefaultValue(false)]
    public bool? ContactActionAssign { get; set; } = false;
}

public class MutualFund
{
    [DefaultValue(false)]
    public bool? Create { get; set; } = false;
    [DefaultValue(false)]
    public bool? View { get; set; } = false;
    [DefaultValue(false)]
    public bool? MutualFundAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? MutualFundAction { get; set; } = false;
    [DefaultValue(false)]
    public bool? MutualFundActionAssign { get; set; } = false;
}

public class FreeTrial
{
    [DefaultValue(false)]
    public bool? Create { get; set; } = false;
    [DefaultValue(false)]
    public bool? View { get; set; } = false;
    [DefaultValue(false)]
    public bool? Edit { get; set; } = false;
    [DefaultValue(false)]
    public bool? OuterAssign { get; set; } = false;
}

public class _SO
{
    [DefaultValue(false)]
    public bool? Create { get; set; } = false;
    [DefaultValue(false)]
    public bool? View { get; set; } = false;
    [DefaultValue(false)]
    public bool? Edit { get; set; } = false;
    [DefaultValue(false)]
    public bool? ApproveSO { get; set; } = false;
    [DefaultValue(false)]
    public bool? Invoice { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaymentPortal { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaymentApproval { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaymentEdit { get; set; } = false;
    [DefaultValue(false)]
    public bool? Delete { get; set; } = false;
    [DefaultValue(false)]
    public bool? ServiceActivation { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaidClientAssign { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaidClientAction { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaidClientActionAssign { get; set; } = false;
}

public class Compliance
{
    [DefaultValue(false)]
    public bool? KYC { get; set; } = false;
    [DefaultValue(false)]
    public bool? RiskProfile { get; set; } = false;
    [DefaultValue(false)]
    public bool? Agreement { get; set; } = false;
    [DefaultValue(false)]
    public bool? AgreementApproved { get; set; } = false;
    [DefaultValue(false)]
    public bool? ViewRPM { get; set; } = false;
    [DefaultValue(false)]
    public bool? EditRPM { get; set; } = false;
    [DefaultValue(false)]
    public bool? Invoice { get; set; } = false;
    [DefaultValue(false)]
    public bool? SOReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? TaxReport { get; set; } = false;
}

public class LeadTemplate
{
    [DefaultValue(false)]
    public bool? SendSMSLead { get; set; } = false;
    [DefaultValue(false)]
    public bool? SendWhatsappLead { get; set; } = false;
    [DefaultValue(false)]
    public bool? SendEmailLead { get; set; } = false;
}

public class ClientTemplate
{
    [DefaultValue(false)]
    public bool? SendSMSClient { get; set; } = false;
    [DefaultValue(false)]
    public bool? SendWhatsappClient { get; set; } = false;
    [DefaultValue(false)]
    public bool? SendEmailClient { get; set; } = false;
}

public class HRExtra
{
    [DefaultValue(false)]
    public bool? ORGChart { get; set; } = false;
    [DefaultValue(false)]
    public bool? ScrapBook { get; set; } = false;
    [DefaultValue(false)]
    public bool? Holiday { get; set; } = false;
}

public class SupportModule
{
    [DefaultValue(false)]
    public bool? ITAdmin { get; set; } = false;
    [DefaultValue(false)]
    public bool? HRAdmin { get; set; } = false;
    [DefaultValue(false)]
    public bool? ComplianceAdmin { get; set; } = false;
    [DefaultValue(false)]
    public bool? Admin { get; set; } = false;
}

public class TeamMembers
{
    [DefaultValue(false)]
    public bool? List { get; set; } = false;
    [DefaultValue(false)]
    public bool? Data { get; set; } = false;
}

public class SMSModule
{
    [DefaultValue(false)]
    public bool? SendSMS { get; set; } = false;
    [DefaultValue(false)]
    public bool? ViewSMS { get; set; } = false;
}

public class CallingModule
{
    [DefaultValue(false)]
    public bool? Monitoring { get; set; } = false;
    [DefaultValue(false)]
    public bool? Reports { get; set; } = false;
    [DefaultValue(false)]
    public bool? SendSMSViaGateway { get; set; } = false;
    [DefaultValue(false)]
    public bool? ViewSMSViaGateway { get; set; } = false;
    [DefaultValue(false)]
    public bool? MissCall { get; set; } = false;
    [DefaultValue(false)]
    public bool? LiveCall { get; set; } = false;
}

public class Reports
{
    [DefaultValue(false)]
    public bool? GeneralReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? FTReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? PaidClientReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? ExpiredPaidClientReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? UserReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? CallingReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? MessageReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? SMSReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? DNDReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? Tracksheet { get; set; } = false;
    [DefaultValue(false)]
    public bool? ResearchReport { get; set; } = false;
} 

public class Logs
{
    [DefaultValue(false)]
    public bool? Client { get; set; } = false;
    [DefaultValue(false)]
    public bool? SMS { get; set; } = false;
    [DefaultValue(false)]
    public bool? Chat { get; set; } = false;
    [DefaultValue(false)]
    public bool? Whatsapp { get; set; } = false;
    [DefaultValue(false)]
    public bool? Login { get; set; } = false;
    [DefaultValue(false)]
    public bool? Extension { get; set; } = false;
}

public class Extra
{
    [DefaultValue(false)]
    public bool? CallingModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? UserModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? GroupModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? PoolsModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? LeadStatusModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? SegmentModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? SOModule { get; set; } = false;
    [DefaultValue(false)]
    public bool? FetchingReport { get; set; } = false;
    [DefaultValue(false)]
    public bool? MailDelete { get; set; } = false;
    [DefaultValue(false)]
    public bool? Forecast { get; set; } = false;
    [DefaultValue(false)]
    public bool? Brokerage { get; set; } = false;
    [DefaultValue(false)]
    public bool? LiveUpdates { get; set; } = false;
    [DefaultValue(false)]
    public bool? Policy { get; set; } = false;
    [DefaultValue(false)]
    public bool? LeadApproval { get; set; } = false;
    [DefaultValue(false)]
    public bool? GroupDesignation { get; set; } = false;
    [DefaultValue(false)]
    public bool? GroupDepartment { get; set; } = false;
    [DefaultValue(false)]
    public bool? GroupHierarchy { get; set; } = false;
    [DefaultValue(false)]
    public bool? CustomSMS { get; set; } = false;
    [DefaultValue(false)]
    public bool? Notification { get; set; } = false;
    [DefaultValue(false)]
    public bool? NotificationUpdate { get; set; } = false;
    [DefaultValue(false)]
    public bool? LeaderDashboardUpdate { get; set; } = false;
    [DefaultValue(false)]
    public bool? GroupChat { get; set; } = false;
}

public class MIS
{
    [DefaultValue(false)]
    public bool? Employee { get; set; } = false;
    [DefaultValue(false)]
    public bool? Lead { get; set; } = false;
    [DefaultValue(false)]
    public bool? Client { get; set; } = false;
    [DefaultValue(false)]
    public bool? Sales { get; set; } = false;
    [DefaultValue(false)]
    public bool? DisposeLeads { get; set; } = false;
    [DefaultValue(false)]
    public bool? PreSales { get; set; } = false;
}

public class Whatsapp
{
    [DefaultValue(false)]
    public bool? ShowWhatsapp { get; set; } = false;
    [DefaultValue(false)]
    public bool? SendAttachment { get; set; } = false;
}

public class Export
{
    [DefaultValue(false)]
    public bool? Leads { get; set; } = false;
    [DefaultValue(false)]
    public bool? Contacts { get; set; } = false;
    [DefaultValue(false)]
    public bool? FreeTrial { get; set; } = false;
    [DefaultValue(false)]
    public bool? FollowUp { get; set; } = false;
    [DefaultValue(false)]
    public bool? Clients { get; set; } = false;
    [DefaultValue(false)]
    public bool? SalesOrder { get; set; } = false;
    [DefaultValue(false)]
    public bool? SMSLogs { get; set; } = false;
    [DefaultValue(false)]
    public bool? ChatLogs { get; set; } = false;
}

public class LeadFetch
{
    [DefaultValue(false)]
    public bool? Active { get; set; } = false;
    public List<string>? From { get; set; } 
    public string? Ratio { get; set; }
}

public class ClientFetch
{
    [DefaultValue(false)]
    public bool? Active { get; set; } = false;
    public List<string>? From { get; set; }
    public string? Ratio { get; set; }
}




