using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Sample_Application_Inventory.Common_Data;
using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory
{
    public class AuthManager
    {
        private static AuthManager _instance = null;

        public static AuthManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new AuthManager();
                }
                return _instance;
            }
        }

        public bool register(string user_name,string email_address,string password,roles role)
        {
            if(!validate_register(user_name,email_address,password)) return false;
            if(role == roles.Employee)
            {
                Employee employee = new Employee(user_name,email_address,password);
                DBEmployee.Instance.put(employee);
            }
            else if(role == roles.Admin)
            {
                Admin admin = new Admin(user_name, email_address, password);
                DBAdmin.Instance.put(admin);
            }
            return true;
        }


        public object login(string email,string password)
        {
            if (!validate_login(email, password)) return null;
            List<Employee> e = DBEmployee.Instance.Get();
            foreach (Employee employee in e)
            {
                if (employee.email_address.Equals(email) && employee.password.Equals(password))
                {
                    return employee;
                }
            }

            List<Admin> a = DBAdmin.Instance.Get();
            foreach (Admin admin in a)
            {
                if (admin.email_address.Equals(email) && admin.password.Equals(password))
                {
                    return admin;
                }
            }

            return null;
        }
        
        private bool validate_register(string user_name,string email_address,string password)
        {
            
            Match match = regex_data.regex1.Match(email_address);
            if (!match.Success)
            {
                return false;
            }

            
            Match match2 = regex_data.regex2.Match(password);
            if (!match2.Success)
            {
                return false;
            }


            if(user_name.Length < 4)
            {
                return false;
            }

            List<Employee> employee = DBEmployee.Instance.Get();
            foreach(Employee e in  employee)
            {
                if (e.email_address.Equals(email_address))
                {
                    return false;
                }
            }
            List<Admin> admin = DBAdmin.Instance.Get();
            foreach(Admin a in admin)
            {
                if (a.email_address.Equals(email_address))
                {
                    return false;
                }
            }

            return true;
        }

        private bool validate_login(string email_address,string password)
        {
            
            Match match = regex_data.regex1.Match(email_address);
            if (!match.Success)
            {
                return false;
            }

            Match match2 = regex_data.regex2.Match(password);
            if (!match2.Success)
            {
                return false;
            }

            return true;
        }
    }

}
