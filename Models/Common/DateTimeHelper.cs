using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common

{
    public class DateTimeHelper
    {
        public static string GetPresentDate()
        {
            return DateTime.Now.ToString("dd-MM-yyyy"); // Format as "17-12-2024"
        }

        public static string GetPresentTime()
        {
            return DateTime.Now.ToString("hh:mm tt"); // Format as "05:38 AM"
        }
    }
}
