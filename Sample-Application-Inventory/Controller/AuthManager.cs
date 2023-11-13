using System.Text.RegularExpressions;
using Sample_Application_Inventory.Common_Data;
using Sample_Application_Inventory.ControllerInterface;
using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models.Enums;

namespace Sample_Application_Inventory
{
    public class AuthManager : IAuthManager
    {
        private static AuthManager _instance = null;

        public static AuthManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AuthManager();
                }
                return _instance;
            }
        }

        public bool Register(User user, Roles role)
        {
            if (!ValidateRegistration(user.username, user.emailAddress, user.password)) return false;
            if (role == Roles.Employee)
            {
                Employee employee = new Employee(user.username, user.emailAddress, user.password);
                DBEmployee.Instance.Put(employee);
            }
            else if (role == Roles.Admin)
            {
                Admin admin = new Admin(user.username, user.emailAddress, user.password);
                DBAdmin.Instance.Put(admin);
            }
            return true;
        }


        public object Login(string email, string password)
        {
            if (!ValidateLogin(email, password)) return null;

            List<Admin> admins = DBAdmin.Instance.Get();
            foreach (Admin admin in admins)
            {
                if (admin.emailAddress.Equals(email) && admin.password.Equals(password))
                {
                    return admin;
                }
            }

            List<Employee> employees = DBEmployee.Instance.Get();
            foreach (Employee employee in employees)
            {
                if (employee.emailAddress.Equals(email) && employee.password.Equals(password))
                {
                    return employee;
                }
            }
            return null;
        }

        private bool ValidateRegistration(string userName, string emailAddress, string password)
        {

            Match match = RegexData.regex1.Match(emailAddress);
            if (!match.Success)
            {
                return false;
            }


            Match match2 = RegexData.regex2.Match(password);
            if (!match2.Success)
            {
                return false;
            }


            if (userName.Length < 4)
            {
                return false;
            }

            List<Employee> employees = DBEmployee.Instance.Get();
            foreach (Employee employee in employees)
            {
                if (employee.emailAddress.Equals(emailAddress))
                {
                    return false;
                }
            }
            List<Admin> admins = DBAdmin.Instance.Get();
            foreach (Admin admin in admins)
            {
                if (admin.emailAddress.Equals(emailAddress))
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateLogin(string emailAddress, string password)
        {

            Match match = RegexData.regex1.Match(emailAddress);
            if (!match.Success)
            {
                return false;
            }

            Match match2 = RegexData.regex2.Match(password);
            if (!match2.Success)
            {
                return false;
            }

            return true;
        }
    }

}
