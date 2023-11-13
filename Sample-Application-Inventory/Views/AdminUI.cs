using Sample_Application_Inventory.Controller;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.ControllerInterface;
using Sample_Application_Inventory.Common_Data;


namespace Sample_Application_Inventory.Views
{

    public class AdminUI
    {
        AdminController adminController;
        IRequestControllerAdmin requestController;
        IDepartmentControllerAdmin departmentController;
        IProductControllerAdmin productController;
        public AdminUI(Admin admin)
        {
            adminController = new AdminController();
            requestController = new RequestController();
            departmentController = new DepartmentController();
            productController = new ProductController();
        }

        public void AdminHomepage()
        {
            Console.WriteLine();
            UIConsoleStatements.ShowAdminHomepage();
            while (true)
            {
                Console.Write(CommonString.inputOptionNumber);
                int inputOption;
                bool isValidInput = int.TryParse(Console.ReadLine(), out inputOption);


                

                if (isValidInput)
                {
                    var option = (AdminHomepageOptions)inputOption;

                    if (option == AdminHomepageOptions.viewDepartments)
                    {
                        ViewDepartment();
                        break;
                    }
                    else if (option == AdminHomepageOptions.viewEmployees)
                    {
                        ViewEmployees();
                        break;
                    }
                    else if (option == AdminHomepageOptions.createNewDepartment)
                    {
                        CreateDepartment();
                        break;
                    }
                    else if (option == AdminHomepageOptions.createNewProduct)
                    {
                        CreateNewProduct();
                        break;
                    }
                    else if (option == AdminHomepageOptions.createNewAdmin)
                    {
                        AddAdmin();
                        break;
                    }
                    else if (option == AdminHomepageOptions.reviewRequest)
                    {
                        ReviewRequest();
                        break;
                    }
                    else if(option == AdminHomepageOptions.logout)
                    {
                        Logout();
                        break;
                    }
                    else if(option == AdminHomepageOptions.exit)
                    {
                        Exit();
                        break;
                    }
                    else
                    {
                        UIConsoleStatements.ShowInvalidStatement();
                    }
                }
                else
                {
                    UIConsoleStatements.ShowInvalidStatement();
                }
            }
        }

        public void ViewEmployees()
        {
            Console.WriteLine();
            Console.WriteLine(CommonString.employeeListMessage);
            List<Employee> employees = adminController.GetEmployees();
            foreach(Employee employee in employees)
            {
                Console.WriteLine(CommonString.dottedLine);
                Console.WriteLine(CommonString.employeeUsername + employee.username);
                Console.WriteLine(CommonString.employeeEmail + employee.emailAddress);
            }

            Console.WriteLine();
            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            AdminHomepage();
        }


        public void ViewDepartment()
        {
            Console.WriteLine();
            List<Department> departments = departmentController.GetAllDepartments();

            if(departments.Count == 0)
            {
                Console.WriteLine("No Departments are currently present.");
                Console.WriteLine(CommonString.loadingBackHomepageMessage);
            }
            int count = 1;
            foreach (Department department in departments)
            {
                Console.WriteLine($"{count++} {department.name}");
            }
            Console.WriteLine();
            Console.WriteLine(CommonString.chooseDepartment);
            Console.Write(CommonString.departmentNo);

            int departmentIndex;

            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out departmentIndex);

                if (!isValidInput || departmentIndex < 1 || departmentIndex >= count)
                {
                    UIConsoleStatements.ShowInvalidStatement();
                }
                else
                {
                    break;
                }
            }

            Department chosenDepartment = departments[departmentIndex - 1];


            List<Product> departmentProducts = chosenDepartment.GetProducts();

            int productCount = 1;

            foreach (Product product in departmentProducts)
            {
                Console.WriteLine($"{productCount++} {product.name} Quantity:- {product.quantity}");
            }


