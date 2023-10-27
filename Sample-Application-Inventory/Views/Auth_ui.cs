using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Views
{ 
    internal class Auth_ui
    {
        
        
        public static void login()
        {
            Console.WriteLine();
            Console.WriteLine("Please give following information for Login");
            Console.Write("Email Address - ");
            string s = Console.ReadLine();
            Console.Write("Password - ");
            string s2 = Console.ReadLine();


            object user = auth_manager.login(s, s2);

            if(user == null)
            {
                Console.WriteLine("User don't exist. Please login again.");
                login();
            }
            int role = ((User)user).role;

            if (role == 2)
            {
                Emloyee_ui.employee_homepage((Employee)user);
            }
            else
            {
                Admin_ui.admin_homepage((Admin)user);
            }
        }


        public static void register()
        {
            Console.WriteLine();
            Console.WriteLine("Please give following information for registration");
            Console.Write("Username - ");
            string s = Console.ReadLine();
            Console.Write("Email - ");
            string s2 = Console.ReadLine();
            Console.Write("Password - ");
            string s3 = Console.ReadLine();

            bool flag = auth_manager.register(s, s2, s3, 0);

            if(flag == false)
            {
                Console.WriteLine("User cannot be registered.");
                register();
            }
            else
            {
                Console.WriteLine("Employee registered. Please Login now");
                login();
            }
        }
    }
}
