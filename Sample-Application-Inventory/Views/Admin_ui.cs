using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Sample_Application_Inventory.Controller;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Controller;

namespace Sample_Application_Inventory.Views
{

    public class AdminUI
    {
        Admin admin;
        AdminController adminController;
        RequestController_Admin adminRequestController;
        public AdminUI(Admin admin)
        {
            this.admin = admin;
            adminController = new AdminController();
            adminRequestController = new RequestController_Admin();
        }

        public void admin_homepage()
        {
            Console.WriteLine();
            ui_console_statements.showAdminHomepage();
            while (true)
            {
                Console.Write("Option Number:- ");
                int i;
                bool flag = int.TryParse(Console.ReadLine(), out i);


                

                if (flag)
                {
                    var key = (admin_homepage_options)i;

                    if (key == admin_homepage_options.view_departments)
                    {
                        viewDepartment();
                        break;
                    }
                    else if (key == admin_homepage_options.view_employees)
                    {
                        viewEmployees();
                        break;
                    }
                    else if (key == admin_homepage_options.create_new_department)
                    {
                        createDepartment();
                        break;
                    }
                    else if (key == admin_homepage_options.create_new_product)
                    {
                        createNewProduct();
                        break;
                    }
                    else if (key == admin_homepage_options.create_new_admin)
                    {
                        addAdmin();
                        break;
                    }
                    else if (key == admin_homepage_options.review_requests)
                    {
                        reviewRequest();
                        break;
                    }
                    else if(key == admin_homepage_options.logout)
                    {
                        logout();
                        break;
                    }
                    else if(key == admin_homepage_options.Exit)
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

        public void viewEmployees()
        {
            Console.WriteLine();
            Console.WriteLine("Following is the list of employees in the Inventory System:- ");
            List<Employee> employees = adminController.GetEmployees();
            foreach(Employee employee in employees)
            {
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("Employee Username:- "+employee.user_name);
                Console.WriteLine("Employee Email:- " + employee.email_address);
            }

            Console.WriteLine();
            Console.WriteLine("Returning back to Homepage.");
            admin_homepage();
        }


        public void viewDepartment()
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
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out department_id);

                if (!flag || department_id < 1 || department_id >= i)
                {
                    Console.WriteLine("Invalid Input");
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
            Console.WriteLine("Returning back to Homepage.");
            admin_homepage();
        }



        public void createDepartment()
        {
            Console.WriteLine();
            Console.WriteLine("Provide following info for creating new Department:- ");
            Console.WriteLine();
            Console.Write("Department Name:- ");
            string s;

            while (true)
            {
                s = Console.ReadLine();
                if (validate_department_name(s))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Department Name or Department already exists. Please try again.");
                }
            }
            
            Controllers.Instance.departmentController.create_new_Department(s);

            Console.WriteLine();
            Console.WriteLine("New Department Created");
            Console.WriteLine();
            Console.WriteLine("Returning back to Homepage.");
            admin_homepage();
        }
        private bool validate_department_name(string department_name)
        {
            
            if(department_name.Length < 4)
            {
                return false;
            }
            List<Department> departments = Controllers.Instance.departmentController.getDepartments();
            foreach (Department department in departments)
            {
                if (department.name.Equals(department_name))
                {
                    return false;
                }
            }

            return true;
        }

        public void createNewProduct()
        {
            Console.WriteLine();
            List<Department> list = Controllers.Instance.departmentController.getDepartments();
            int i = 1;
            foreach (Department department in list)
            {
                Console.WriteLine(i + ". " + department.name);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Choose a Department from above List");
            Console.WriteLine();
            Console.Write("Department Number:- ");
            int department_id;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out department_id);
                if (!flag || department_id < 1 || department_id >= i)
                {
                    Console.WriteLine("Invalid Input");
                }
                else
                {
                    break;
                }
            }
        
            
            Console.WriteLine();
            Console.WriteLine("Please provide following information for new Product");
            Console.Write("Name:- ");
            string s;
            while (true)
            {
                s = Console.ReadLine();
                if (!validate_product_name(admin, list[department_id - 1], s))
                {
                    Console.WriteLine("Invalid Input or Product name already exists.Please try again.");
                }
                else
                {
                    break;
                }
            }
            Console.Write("Quantity:- ");
            int quan;
            while (true)
            {
                bool flag = int.TryParse(Console.ReadLine(), out quan);
                if (!flag)
                {
                    Console.WriteLine("Invalid Input. Please try again.");
                }
                else
                {
                    break;
                }
            }
            Controllers.Instance.productController.CreateNewProduct(s, list[department_id - 1].name, quan, department_id - 1, list[department_id - 1].id);
            Console.WriteLine("New Product Added");
            Console.WriteLine();
            Console.WriteLine("Returning back to Homepage.");
            admin_homepage();
        }
        private bool validate_product_name(Admin admin,Department department,string productName)
        {
            if(productName.Length < 4)
            {
                return false;
            }
            List<Product> products = department.GetProducts();
            foreach (Product product in products) {
                if (product.Name.Equals(productName)) return false;
            }
            return true;
        }

        public void addAdmin()
        {
            Console.WriteLine();
            Console.WriteLine("Please give following information for New Admin Registration");
            Console.Write("Username - ");
            string s1 = Console.ReadLine();
            Console.Write("Email Address - ");
            string s2 = Console.ReadLine();
            Console.Write("Password - ");
            string s3 = Console.ReadLine();

            bool flag = adminController.AddAdmin(s1, s2, s3);
            if (!flag)
            {
                ui_console_statements.showRegistraionError();
                addAdmin();
            }

            Console.WriteLine();

            Console.WriteLine("New admin added");
            Console.WriteLine();
            Console.WriteLine("Returning back to Homepage.");
            admin_homepage();
        }

        public void reviewRequest()
        {
            Console.WriteLine();
            Dictionary<Request, int> requests = adminRequestController.GetUnaddressedRequests();

            if(requests.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("No request is present");
                Console.WriteLine();
                admin_homepage();
                return;
            }
            int i = 1;

            foreach (var request in requests)
            {
                Console.WriteLine($"{i}. Product Name - {request.Key.product_name} Department Name - {request.Key.department_name} Quantity Requested - {request.Key.quantity}");
                i++;
            }

           
            Console.WriteLine();

            Console.WriteLine("Please select a request no.");
            Console.Write("Request No.- ");

            int request_id;
            while (true)
            {
                bool flag1 = int.TryParse(Console.ReadLine(), out request_id);
                if (!flag1 || request_id < 1 || request_id >= i)
                {
                    ui_console_statements.showInvalidStatement();
                   
                }
                else
                {
                    break;
                }

            }

            
            Console.WriteLine("Whether you want to accept the request. Answer in Yes or No");

            string s;
            while (true) {
                s = Console.ReadLine();
                if (!s.Equals("Yes") && !s.Equals("No"))
                {
                    ui_console_statements.showInvalidStatement();
                }
                else
                {
                    break;
                }
            }
            

            bool flag = adminRequestController.ReviewRequest(requests.ElementAt(request_id-1).Value, s);
            if (s.Equals("Yes"))
            {
                if (flag)
                {
                    Console.WriteLine("Request Successfully accepted.");
                }
                else
                {
                    Console.WriteLine("Specified Quantity is not available in inventory.");
                }
            }
            else
            {
                Console.WriteLine("Request Successfully declined.");
            }


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
