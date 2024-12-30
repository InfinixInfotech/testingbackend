using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class BulkUser
    {
        public IFormFile? CsvUserFile { get; set; }
    }
}
