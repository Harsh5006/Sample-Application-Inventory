using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample_Application_Inventory.Controller;
//using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.Views
{

    public class Employee_ui
    {
        Employee employee;
        RequestController_Employee requestControllerEmployee;

        public Employee_ui(Employee employee)
        {
            this.employee = employee;
            this.requestControllerEmployee = new RequestController_Employee(employee);
        }
        public void employee_homepage()
        {
            Console.WriteLine();
            ui_console_statements.showEmployeeHomepage();


            while (true)
            {
                Console.Write("Option No:- ");
                int i;
                bool flag = int.TryParse(Console.ReadLine(), out i);
                if (flag)
                {
                    var key = (employee_homepage_options)i;
                    if (key == employee_homepage_options.ViewPreviouslyAllocatedProducts)
                    {
                        employee_allocatedProducts();
                        break;
                    }
                    else if (key == employee_homepage_options.ViewPreviouslyMadeRequests)
                    {

                        employee_requests();
                        break;
                    }
                    else if (key == employee_homepage_options.RequestProduct)
                    {
                        requestProduct();
                        break;
                    }
                    else if (key == employee_homepage_options.ReturnProduct)
                    {
                        returnProduct();
                        break;
                    }
                    else if(key == employee_homepage_options.Logout)
                    {
                        logout();
                        break;
                    }
                    else if (key == employee_homepage_options.Exit)
                    {
                        exit();
                        break;
                    }
                    else
                    {
                        ui_console_statements.showInvalidStatement();
                    }
                }
                else
                {
                    ui_console_statements.showInvalidStatement();
                }
            }
        }

        public void employee_allocatedProducts()
        {

            Dictionary<Product, int> keyValuePairs = Controllers.Instance.productController.GetEmployeeProducts(employee);
            if(keyValuePairs.Count == 0)
            {
                Console.WriteLine("No product is allocated yet.");
                Console.WriteLine();
                Console.WriteLine("Loading back to Homepage.");
                Console.WriteLine();
                employee_homepage();
            }

            int i = 1;

            foreach (var product in keyValuePairs)
            {
                
                Console.WriteLine($"{i++}. {product.Key.Name} Quantity- {product.Value} ");

            }

            Console.WriteLine();
            Console.WriteLine("Loading back to Homepage.");
            Console.WriteLine();

            employee_homepage();

        }

        public void employee_requests()
        {
            List<Request> requests = requestControllerEmployee.GetEmployeeRequests();
            if(requests.Count == 0)
            {
                Console.WriteLine("No request is made yet.");
                Console.WriteLine();
                Console.WriteLine("Loading back to Homepage...");
                employee_homepage();
            }
            int i = 1;
            foreach (Request r in requests)
            {
                Console.WriteLine($"{i++}. Product Name:- {r.product_name}  Department Name:- {r.department_name} Quantity Requested:- {r.quantity} Current Status:- {r.status}");
            }

            Console.WriteLine();
            Console.WriteLine("Loading back to Homepage...");
            Console.WriteLine();
            employee_homepage();
        }

        public void requestProduct()
        {
            Console.WriteLine();
            List<Department> list = Controllers.Instance.departmentController.getDepartments();
            int i = 1;
            foreach (Department department in list)
            {
                Console.WriteLine(i + " " + department.name);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Please choose a department from above list");
            Console.Write("Department No:- ");

            int department_id;

            while (true) {
                bool flag = int.TryParse(Console.ReadLine(), out department_id);

                if (!flag || department_id < 1 || department_id >= i)
                {
                    ui_console_statements.showInvalidStatement();
                }
                else
                {
                    break;
                }
            }
            

            List<Product> pr = list[department_id - 1].GetProducts();

            int j = 1;

            foreach (Product product in pr)
            {
                Console.WriteLine(j + " " + product.Name + " Quantity:- " + product.Quantity);
                j++;
            }
            Console.WriteLine();
            Console.WriteLine("Please choose a product from above list.");
            Console.WriteLine("Product No:- ");
            int product_id;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out product_id);
                if (!flag || product_id < 1 || product_id >= j)
                {
                    ui_console_statements.showInvalidStatement();
                }
                else
                {
                    break;
                }
            }
            

            Console.WriteLine();
            Console.Write("Please specify quantity:- ");
            int quant;

            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out quant);

                if (!flag || quant < 1 || quant > pr[product_id - 1].Quantity)
                {
                    ui_console_statements.showInvalidStatement();
                }
                else
                {
                    break;
                }
            }

            
            requestControllerEmployee.RequestProduct(product_id - 1, department_id - 1, quant, pr[product_id - 1].Name, list[department_id - 1].name);
            Console.WriteLine();
            Console.WriteLine("Request Successful");
            Console.WriteLine();

            Console.WriteLine("Loading back to Homepage...");
            employee_homepage();
        }

        public void returnProduct()
        {
            Console.WriteLine();
            Dictionary<Product, int> keyValuePairs = Controllers.Instance.productController.GetEmployeeProducts(employee);


            int i = 1;

            foreach (var product in keyValuePairs)
            {

                Console.WriteLine($"{i++}. {product.Key.Name} Quantity- {product.Value} ");

            }

            Console.WriteLine();

            Console.Write("Please enter Product No you want to return.");
            int product_id;

            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out product_id);
                if (!flag || product_id < 1 || product_id >= i)
                {
                    ui_console_statements.showInvalidStatement();
                    
                }
                else
                {
                    break; }
            }
            
            

            
            Console.Write("Please enter quantity:- ");

            int quantity;
            int product_quantity = keyValuePairs.ElementAt(product_id - 1).Value;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out quantity);

                if (!flag || quantity < 1 || quantity > product_quantity)
                {
                    Console.WriteLine("Invalid Input for Quantity. Please try again.");
                    
                }
                else { break; }
            }
           
           

            Controllers.Instance.productController.returnProduct(employee,keyValuePairs.ElementAt(product_id - 1).Key, quantity,product_id-1);
            Console.WriteLine();
            Console.WriteLine("Product Successfully returned");
            
        }

        public void logout()
        {
            Program.app.start();
        }   
        

        public void exit()
        {
            Environment.Exit(0);
        }
    }
}
