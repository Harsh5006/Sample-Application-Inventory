using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.Views
{
    internal class Auth_ui
    {
        
        public  void login()
        {
            Console.WriteLine();
            Console.WriteLine("Please give following information for Login");
            Console.Write("Email Address - ");
            string email_address = Console.ReadLine();
            Console.Write("Password - ");
            var password = password_masking();



            object user = AuthManager.Instance.login(email_address,password);

            if(user == null)
            {
                Console.WriteLine();
                Console.WriteLine("Email Address or password does not match. Please login again.");
                login();
            }
            

            if (user is Employee)
            {
                Employee_ui employee_ui = new Employee_ui((Employee)user);
                employee_ui.employee_homepage();
            }
            else
            {
                AdminUI adminUI = new AdminUI((Admin)user);
                adminUI.admin_homepage();
            }
        }


        public void register()
        {
            Console.WriteLine();
            Console.WriteLine("Please give following information for registration");
            Console.Write("Username - ");
            string user_name = Console.ReadLine();
            Console.Write("Email - ");
            string email_address = Console.ReadLine();
            Console.Write("Password - ");
            string password = password_masking();


            bool flag = AuthManager.Instance.register(user_name,email_address,password,roles.Employee);

            if(flag == false)
            {
                ui_console_statements.showRegistraionError();
                register();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Employee registered. Please Login now");
                login();
            }
        }

        public string password_masking()
        {
            string password = string.Empty;
            ConsoleKey key; do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);

            return password;
        }
    }
}
