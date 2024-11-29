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

        public SMSService(ISMSRepository sMSRepository, SequenceGenerator sequenceGenerator, IIdentifierService identifierService, IGroupsRepository groupsRepository)
        {
            _sMSRepository = sMSRepository;
            _sequenceGenerator = sequenceGenerator;
            _identifierService = identifierService;
            _groupsRepository = groupsRepository;
        }
        public async Task<Response> AddSMS(SMS sms, string groupName)
        {

            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(sms.apiType, sms.accessType, groupName);
                if (isAccessType == true)
                {
                    var SMS = new Email
                    {
                        Id = _sequenceGenerator.GetNextSequence("submitkycform", "submitkycform_Sequence"),
                        accessType = sms.accessType,
                        apiType = sms.apiType,
                        From = sms.From,
                        To = sms.To,
                        CC = sms.CC,
                        BCC = sms.BCC,
                        Subject = sms.Subject,
                        Message = sms.Message,
                        Attachment = ProcessFileContents(sms.Attachment),
                        CreateDate = sms.CreateDate,
                        CreateTime = sms.CreateTime,

                    };
                    await _sMSRepository.AddSMS(SMS);
                    return new Response { Success = true, Message = "SMS added successfully" };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }

        }

        public async Task<Response> GetSMSById(int id, string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var user = await _sMSRepository.GetSMSById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "User not found." };
                    }
                    return new Response { Success = true, Data = user };
                }
                else
                {
                    return new Response { Success = false, Error = "Unauthorize cradential" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> UpdateSMSById(Email model, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(model.apiType, model.accessType, groupName);
                if (isAccessType == true)
                {

                    await _sMSRepository.UpdateSMSById(model);
                    return new Response { Success = true, Message = "Lead updated successfully" };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetAllSMS(string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var sMS = await _sMSRepository.GetAllSMS();


                    return new Response { Success = true, Data = sMS };
                }
                else
                {
                    return new Response { Success = true, Message = "Unauthorize cradential" };
                }
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> DeleteSMSById(int id, string apiType, string accessType, string groupName)
        {
            try
            {
                var isAccessType = await _groupsRepository.GetAccessKey(apiType, accessType, groupName);
                if (isAccessType == true)
                {
                    var user = await _sMSRepository.GetSMSById(id);
                    if (user == null)
                    {
                        return new Response { Success = false, Error = "Lead not found." };
                    }

                    var result = await _sMSRepository.DeleteSMSById(id);
                    if (result)
                    {
                        return new Response { Success = true, Data = "Lead deleted successfully." };
                    }

                    return new Response { Success = false, Error = "Failed to delete the lead." };
                }
                else
                {
                    return new Response { Success = false, Message = "Unauthorize cradential" };
                }
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
    }
}
