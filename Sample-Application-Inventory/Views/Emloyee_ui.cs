using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Views
{
    enum employee_homepage_options
    {
        ViewPreviouslyAllocatedProducts = 1,
        ViewPreviouslyMadeRequests = 2,
        RequestProduct = 3
    }
    class Emloyee_ui
    {
        public static void employee_homepage(Employee e)
        {
            Console.WriteLine("1. View Previously Allocated Products");
            Console.WriteLine("2. View Previously Made Requests");
            Console.WriteLine("3. Request a Product");
            Console.WriteLine();


            while (true)
            {
                int i = Convert.ToInt32(Console.ReadLine());

                if (i == (int)employee_homepage_options.ViewPreviouslyAllocatedProducts)
                {
                    employee_allocatedProducts();
                }
                else if (i == (int)employee_homepage_options.ViewPreviouslyMadeRequests)
                {

                    employee_requests(e);
                }
                else if (i == (int)employee_homepage_options.RequestProduct)
                {
                    requestProduct(e);
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please try again.");
                }
            }
        }

        public static void employee_allocatedProducts()
        {
            //List<ArrayList> prod = employee.getAllocatedProducts();
            //int i = 1;

            //foreach(var product in prod)
            //{
            //    Product p = Product(product[0]);
            //    Console.WriteLine($"{i}. {product[0].Name} Quantity- {product.Value} ")
            //}
            //foreach(var product in prod)
            //{
            //    Console.WriteLine($"{i}. {product.Key.Name} Quantity- {product.Value} ");
            //    i++;
            //}
        }

        public static void employee_requests(Employee employee)
        {
            List<Request> requests = employee.getRequests();
            int i = 1;
            foreach (Request r in requests)
            {
                Console.WriteLine($"Product Name:- {r.product_name}  Department Name:- {r.department_name} Quantity Requested:- {r.quantity} Current Status:- {r.status}");
            }
        }

        public static void requestProduct(Employee employee)
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
            Console.WriteLine();
            Console.WriteLine("Please choose a product from above list.");
            Console.WriteLine("Product No:- ");
            int product_id = Convert.ToInt32(Console.ReadLine());
            if (product_id < 1 || product_id >= j)
            {
                Console.WriteLine("Invalid input");
            }

            Console.WriteLine();
            Console.Write("Please specify quantity:- ");
            int quant = Convert.ToInt32(Console.ReadLine());
            if (quant < 1 || quant > pr[product_id - 1].Quantity)
            {
                Console.WriteLine("Invalid input. Application exiting");
            }

            employee.requestProduct(product_id - 1, department_id - 1, quant, pr[product_id - 1].Name, list[department_id - 1].Name);
            Console.WriteLine();
            Console.WriteLine("Request Successful");
        }
    }
}
