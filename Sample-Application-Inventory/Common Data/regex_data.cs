using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Common_Data
{
    internal class regex_data
    {
        public static string email_regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public static string password_regex = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public static Regex regex1 = new Regex(email_regex);
        public static Regex regex2 = new Regex(password_regex);
    }
}
