using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Response
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Message { get; set; }
        public string EmployeeCode { get; set; }
        public string GroupName { get; set; }
        public object Data { get; set; } 
    }
}
