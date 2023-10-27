using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory
{
    static class auth_manager
    {

        public static bool register(string user_name,string email_address,string password,int user_type)
        {
            if(!validate()) return false;
            if(user_type == 0)
            {
                Employee e = new Employee(user_name,email_address,password);
                database_manager.addEmployee(e);
            }
            else if(user_type == 1)
            {
                Admin a = new Admin(user_name, email_address, password);
                database_manager.addAdmin(a);
            }
            return true;
        }


        public static object login(string email,string password)
        {
            List<Employee> e = database_manager.getEmployees();
            foreach (Employee employee in e)
            {
                if (employee.email_address.Equals(email) && employee.password.Equals(password))
                {
                    return employee;
                }
            }

            List<Admin> a = database_manager.getAdmins();
            foreach (Admin admin in a)
            {
                if (admin.email_address.Equals(email) && admin.password.Equals(password))
                {
                    return admin;
                }
            }

            return null;
        }
        
        public static void logout()
        {

        }
        public static bool validate()
        {
            return true;
        }
    }

}
