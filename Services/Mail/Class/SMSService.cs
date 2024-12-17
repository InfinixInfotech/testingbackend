using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Http;
using Models.Common;
using Models.Leads;
using Models.Mail;
using Repository.Common;
using Repository.Leads.Class;
using Repository.Leads.IClass;
using Repository.Mail.IClass;
using Repository.Settings.IClass;
using Services.Mail.IClass;

namespace Services.Mail.Class
{
    public class SMSService : ISMSService
    {
        private readonly ISMSRepository _sMSRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        private readonly IIdentifierService _identifierService;
        private readonly IGroupsRepository _groupsRepository;
        private readonly IUsersRepository _usersRepository;

        public SMSService(ISMSRepository sMSRepository, SequenceGenerator sequenceGenerator, IIdentifierService identifierService, IGroupsRepository groupsRepository,IUsersRepository usersRepository)
        {
            _sMSRepository = sMSRepository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
            _groupsRepository = groupsRepository;
            _usersRepository = usersRepository;
        }
        public async Task<Response> AddSMS(SMS sms)
        {
            try
            {
                
                List<string> recipientListTo = new List<string>();
                List<string> recipientListCC = new List<string>();
                List<string> recipientListBCC = new List<string>();
                if (sms.To is List<string> recipientEmails)
                {
                    foreach (var recipient in recipientEmails)
                    {
                        var emailList = await GetRecipientList(recipient);
                        recipientListTo.AddRange(emailList);
                    }
                }
                else if (sms.To is List<string> singleRecipient)
                {
                    var emailList = await GetRecipientList(singleRecipient.ToString());
                    recipientListTo.AddRange(emailList);
                }
                if (sms.CC is List<string> recipientCC)
                {
                    foreach (var recipient in recipientCC)
                    {
                        var emailList = await GetRecipientList(recipient);
                        recipientListCC.AddRange(emailList);
                    }
                }
                else if (sms.CC is List<string> singleCC)
                {
                    var emailList = await GetRecipientList(singleCC.ToString());
                    recipientListCC.AddRange(emailList);
                }
                if (sms.BCC is List<string> recipientBCC)
                {
                    foreach (var recipient in recipientBCC)
                    {
                        var emailList = await GetRecipientList(recipient);
                        recipientListBCC.AddRange(emailList);
                    }
                }
                else if (sms.BCC is List<string> singleBCC)
                {
                    var emailList = await GetRecipientList(singleBCC.ToString());
                    recipientListBCC.AddRange(emailList);
                }
                var employeeCodeList = recipientListTo
           .Concat(recipientListCC)
           .Concat(recipientListBCC)
           .Distinct()  
           .ToList();
                
                var email = new Email
                {
                    Id = _sequenceGenerator.GetNextSequence("submitSMS", "submitSMS_Sequence"),
                    From = sms.From,
                    To = recipientListTo,  
                    CC = recipientListCC,  
                    BCC = recipientListBCC,  
                    EmployeeCode = employeeCodeList,
                    Subject = sms.Subject,
                    Message = sms.Message,
                    Attachment = ProcessFileContents(sms.Attachment),
                    CreateDate = DateTime.Now.ToString("dd-MM-yyyy"),
                    CreateTime = DateTime.Now.ToString("hh:mm tt"),
                    isImportant = sms.isImportant,
                    Templatetype = sms.Templatetype,
                    PdfFiles = ProcessFileContents(sms.PdfFiles),
                    PhotoFiles = ProcessFileContents(sms.PhotoFiles),
                };
                await _sMSRepository.AddSMS(email);

                return new Response { Success = true, Message = "SMS added successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetSMSById(int id)
        {
            try
            {
                
                    var user = await _sMSRepository.GetSMSById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "User not found." };
                    }
                    return new Response { Success = true, Data = user };
               
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateSMSById(Email model)
        {
            try
            {
                    await _sMSRepository.UpdateSMSById(model);
                    return new Response { Success = true, Message = "SMS updated successfully" };
               
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetAllSMS()
        {
            try
            {
                    var sMS = await _sMSRepository.GetAllSMS();
                    return new Response { Success = true, Data = sMS };
                
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> DeleteSMSById(int id)
        {
            try
            {
              var user = await _sMSRepository.GetSMSById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "SMS not found." };
                    }

                    var result = await _sMSRepository.DeleteSMSById(id);
                    if (result)
                    {
                        return new Response { Success = true, Data = "SMS deleted successfully." };
                    }

                    return new Response { Success = false, Error = "Failed to delete the SMS." };            
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }

        }
        private List<FileContent> ProcessFileContents(List<IFormFile> files)
        {
            if (files == null || !files.Any()) return null;

            var processedFiles = new List<FileContent>();
            foreach (var file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);
                    processedFiles.Add(new FileContent
                    {
                        FileName = file.FileName,
                        FileData = memoryStream.ToArray(),
                        ContentType = file.ContentType
                    });
                }
            }

            return processedFiles;
        }
        private async Task<List<string>> GetRecipientList(string recipient)
        {
            if (recipient.Contains("INF") && recipient.Length >= 9)
            {
                return new List<string> { recipient };
            }
            else
            {
                return  _usersRepository.GetEmployeeCredentialsByGroupId(recipient);
            }
        }
        public async Task<Response> GetAllSMSByEmployeeCode(string employeeCode)
        {
            try
            {
                // Call the repository to get emails by employee code
                var emails = await _sMSRepository.GetAllSMSByEmployeeCode(employeeCode);

                // Check if any emails were found
                if (emails == null || emails.Count == 0)
                {
                    return new Response
                    {
                        Success = false,
                        Message = "No messages found for the given Employee Code."
                    };
                }

                var result = emails.Select(email => new
                {
                    email.Id,
                    email.Subject,
                    email.Message,
                    email.CreateDate,
                    email.CreateTime,
                    Attachment = email.Attachment?.Select(a => new
                    {
                        FileName = a.FileName,
                        ContentType = a.ContentType,
                        FileData = a.FileData 
                    }).ToList()
                }).ToList();


                return new Response
                {
                    Success = true,
                    Message = "Messages retrieved successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = "An error occurred while fetching messages.",
                    Error = ex.Message
                };
            }
        }
        public async Task<Response> GetAllSMSByisImportant(bool isimportant)
        {
            try
            {
                // Call the repository to get emails by employee code
                var emails = await _sMSRepository.GetAllSMSByisImportant(isimportant);

                var result = emails.Select(email => new
                {
                    email.Id,
                    email.Subject,
                    email.To,
                    email.From,
                    email.CreateDate,
                    email.CreateTime,
                    email.Templatetype,
                }).ToList();


                return new Response
                {
                    Success = true,
                    Message = "Messages retrieved successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Success = false,
                    Message = "An error occurred while fetching messages.",
                    Error = ex.Message
                };
            }
        }
    }
}
