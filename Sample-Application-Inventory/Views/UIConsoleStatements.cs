namespace Sample_Application_Inventory.Views
{
    class UIConsoleStatements
    {
        public static void ShowAdminHomepage()
        {
            Console.WriteLine();
            Console.WriteLine("1. View Departments");
            Console.WriteLine("2. View Employees");
            Console.WriteLine("3. Create a new Department");
            Console.WriteLine("4. Create a new Product.");
            Console.WriteLine("5. Create a new Admin");
            Console.WriteLine("6. Review Requests");
            Console.WriteLine("7. Logout");
            Console.WriteLine("8. Exit");

            Console.WriteLine("Choose a Option from above");
            Console.WriteLine();
        }

        public static void ShowInvalidStatement()
        {
            Console.WriteLine("Invalid Input. Please try again.");
        }

        public static void ShowRegistraionError()
        {
            Console.WriteLine("User cannot be registered. Please make the following conditions:- ");
            Console.WriteLine("1. Email should in proper format.");
            Console.WriteLine("2. Password should be minimum 8 characters in length, should contain atleast one upper-case letter,lower-case letter, special character and one digit.");
            Console.WriteLine("3. UserName should be minimum 4 characters in length.");
            Console.WriteLine("4. Or User already exists with same email address.");
        }

        public static void ShowEmployeeHomepage()
        {
            Console.WriteLine();
            Console.WriteLine("1. View Previously Allocated Products");
            Console.WriteLine("2. View Previously Made Requests");
            Console.WriteLine("3. Request a Product");
            Console.WriteLine("4. Return a Product");
            Console.WriteLine("5. Logout");
            Console.WriteLine("6. Exit.");
            Console.WriteLine();
        }

        public static void ShowHomepage()
        {
            Console.WriteLine("*****************************************************");
            Console.WriteLine("Inventory Mangement - Office");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
        }
    }
}
