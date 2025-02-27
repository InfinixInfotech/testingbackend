﻿using Microsoft.AspNetCore.Http;
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
        private string _createDate;

        public int Id { get; set; }
        public List<string>? To { get; set; }
        public string? From { get; set; }
        public List<string>? CC { get; set; }
        public List<string>? BCC { get; set; }
        public List<string>? EmployeeCode { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public List<FileContent>? Attachment { get; set; }
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
        public bool? isImportant { get; set; }
        public string? Templatetype { get; set; }
        public List<FileContent>? PdfFiles { get; set; }
        public List<FileContent>? PhotoFiles { get; set; }
        public Email()
        {
            PdfFiles = new List<FileContent>();
            PhotoFiles = new List<FileContent>();
        }
    }
}
