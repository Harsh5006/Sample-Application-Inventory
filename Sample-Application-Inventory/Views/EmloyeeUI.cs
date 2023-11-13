
using Sample_Application_Inventory.Common_Data;
using Sample_Application_Inventory.Controller;
using Sample_Application_Inventory.ControllerInterface;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models.Enums;

namespace Sample_Application_Inventory.Views
{

    public class EmployeeUI
    {
        
        Employee employee;
        IRequestControllerEmployee requestController;
        IDepartmentControllerEmployee departmentController;
        IProductControllerEmployee productController;

        public EmployeeUI(Employee employee)
        {
            this.employee = employee;
            this.requestController = new RequestController();
            departmentController = new DepartmentController();
            productController = new ProductController();
        }
        public void EmployeeHomepage()
        {
            Console.WriteLine();
            UIConsoleStatements.ShowEmployeeHomepage();


            while (true)
            {
                Console.Write(CommonString.inputOptionNumber);
                int input;
                bool isValidInput = int.TryParse(Console.ReadLine(), out input);
                if (isValidInput)
                {
                    var option = (EmployeeHomepageOptions)input;
                    if (option == EmployeeHomepageOptions.ViewPreviouslyAllocatedProducts)
                    {
                        EmployeeAllocatedProducts();
                        break;
                    }
                    else if (option == EmployeeHomepageOptions.ViewPreviouslyMadeRequests)
                    {

                        EmployeeRequests();
                        break;
                    }
                    else if (option == EmployeeHomepageOptions.RequestProduct)
                    {
                        RequestProduct();
                        break;
                    }
                    else if (option == EmployeeHomepageOptions.ReturnProduct)
                    {
                        ReturnProduct();
                        break;
                    }
                    else if(option == EmployeeHomepageOptions.Logout)
                    {
                        Logout();
                        break;
                    }
                    else if (option == EmployeeHomepageOptions.Exit)
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

        public void EmployeeAllocatedProducts()
        {

            Dictionary<Product, int> allocatedProducts = productController.GetEmployeeProducts(employee);
            if(allocatedProducts.Count == 0)
            {
                Console.WriteLine(CommonString.errorNoAllocatedProduct);
                Console.WriteLine();
                Console.WriteLine(CommonString.loadingbackMessage);
                Console.WriteLine();
                EmployeeHomepage();
            }

            int count = 1;

            foreach (var product in allocatedProducts)
            {
                
                Console.WriteLine($"{count++}. {product.Key.name} Quantity- {product.Value} ");

            }

            Console.WriteLine();
            Console.WriteLine(CommonString.loadingbackMessage);
            Console.WriteLine();

            EmployeeHomepage();

        }

        public void EmployeeRequests()
        {
            List<Request> requests = requestController.GetEmployeeRequests(employee);
            if(requests.Count == 0)
            {
                Console.WriteLine(CommonString.noRequestMessage);
                Console.WriteLine();
                Console.WriteLine(CommonString.loadingBackHomepageMessage);
                EmployeeHomepage();
            }
            int count = 1;
            foreach (Request r in requests)
            {
                Product product = productController.GetProductById(r.productId);
                Department department = departmentController.GetDepartmentById(r.departmentId);

                Console.WriteLine($"{count++}. Product Name:- {product.name}  Department Name:- {department.name} Quantity Requested:- {r.quantity} Current Status:- {r.status}");
            }

            Console.WriteLine();
            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            Console.WriteLine();
            EmployeeHomepage();
        }

        public void RequestProduct()
        {
            Console.WriteLine();
            List<Department> departments = departmentController.GetAllDepartments();
            int count = 1;
            foreach (Department department in departments)
            {
                Console.WriteLine($"{count++} {department.name}");
            }
            Console.WriteLine();
            Console.WriteLine(CommonString.chooseDepartment);
            Console.Write(CommonString.departmentNo);

            int departmentIndex;

            while (true) {
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

            Department chosenDepartment = departments[departmentIndex-1];
            

            List<Product> departmentProducts = chosenDepartment.GetProducts();

            int productCount = 1;

            foreach (Product product in departmentProducts)
            {
                Console.WriteLine($"{productCount++} {product.name} Quantity:- {product.quantity}");
            }
            Console.WriteLine();
            Console.WriteLine(CommonString.chooseProduct);
            Console.WriteLine(CommonString.productNo);

            int productIndex;
            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out productIndex);
                if (!isValidInput || productIndex < 1 || productIndex >= productCount)
                {
                    UIConsoleStatements.ShowInvalidStatement();
                }
                else
                {
                    break;
                }
            }

            Product chosenProduct = departmentProducts[productIndex - 1];
            

            Console.WriteLine();
            Console.Write(CommonString.chooseQuantity);
            int quantity;

            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out quantity);

                if (!isValidInput || quantity < 1 || quantity > chosenProduct.quantity)
                {
                    UIConsoleStatements.ShowInvalidStatement();
                }
                else
                {
                    break;
                }
            }



            Request request = new Request(chosenProduct.id, chosenDepartment.id, employee.id, quantity);
            requestController.RequestProduct(employee,request);
            Console.WriteLine();
            Console.WriteLine(CommonString.requestSuccessful);
            Console.WriteLine();

            Console.WriteLine(CommonString.loadingBackHomepageMessage);
            EmployeeHomepage();
        }

        public void ReturnProduct()
        {
            Console.WriteLine();
            Dictionary<Product, int> allocatedProducts = productController.GetEmployeeProducts(employee);


            int productCount = 1;

            foreach (var product in allocatedProducts)
            {

                Console.WriteLine($"{productCount++}. {product.Key.name} Quantity- {product.Value} ");

            }

            Console.WriteLine();

            Console.Write(CommonString.chooseProductToReturn);
            int productIndex;

            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out productIndex);
                if (!isValidInput || productIndex < 1 || productIndex >= productCount)
                {
                    UIConsoleStatements.ShowInvalidStatement();
                    
                }
                else
                {
                    break; }
            }
            
            

            
            Console.Write(CommonString.chooseQuantity);

            int quantityToReturn;
            int actualProductQuantity = allocatedProducts.ElementAt(productIndex - 1).Value;
            while (true)
            {
                bool isValidInput = int.TryParse(Console.ReadLine(), out quantityToReturn);

                if (!isValidInput || quantityToReturn < 1 || quantityToReturn > actualProductQuantity)
                {
                    Console.WriteLine(CommonString.errorMessageforQuantity);
                    
                }
                else { break; }
            }
           
           

            productController.ReturnProduct(employee,allocatedProducts.ElementAt(productIndex - 1).Key, quantityToReturn,productIndex - 1);
            Console.WriteLine();
            Console.WriteLine(CommonString.returnSuccessful);
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
