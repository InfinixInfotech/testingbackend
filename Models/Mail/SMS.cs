using Microsoft.AspNetCore.Http;
using Models.Common;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Mail
{
    public class SMS
    {
        private string _createDate;
        public List<string>? To { get; set; }
        public string? From { get; set; }
        public List<string>? CC { get; set; }
        public List<string>? BCC { get; set; }
        public List<string>? EmployeeCode { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public List<IFormFile>? Attachment { get; set; }
        public string? CreateDate
        {
            get => _createDate ?? DateTimeHelper.GetPresentDate();
            set => _createDate = value;
        }

        private string? _createTime;
        public string? CreateTime
        {
            get => _createTime ?? DateTimeHelper.GetPresentTime();
            set => _createTime = value;
        }
        public bool? isImportant {  get; set; } = false;
        public string? Templatetype { get; set; }    
        public List<IFormFile>? PdfFiles { get; set; } 
        public List<IFormFile>? PhotoFiles { get; set; } 
        public SMS()
        {
            PdfFiles = new List<IFormFile>();
            PhotoFiles = new List<IFormFile>();
        }

    }
}
