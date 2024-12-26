using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Settings
{
    public class Designation
    {
        public int Id { get; set; }
        public string? DesignationName { get; set; }
        public int? DesignationTarget { get; set; }
    }
}
