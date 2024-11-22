using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class GetUsers
    {
        public string FullName { get; set; }
        public string EmployeeCode { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ReportingTo { get; set; }
        public string GroupName { get; set; }
        public string DepartmentName { get; set; }
        public string DesignationName { get; set; }
        public string QualificationName { get; set; }
        public Extension Extension { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
}