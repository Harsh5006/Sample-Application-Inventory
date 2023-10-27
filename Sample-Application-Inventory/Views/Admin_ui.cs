using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Views
{
    enum admin_homepage_options
    {
        view_departments = 1,
        create_new_department = 2,
        create_new_product = 3,
        create_new_admin = 4,
        review_requests = 5
    }
    internal class Admin_ui
    {

        public static void admin_homepage(Admin admin)
        {
            Console.WriteLine("1. View Departments");
            Console.WriteLine("2. Create a new Department");
            Console.WriteLine("3. Create a new Product.");
            Console.WriteLine("4. Create a new Admin");
            Console.WriteLine("5. Review Requests");

            Console.WriteLine("Choose a Option from above");

            while (true)
            {
                Console.Write("Option Number:- ");
                int i = Convert.ToInt32(Console.ReadLine());

                if (i == (int)admin_homepage_options.view_departments)
                {
                    viewDepartment();
                }
                else if (i == (int)admin_homepage_options.create_new_department)
                {
                    createDepartment(admin);
                }
                else if (i == (int)admin_homepage_options.create_new_product)
                {
                    createNewProduct(admin);
                }
                else if (i == (int)admin_homepage_options.create_new_admin)
                {
                    addAdmin(admin);
                }
                else if (i == (int)admin_homepage_options.review_requests)
                {
                    reviewRequest(admin);
                }
                else
                {
                    Console.WriteLine("Invalid Option. Please try again");
                }
            }
        }


        public static void viewDepartment()
        {
            List<Department> list = database_manager.getDepartments();
            int i = 1;
            foreach (Department department in list)
            {
                Console.WriteLine(i + " " + department.Name);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Please choose a department from above list");
            Console.Write("Department No:- ");
            int department_id = Convert.ToInt32(Console.ReadLine());

            if (department_id < 1 || department_id >= i)
            {
                Console.WriteLine("Invalid Input");
            }

            List<Product> pr = list[department_id - 1].getProducts();

            int j = 1;

            foreach (Product product in pr)
            {
                Console.WriteLine(j + " " + product.Name + " Quantity:- " + product.Quantity);
                j++;
            }
            //Console.WriteLine();
            //Console.WriteLine("Please choose a product from above list.");
            //Console.WriteLine("Product No:- ");
            //int product_id = Convert.ToInt32(Console.ReadLine());
            //if(product_id < 1 || product_id >= j)
            //{
            //    Console.WriteLine("Invalid input");
            //}

        }



        public static void createDepartment(Admin admin)
        {
            Console.WriteLine("Provide following info for creating new Department:- ");
            Console.WriteLine();
            Console.Write("Department Name:- ");
            string s = Console.ReadLine();
            admin.create_new_Department(s);

            Console.WriteLine();
            Console.WriteLine("New Department Created");
            admin_homepage(admin);
        }

        public static void createNewProduct(Admin admin)
        {
            List<Department> list = database_manager.getDepartments();
            int i = 1;
            foreach (Department department in list)
            {
                Console.WriteLine(i + ". " + department.Name);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Choose a Department from above List");
            Console.WriteLine();
            Console.Write("Department Number:- ");
            int department_id = Convert.ToInt32(Console.ReadLine());
            if (department_id < 1 || department_id >= i)
            {
                Console.WriteLine("Invalid Input");
            }

            Console.WriteLine();
            Console.WriteLine("Please provide following information for new Product");
            Console.Write("Name:- ");
            string s = Console.ReadLine();
            Console.Write("Quantity:- ");
            int quan = Convert.ToInt32(Console.ReadLine());
            admin.create_new_Product(s, list[department_id - 1].Name, quan, department_id - 1, list[department_id - 1].Id);
            Console.WriteLine("New Product Added");
            Console.WriteLine();
            admin_homepage(admin);
        }

        public static void addAdmin(Admin admin)
        {
            Console.WriteLine("Please give following information for New Admin Registration");
            Console.Write("Username - ");
            string s1 = Console.ReadLine();
            Console.Write("Email Address - ");
            string s2 = Console.ReadLine();
            Console.Write("Password - ");
            string s3 = Console.ReadLine();

            admin.Add_Admin(s1, s2, s3);

            Console.WriteLine("New admin added");
        }

        public static void reviewRequest(Admin admin)
        {
            List<Request> requests = database_manager.GetRequests();
            int i = 1;

            foreach (Request request in requests)
            {
                Console.WriteLine($"{i}. Product Name - {request.product_name} Department Name - {request.department_name}");
                i++;
            }
            Console.WriteLine();

            Console.WriteLine("Please select a request no.");
            Console.Write("Request No.- ");
            int request_id = Convert.ToInt32(Console.ReadLine());

            if (request_id < 1 || request_id >= i)
            {
                Console.WriteLine("Invalid Input");
                return;
            }
            Console.WriteLine("Whether you want to accept the request. Answer in Yes or No");

            string s = Console.ReadLine();
            if (!s.Equals("Yes") && !s.Equals("No"))
            {
                Console.WriteLine("Invalid Input");
            }

            admin.reviewRequest(request_id - 1, s);
        }
    }
}
