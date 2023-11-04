using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory
{
    class AdminController
    {
        public bool AddAdmin(string user_name,string email_address,string password)
        {   
            return AuthManager.Instance.register(user_name, email_address, password,roles.Admin);
        }

        public List<Employee> GetEmployees()
        {
            return DBEmployee.Instance.Get();
        }   
    }
}
