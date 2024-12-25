using Common;
using CsvHelper.Configuration;
using CsvHelper;
using Microsoft.AspNetCore.Http;
using Models.BulkLeads;
using Models.Common;
using Models.Mail;
using Repository.BulkLead.IClass;
using Repository.SO.Class;
using Services.BulkLead.IClass;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Common;
using Repository.Login.IClass;
using Repository.Settings.IClass;
using Models.Login;
using MongoDB.Driver;
using Models.Leads;
using Repository.Settings.Class;


namespace Services.BulkLead.Class
{
    public class BulkLeadService : IBulkLeadService
    {
        private readonly IBulkLeadRepository _bulkLeadRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;
        private readonly IUsersRepository _userRepository;

        public BulkLeadService(IBulkLeadRepository bulkLeadRepository, SequenceGenerator sequenceGenerator,IIdentifierService identifierService, IUsersRepository userRepository) 
        {
            _bulkLeadRepository = bulkLeadRepository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
            _userRepository = userRepository;
        }

        public async Task<Response> BulkLeadUpload(_leads bulkLead)
        {
            try
            {
                var fileContent = await ConvertToFileContent(bulkLead.CsvLeadFile);
                var leads = await ProcessCsvFile(fileContent, bulkLead.LeadSourceName,bulkLead.SegmentName, bulkLead.CampaignName);
                var bulkLeads = new _BulkLead
                {
                    Id = _sequenceGenerator.GetNextSequence("submitBulkLead", "submitBulkLead_Sequence"),
                    CampaignName = bulkLead.CampaignName,
                    LeadSourceName = bulkLead.LeadSourceName,
                    SegmentName = bulkLead.SegmentName,
                    Leads = leads
                };
                await _bulkLeadRepository.AddBulkLeads(bulkLeads);

                return new Response
                {
                    Success = true,
                    Message = $"{leads.Count} leads have been successfully uploaded to the database."
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Error = ex.Message
                };
            }
        }

        private async Task<FileContent> ConvertToFileContent(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                return new FileContent
                {
                    FileName = file.FileName,
                    FileData = memoryStream.ToArray()
                };
            }
        }

        private async Task<List<_BulkLead.LeadDetail>> ProcessCsvFile(FileContent fileContent, string leadSourceName, string SegmentName , string CampaignName)
        {
            var leads = new List<_BulkLead.LeadDetail>();

            using (var reader = new StreamReader(new MemoryStream(fileContent.FileData)))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Map CSV columns to LeadDetail fields
                csv.Context.RegisterClassMap<LeadDetailMap>();

                // Get records from the CSV file
                var records = csv.GetRecords<_BulkLead.LeadDetail>();
                foreach (var record in records)
                {
                    // Assign LeadSource and generate LeadId dynamically
                    record.Lead.LeadSource = leadSourceName;
                    record.Lead.LeadId = await GetNextIdentifierAsync();
                    record.Lead.SegmentName = SegmentName;
                    record.Lead.CampaignName = CampaignName;

                    leads.Add(record);
                }
            }

            return leads;
        }

        public sealed class LeadDetailMap : ClassMap<_BulkLead.LeadDetail>
        {
            public LeadDetailMap()
            {
                Map(m => m.Lead.ClientName).Name("Name");
                Map(m => m.Lead.Mobile).Name("Contact");
                
            }
        }
        public async Task<string> GetNextIdentifierAsync()
        {
            long nextIdNumber = _sequenceGenerator.GetNextSequence("Demo_LeadNo", "LeadNo");
            var nextId = $"LEAD{nextIdNumber:D2}";
            await _identifierService.InsertIdentifierAsync(new InfinixId { Id = nextId });

            return nextId;
        }

        public async Task<Response> CustomeFetchLeads(string EmployeeCode, string CampaignName)
        {
            var CustomFetchRatio = await _userRepository.GetCustomFetchRatioByEmpCode(EmployeeCode);
            var ratioParts = CustomFetchRatio.Split(':');
            if (ratioParts.Length != 2 || !int.TryParse(ratioParts[0], out int a) || !int.TryParse(ratioParts[1], out int b))
            {
                return new Response { Success = false, Error = "Invalid Custom Fetch Ratio format." };
            }
            var result = new
            {
                CustomFetch = a,
                CustomRatio = b
            };
            var user = await _userRepository.GetUserByEmployeeCodeAsync(EmployeeCode);
            int count = 0;
            string currentDate = DateTime.Now.ToString("dd-MM-yyyy");
            var FetchedDate = await _userRepository.GetFetchDateByEmployeeCode(EmployeeCode);
            int totalFetchedLeads = await _userRepository.GetTotalFetchedLeadsByDateAsync(EmployeeCode, currentDate);         
            if(string.IsNullOrEmpty(FetchedDate) || currentDate != FetchedDate.ToString()) 
            {
                var newFetchedLead = new FetchedLeads
                {
                    FetchedDate = currentDate,
                    TotalFetchedLeads = 0
                };
                await _userRepository.AddFetchedLeadAsync(EmployeeCode, newFetchedLead);
                FetchedDate = await _userRepository.GetFetchDateByEmployeeCode(EmployeeCode);
                if (currentDate == FetchedDate.ToString())
                {

                    if (result.CustomFetch >= totalFetchedLeads)
                    {
                        count = result.CustomFetch - totalFetchedLeads;
                        if (count >= result.CustomRatio)
                        {
                            totalFetchedLeads += result.CustomRatio;
                            await _userRepository.UpdateTotalFetchedLeadsAsync(EmployeeCode, FetchedDate, totalFetchedLeads);
                            var lead = await _bulkLeadRepository.UpdateTopLeadsByCampaignNameAsync(CampaignName, result.CustomRatio, EmployeeCode);
                            return new Response { Success = true, Data = lead };
                        }
                    }

                }
            }
            else if (currentDate == FetchedDate.ToString())
            {

                if (result.CustomFetch >= totalFetchedLeads)
                {
                    count = result.CustomFetch - totalFetchedLeads;
                    if (count >= result.CustomRatio)
                    {
                        totalFetchedLeads += result.CustomRatio;
                        await _userRepository.UpdateTotalFetchedLeadsAsync(EmployeeCode, currentDate, totalFetchedLeads);
                        var lead = await _bulkLeadRepository.UpdateTopLeadsByCampaignNameAsync(CampaignName, result.CustomRatio, EmployeeCode);
                        return new Response { Success = true, Data = lead };
                    }
                }
            }
            return new Response { Success = false };
        }
        public async Task<Response> GetLeadByEmployeeCode(string employeeCode , string CampaignName)
        {
            try
            {
                var user = await _bulkLeadRepository.GetLeadsByEmployeeCodeAndCampaignAsync(employeeCode, CampaignName);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "Leads not found." };
                    }
                    return new Response { Success = true, Data = user };
               
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> UpdateLeadById(Lead model)
        {
            var success = await _bulkLeadRepository.UpdateLeadById(model);
            return new Response
            {
                Success = success,
                Message = success ? "Lead updated successfully." : "Failed to update lead."
            };
        }

    }
}
