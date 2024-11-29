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
        public string apiType { get; set; }
        public string accessType { get; set; }
        public List<string> To { get; set; }
        public string From { get; set; }
        public List<string> CC { get; set; }
        public List<string> BCC { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public List<IFormFile>? Attachment { get; set; }
        [BsonElement("CreateDate")]
        [BsonSerializer(typeof(CustomDateTimeSerializer))]
        public DateTime CreateDate { get; set; }
        [BsonElement("CreateTime")]
        [BsonSerializer(typeof(CustomTimeSerializer))]
        public DateTime CreateTime { get; set; }
    }
}
