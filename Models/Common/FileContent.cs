﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class FileContent
    {
        public string FileName { get; set; }

        public byte[] FileData { get; set; }

        public string ContentType { get; set; }
    }
}
