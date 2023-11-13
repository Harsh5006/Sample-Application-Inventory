
using System.Text.RegularExpressions;


namespace Sample_Application_Inventory.Common_Data
{
    internal class RegexData
    {
        public static string email_regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
        public static string password_regex = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
        public static Regex regex1 = new Regex(email_regex);
        public static Regex regex2 = new Regex(password_regex);
    }
}
