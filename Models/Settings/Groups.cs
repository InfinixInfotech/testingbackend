using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class Groups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public Dashboard Dashboard { get; set; }
        public Leadss Leads { get; set; }
        public Contact Contact { get; set; }
        public MutualFund MutualFund { get; set; }
        public FreeTrial FreeTrial { get; set; }
        public _SO SO { get; set; }
        public Compliance Compliance { get; set; }
        public LeadTemplate LeadTemplate { get; set; }
        public ClientTemplate ClientTemplate { get; set; }
        public HRExtra HRExtra { get; set; }
        public SupportModule SupportModule { get; set; }
        public TeamMembers TeamMembers { get; set; }
        public SMSModule SMSModule { get; set; }
        public CallingModule CallingModule { get; set; }
        public Reports Reports { get; set; }
        public Logs Logs { get; set; }
        public Extra Extra { get; set; }
        public MIS MIS { get; set; }
        public Whatsapp Whatsapp { get; set; }
        public Export Export { get; set; }
        public int FreeTrialDays { get; set; }
        public int FreeTrialPerContact { get; set; }
        public int TotalCRMLeadLimit { get; set; }
        public LeadFetch LeadFetch { get; set; }
        public ClientFetch ClientFetch { get; set; }
        public int UnreadFetch { get; set; }
    }
}
public class Dashboard
{
    public bool SalesDashboard { get; set; }
    public bool CallingDashboard { get; set; }
}

public class Leadss
{
    public bool Create { get; set; }
    public bool View { get; set; }
    public bool MarketingLeads { get; set; }
    public bool Edit { get; set; }
    public bool Delete { get; set; }
    public bool Dispose { get; set; }
    public bool DisposeClients { get; set; }
    public bool Upload { get; set; }
    public bool InternalAssign { get; set; }
    public bool OuterAssign { get; set; }
    public bool GlobalAssign { get; set; }
    public bool ViewFollowUp { get; set; }
    public bool DeleteFollowUp { get; set; }
    public bool FollowAssign { get; set; }
    public bool BulkLeadOperation { get; set; }
    public bool LeadAction { get; set; }
    public bool LeadActionAssign { get; set; }
    public bool CreateAgreement { get; set; }
    public bool AddRPM { get; set; }
}

public class Contact
{
    public bool Create { get; set; }
    public bool View { get; set; }
    public bool ContactAssign { get; set; }
    public bool ContactAction { get; set; }
    public bool ContactActionAssign { get; set; }
}

public class MutualFund
{
    public bool Create { get; set; }
    public bool View { get; set; }
    public bool MutualFundAssign { get; set; }
    public bool MutualFundAction { get; set; }
    public bool MutualFundActionAssign { get; set; }
}

public class FreeTrial
{
    public bool Create { get; set; }
    public bool View { get; set; }
    public bool Edit { get; set; }
    public bool OuterAssign { get; set; }
}

public class _SO
{
    public bool Create { get; set; }
    public bool View { get; set; }
    public bool Edit { get; set; }
    public bool ApproveSO { get; set; }
    public bool Invoice { get; set; }
    public bool PaymentPortal { get; set; }
    public bool PaymentApproval { get; set; }
    public bool PaymentEdit { get; set; }
    public bool Delete { get; set; }
    public bool ServiceActivation { get; set; }
    public bool PaidClientAssign { get; set; }
    public bool PaidClientAction { get; set; }
    public bool PaidClientActionAssign { get; set; }
}

public class Compliance
{
    public bool KYC { get; set; }
    public bool RiskProfile { get; set; }
    public bool Agreement { get; set; }
    public bool AgreementApproved { get; set; }
    public bool ViewRPM { get; set; }
    public bool EditRPM { get; set; }
    public bool Invoice { get; set; }
    public bool SOReport { get; set; }
    public bool TaxReport { get; set; }
}

public class LeadTemplate
{
    public bool SendSMSLead { get; set; }
    public bool SendWhatsappLead { get; set; }
    public bool SendEmailLead { get; set; }
}

public class ClientTemplate
{
    public bool SendSMSClient { get; set; }
    public bool SendWhatsappClient { get; set; }
    public bool SendEmailClient { get; set; }
}

public class HRExtra
{
    public bool ORGChart { get; set; }
    public bool ScrapBook { get; set; }
    public bool Holiday { get; set; }
}

public class SupportModule
{
    public bool ITAdmin { get; set; }
    public bool HRAdmin { get; set; }
    public bool ComplianceAdmin { get; set; }
    public bool Admin { get; set; }
}

public class TeamMembers
{
    public bool List { get; set; }
    public bool Data { get; set; }
}

public class SMSModule
{
    public bool SendSMS { get; set; }
    public bool ViewSMS { get; set; }
}

public class CallingModule
{
    public bool Monitoring { get; set; }
    public bool Reports { get; set; }
    public bool SendSMSViaGateway { get; set; }
    public bool ViewSMSViaGateway { get; set; }
    public bool MissCall { get; set; }
    public bool LiveCall { get; set; }
}

public class Reports
{
    public bool GeneralReport { get; set; }
    public bool FTReport { get; set; }
    public bool PaidClientReport { get; set; }
    public bool ExpiredPaidClientReport { get; set; }
    public bool UserReport { get; set; }
    public bool CallingReport { get; set; }
    public bool MessageReport { get; set; }
    public bool SMSReport { get; set; }
    public bool DNDReport { get; set; }
    public bool Tracksheet { get; set; }
    public bool ResearchReport { get; set; }
}

public class Logs
{
    public bool Client { get; set; }
    public bool SMS { get; set; }
    public bool Chat { get; set; }
    public bool Whatsapp { get; set; }
    public bool Login { get; set; }
    public bool Extension { get; set; }
}

public class Extra
{
    public bool CallingModule { get; set; }
    public bool UserModule { get; set; }
    public bool GroupModule { get; set; }
    public bool PoolsModule { get; set; }
    public bool LeadStatusModule { get; set; }
    public bool SegmentModule { get; set; }
    public bool SOModule { get; set; }
    public bool FetchingReport { get; set; }
    public bool MailDelete { get; set; }
    public bool Forecast { get; set; }
    public bool Brokerage { get; set; }
    public bool LiveUpdates { get; set; }
    public bool Policy { get; set; }
    public bool LeadApproval { get; set; }
    public bool GroupDesignation { get; set; }
    public bool GroupDepartment { get; set; }
    public bool GroupHierarchy { get; set; }
    public bool CustomSMS { get; set; }
    public bool Notification { get; set; }
    public bool NotificationUpdate { get; set; }
    public bool LeaderDashboardUpdate { get; set; }
    public bool GroupChat { get; set; }
}

public class MIS
{
    public bool Employee { get; set; }
    public bool Lead { get; set; }
    public bool Client { get; set; }
    public bool Sales { get; set; }
    public bool DisposeLeads { get; set; }
    public bool PreSales { get; set; }
}

public class Whatsapp
{
    public bool ShowWhatsapp { get; set; }
    public bool SendAttachment { get; set; }
}

public class Export
{
    public bool Leads { get; set; }
    public bool Contacts { get; set; }
    public bool FreeTrial { get; set; }
    public bool FollowUp { get; set; }
    public bool Clients { get; set; }
    public bool SalesOrder { get; set; }
    public bool SMSLogs { get; set; }
    public bool ChatLogs { get; set; }
}

public class LeadFetch
{
    public bool Active { get; set; }
    public List<string> From { get; set; }
    public string Ratio { get; set; }
}

public class ClientFetch
{
    public bool Active { get; set; }
    public List<string> From { get; set; }
    public string Ratio { get; set; }
}    


