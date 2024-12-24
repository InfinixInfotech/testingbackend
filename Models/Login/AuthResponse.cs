using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Login
{
    public class AuthResponse
    {
        public bool Success { get; set; }
        public string? Error { get; set; }
        public string? Token { get; set; }
        public string? Message { get; set; }
        public string? EmployeeCode { get; set; }
        public string? GroupName { get; set; }
        public object? Data { get; set; }
        public string? UserName { get; set; }
    }
}
