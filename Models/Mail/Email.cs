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
    public class Email
    {
       
        public int Id { get; set; }
        public List<string> To { get; set; }
        public string From { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public List<string> EmployeeCode { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<FileContent>? Attachment { get; set; }
        [BsonElement("CreateDate")]
        [BsonSerializer(typeof(CustomDateTimeSerializer))]
        public DateTime CreateDate { get; set; }
        [BsonElement("CreateTime")]
        [BsonSerializer(typeof(CustomTimeSerializer))]
        public DateTime CreateTime { get; set; }
        public bool isImportant { get; set; }
        public string Templatetype { get; set; }
        public List<FileContent> PdfFiles { get; set; }
        public List<FileContent> PhotoFiles { get; set; }
        public Email()
        {
            PdfFiles = new List<FileContent>();
            PhotoFiles = new List<FileContent>();
        }
    }
}