            Console.WriteLine();
            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            AdminHomepage();
        }



        public void CreateDepartment()
        {
            Console.WriteLine();
            Console.WriteLine(CommonString.inputForNewDepartment);
            Console.WriteLine();
            Console.Write(CommonString.departmentName);
            string inputDepartmentName;

            while (true)
            {
                inputDepartmentName = Console.ReadLine();
                if (ValidateDepartmentName(inputDepartmentName))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(CommonString.invalidDepartmentName);
                }
            }
            
            departmentController.CreateNewDepartment(inputDepartmentName);

            Console.WriteLine();
            Console.WriteLine(CommonString.newDepartmentSuccessful);
            Console.WriteLine();
            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            AdminHomepage();
        }
        private bool ValidateDepartmentName(string department_name)
        {
            
            if(department_name.Length < 4)
            {
                return false;
            }
            List<Department> departments = departmentController.GetAllDepartments();
            foreach (Department department in departments)
            {
                if (department.name.Equals(department_name))
                {
                    return false;
                }
            }

            return true;
        }

        public void CreateNewProduct()
        {
            Console.WriteLine();
            //List<Department> list = departmentController.getDepartments();
            //int i = 1;
            //foreach (Department department in list)
            //{
            //    Console.WriteLine(i + ". " + department.name);
            //    i++;
            //}
            //Console.WriteLine();
            //Console.WriteLine("Choose a Department from above List");
            //Console.WriteLine();
            //Console.Write("Department Number:- ");
            //int department_id;
            //while (true)
            //{
            //    bool flag = int.TryParse(Console.ReadLine(), out department_id);
            //    if (!flag || department_id < 1 || department_id >= i)
            //    {
            //        Console.WriteLine("Invalid Input");
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            List<Department> departments = departmentController.GetAllDepartments();
            int count = 1;
            foreach (Department department in departments)
            {
                Console.WriteLine($"{count++}. {department.name}");
            }
            Console.WriteLine();
            Console.WriteLine(CommonString.chooseDepartment);
            Console.Write(CommonString.departmentNo);

            int departmentIndex;

            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out departmentIndex);

                if (!isValidInput || departmentIndex < 1 || departmentIndex >= count)
                {
                    UIConsoleStatements.ShowInvalidStatement();
                }
                else
                {
                    break;
                }
            }

            Department chosenDepartment = departments[departmentIndex - 1];


            Console.WriteLine();
            Console.WriteLine(CommonString.inputForNewProduct);
            Console.Write(CommonString.productName);
            string inputProductName;
            while (true)
            {
                inputProductName = Console.ReadLine();
                if (!ValidateProductName(chosenDepartment, inputProductName))
                {
                    Console.WriteLine(CommonString.invalidInputForProductName);
                }
                else
                {
                    break;
                }
            }

            Console.Write(CommonString.chooseQuantity);

            int inputQuantity;
            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out inputQuantity);
                if (!isValidInput)
                {
                    Console.WriteLine(CommonString.errorMessageforQuantity);
                }
                else
                {
                    break;
                }
            }

            Product product = new Product(inputProductName, chosenDepartment.id, inputQuantity);
            productController.CreateNewProduct(product, departmentIndex-1);
            Console.WriteLine(CommonString.newProductAddedMessage);
            Console.WriteLine();
            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            AdminHomepage();
        }
        private bool ValidateProductName(Department department,string productName)
        {
            if(productName.Length < 4)
            {
                return false;
            }
            List<Product> products = department.GetProducts();
            foreach (Product product in products) {
                if (product.name.Equals(productName)) return false;
            }
            return true;
        }

        public void AddAdmin()
        {
            Console.WriteLine();
            Console.WriteLine(CommonString.requestRegistrationInfo);
            Console.Write(CommonString.inputUsername);
            string username = Console.ReadLine();
            Console.Write(CommonString.inputEmail);
            string emailAddress = Console.ReadLine();
            Console.Write(CommonString.inputPassword);
            string password = Console.ReadLine();

            User user = new User(username, password, emailAddress);
            bool flag = adminController.AddAdmin(user);
            if (!flag)
            {
                UIConsoleStatements.ShowRegistraionError();
                AddAdmin();
            }

            Console.WriteLine();

            Console.WriteLine(CommonString.newAdminAddedMessage);
            Console.WriteLine();
            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            AdminHomepage();
        }

        public void ReviewRequest()
        {
            Console.WriteLine();
            Dictionary<Request, int> requests = requestController.GetUnaddressedRequests();

            if(requests.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine(CommonString.noRequestPresentMessage);
                Console.WriteLine();
                AdminHomepage();
                return;
            }
            int requestCount = 1;

            foreach (var request in requests)
            {

                Product product = productController.GetProductById(request.Key.productId);

                Department department = departmentController.GetDepartmentById(request.Key.departmentId);

                Console.WriteLine($"{requestCount++}. {CommonString.productName} {product.name} {CommonString.departmentName} {department.name} {CommonString.quantityRequested} {request.Key.quantity}");
            }

           
            Console.WriteLine();

            Console.WriteLine(CommonString.inputRequestNumber);
            Console.Write(CommonString.requestNumber);

            int requestIndex;
            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out requestIndex);
                if (!isValidInput || requestIndex < 1 || requestIndex >= requestCount)
                {
                    UIConsoleStatements.ShowInvalidStatement();  
                }
                else
                {
                    break;
                }

            }

            
            Console.WriteLine(CommonString.acceptOrRejectRequest);

            string inputForApproval;
            while (true) {
                inputForApproval = Console.ReadLine();
                if (!inputForApproval.Equals(CommonString.yes) && !inputForApproval.Equals(CommonString.no))
                {
                    UIConsoleStatements.ShowInvalidStatement();
                }
                else
                {
                    break;
                }
            }
            

            bool flag = requestController.ReviewRequest(requests.ElementAt(requestIndex-1).Value, inputForApproval);
            if (inputForApproval.Equals(CommonString.yes))
            {
                if (flag)
                {
                    Console.WriteLine(CommonString.requestSuccessMessage);
                }
                else
                {
                    Console.WriteLine(CommonString.quantityNotAvailable);
                }
            }
            else
            {
                Console.WriteLine(CommonString.requestDeclinedMessage);
            }


        }

        private void NoDepartmentMessage()
        {

        }
        private void NoProductMessage()
        {

        }

        public void Logout()
        {

            Program.app.Start();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
