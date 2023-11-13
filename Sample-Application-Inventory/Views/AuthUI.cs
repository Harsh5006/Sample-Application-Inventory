
using Sample_Application_Inventory.Common_Data;
using Sample_Application_Inventory.ControllerInterface;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models.Enums;

namespace Sample_Application_Inventory.Views
{
    public class AuthUI
    {
        IAuthManager authManager;
        public AuthUI(IAuthManager authManager)
        {
            this.authManager = authManager;
        }
        
        public  void Login()
        {
            Console.WriteLine();
            Console.WriteLine(CommonString.loginInfo);
            Console.Write(CommonString.inputEmail);
            string emailAddress = Console.ReadLine();
            Console.Write(CommonString.inputPassword);
            string password = InputPasswordMasking();



            object user = authManager.Login(emailAddress,password);

            if(user == null)
            {
                Console.WriteLine();
                Console.WriteLine(CommonString.loginErrorMessage);
                Login();
            }
            

            if (user is Employee)
            {
                EmployeeUI employeeUI = new EmployeeUI((Employee)user);
                employeeUI.EmployeeHomepage();
            }
            else if(user is Admin)
            {
                AdminUI adminUI = new AdminUI((Admin)user);
                adminUI.AdminHomepage();
            }
        }


        public void Register()
        {
            Console.WriteLine();
            Console.WriteLine(CommonString.requestRegistrationInfo);
            Console.Write(CommonString.inputUsername);
            string username = Console.ReadLine();
            Console.Write(CommonString.inputEmail);
            string emailAddress = Console.ReadLine();
            Console.Write(CommonString.inputPassword);
            string password = InputPasswordMasking();

            User user = new User(username, password, emailAddress);


            bool isRegistrationSuccessful = authManager.Register(user,Roles.Employee);

            if(isRegistrationSuccessful == false)
            {
                UIConsoleStatements.ShowRegistraionError();
                Register();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(CommonString.registrationSuccessMessage);
                Login();
            }
        }

        public string InputPasswordMasking()
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
