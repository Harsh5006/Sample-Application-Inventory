using Sample_Application_Inventory.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Sample_Application_Inventory.Controller;
//using Sample_Application_Inventory.Database;

namespace Sample_Application_Inventory
{
    enum options
    {
        login=1,
        register = 2,
        exit = 3
    }
    class App
    {

        
        public static void start()
        {
            Console.WriteLine("Inventory Mangement - Office");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");

            

            while (true) {
                Console.WriteLine("Enter 1,2 or 3");
                int i = Convert.ToInt32(Console.ReadLine());
                if (i == (int)options.login)
                {
                    Auth_ui.login();
                    
                }
                else if (i == (int)options.register)
                {
                    Auth_ui.register();
                }
                else if (i == 3)
                {
                    exit();
                }
                else
                {
                    Console.WriteLine("Invalid Input. Please try again");
                }
            }

            
        }

        public static void exit()
        {
            Environment.Exit(0);
        }

        //public void login()
        //{
        //    Console.WriteLine("1. Login as Admin");
        //    Console.WriteLine("2. Login as Employee");


        //    while (true)
        //    {
        //        int i = Convert.ToInt32(Console.ReadLine());
        //        if(i == 1)
        //        {
        //            login_asAdmin();
        //            break;
        //        }
        //        else if(i == 2)
        //        {
        //            login_asEmployee();
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid Input. Please try again.");
        //        }
        //    }
        //}

        //public void login_asAdmin()
        //{
        //    Console.WriteLine("Please give following information for Login");
        //    Console.Write("Email Address - ");
        //    string s = Console.ReadLine();
        //    Console.Write("Password - ");
        //    string s2 = Console.ReadLine();

        //    ad = auth_manager.login_Admin(s,s2);
        //    if(ad == null)
        //    {
        //        Console.WriteLine("User don't exists. Application exiting");
        //        return;
        //    }
        //    logged_asAdmin();

        //}
        //public void login_asEmployee()
        //{
        //    Console.WriteLine("Please give following information for Login");
        //    Console.Write("Email Address - ");
        //    string s = Console.ReadLine();
        //    Console.Write("Password - ");
        //    string s2 = Console.ReadLine();

        //    employee = auth_manager.login_Employee(s, s2);
        //    if(employee == null)
        //    {
        //        Console.WriteLine("User don't exists. Application exiting");
        //        return;
        //    }
        //    logged_asEmployee();
        //}

        //public void logged_asEmployee()
        //{
        //    Console.WriteLine("1. View Previously Allocated Products");
        //    Console.WriteLine("2. View Previously Made Requests");
        //    Console.WriteLine("3. Request a Product");
        //    Console.WriteLine();


        //    while (true)
        //    {
        //        int i = Convert.ToInt32(Console.ReadLine());

        //        if(i == 1)
        //        {
        //            employee_allocatedProducts();
        //        }
        //        else if(i == 2)
        //        {

        //            employee_requests();
        //        }
        //        else if(i == 3)
        //        {
        //            requestProduct();
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid Input. Please try again.");
        //        }
        //    }
        //}

        //public void employee_allocatedProducts()
        //{
        //    //List<ArrayList> prod = employee.getAllocatedProducts();
        //    //int i = 1;

        //    //foreach(var product in prod)
        //    //{
        //    //    Product p = Product(product[0]);
        //    //    Console.WriteLine($"{i}. {product[0].Name} Quantity- {product.Value} ")
        //    //}
        //    //foreach(var product in prod)
        //    //{
        //    //    Console.WriteLine($"{i}. {product.Key.Name} Quantity- {product.Value} ");
        //    //    i++;
        //    //}
        //}

        //public void employee_requests()
        //{
        //    List<Request> requests = employee.getRequests();
        //    int i = 1;
        //    foreach(Request r in requests)
        //    {
        //        Console.WriteLine($"Product Name:- {r.product_name}  Department Name:- {r.department_name} Quantity Requested:- {r.quantity} Current Status:- {r.status}");
        //    }
        //}

        //public void requestProduct()
        //{
        //    List<Department> list = database_manager.getDepartments();
        //    int i = 1;
        //    foreach (Department department in list)
        //    {
        //        Console.WriteLine(i + " " + department.Name);
        //        i++;
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Please choose a department from above list");
        //    Console.Write("Department No:- ");
        //    int department_id = Convert.ToInt32(Console.ReadLine());

        //    if (department_id < 1 || department_id >= i)
        //    {
        //        Console.WriteLine("Invalid Input");
        //    }

        //    List<Product> pr = list[department_id - 1].getProducts();

        //    int j = 1;

        //    foreach (Product product in pr)
        //    {
        //        Console.WriteLine(j + " " + product.Name + " Quantity:- " + product.Quantity);
        //        j++;
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Please choose a product from above list.");
        //    Console.WriteLine("Product No:- ");
        //    int product_id = Convert.ToInt32(Console.ReadLine());
        //    if (product_id < 1 || product_id >= j)
        //    {
        //        Console.WriteLine("Invalid input");
        //    }

        //    Console.WriteLine();
        //    Console.Write("Please specify quantity:- ");
        //    int quant = Convert.ToInt32(Console.ReadLine());
        //    if(quant < 1 || quant > pr[product_id - 1].Quantity)
        //    {
        //        Console.WriteLine("Invalid input. Application exiting");
        //    }

        //    employee.requestProduct(product_id-1, department_id-1, quant, pr[product_id - 1].Name, list[department_id-1].Name);
        //    Console.WriteLine();
        //    Console.WriteLine("Request Successful");
        //}
        //public void logged_asAdmin()
        //{
        //    Console.WriteLine("1. View Departments");
        //    Console.WriteLine("2. Create a new Department");
        //    Console.WriteLine("3. Create a new Product.");
        //    Console.WriteLine("4. Create a new Admin");
        //    Console.WriteLine("5. Review Requests");

        //    Console.WriteLine("Choose a Option from above");

        //    int i = Convert.ToInt32(Console.ReadLine());

        //    if(i == 1)
        //    {
        //        viewDepartment();
        //    }
        //    else if(i == 2)
        //    {
        //        createDepartment();
        //    }
        //    else if(i == 3)
        //    {
        //        createNewProduct();
        //    }
        //    else if(i == 4)
        //    {
        //        addAdmin();
        //    }
        //    else if(i == 5)
        //    {
        //        reviewRequest();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid Option");
        //    }

        //}

        //public void viewDepartment()
        //{
        //    List<Department> list = database_manager.getDepartments();
        //    int i = 1;
        //    foreach (Department department in list)
        //    {
        //        Console.WriteLine(i + " " + department.Name);
        //        i++;
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Please choose a department from above list");
        //    Console.Write("Department No:- ");
        //    int department_id = Convert.ToInt32(Console.ReadLine());

        //    if (department_id < 1 || department_id >= i)
        //    {
        //        Console.WriteLine("Invalid Input");
        //    }

        //    List<Product> pr = list[department_id - 1].getProducts();

        //    int j = 1;

        //    foreach (Product product in pr)
        //    {
        //        Console.WriteLine(j + " " + product.Name + " Quantity:- " + product.Quantity);
        //        j++;
        //    }
        //    //Console.WriteLine();
        //    //Console.WriteLine("Please choose a product from above list.");
        //    //Console.WriteLine("Product No:- ");
        //    //int product_id = Convert.ToInt32(Console.ReadLine());
        //    //if(product_id < 1 || product_id >= j)
        //    //{
        //    //    Console.WriteLine("Invalid input");
        //    //}

        //}



        //public void createDepartment()
        //{
        //    Console.WriteLine("Provide following info for creating new Department:- ");
        //    Console.WriteLine();
        //    Console.Write("Department Name:- ");
        //    string s = Console.ReadLine();
        //    ad.create_new_Department(s);

        //    Console.WriteLine();
        //    Console.WriteLine("New Department Created");
        //    logged_asAdmin();
        //}

        //public void createNewProduct()
        //{
        //    List<Department> list = database_manager.getDepartments();
        //    int i = 1;
        //    foreach (Department department in list)
        //    {
        //        Console.WriteLine(i + ". " + department.Name);
        //        i++;
        //    }
        //    Console.WriteLine();
        //    Console.WriteLine("Choose a Department from above List");
        //    Console.WriteLine();
        //    Console.Write("Department Number:- ");
        //    int department_id = Convert.ToInt32(Console.ReadLine());
        //    if (department_id < 1 || department_id >= i)
        //    {
        //        Console.WriteLine("Invalid Input");
        //    }

        //    Console.WriteLine();
        //    Console.WriteLine("Please provide following information for new Product");
        //    Console.Write("Name:- ");
        //    string s = Console.ReadLine();
        //    Console.Write("Quantity:- ");
        //    int quan = Convert.ToInt32(Console.ReadLine());
        //    ad.create_new_Product(s, list[department_id-1].Name, quan,department_id-1, list[department_id-1].Id);
        //    Console.WriteLine("New Product Added");
        //    Console.WriteLine();
        //    logged_asAdmin();
        //}

        //public void addAdmin()
        //{
        //    Console.WriteLine("Please give following information for New Admin Registration");
        //    Console.Write("Username - ");
        //    string s1 = Console.ReadLine();
        //    Console.Write("Email Address - ");
        //    string s2 = Console.ReadLine();
        //    Console.Write("Password - ");
        //    string s3 = Console.ReadLine();

        //    ad.Add_Admin(s1, s2, s3);

        //    Console.WriteLine("New admin added");
        //}

        //public void reviewRequest()
        //{
        //    List<Request> requests = database_manager.GetRequests();
        //    int i = 1;

        //    foreach(Request request in requests)
        //    {
        //        Console.WriteLine($"{i}. Product Name - {request.product_name} Department Name - {request.department_name}");
        //        i++;
        //    }
        //    Console.WriteLine();

        //    Console.WriteLine("Please select a request no.");
        //    Console.Write("Request No.- ");
        //    int request_id = Convert.ToInt32(Console.ReadLine());

        //    if(request_id  < 1  || request_id >= i)
        //    {
        //        Console.WriteLine("Invalid Input");
        //        return;
        //    }
        //    Console.WriteLine("Whether you want to accept the request. Answer in Yes or No");

        //    string s = Console.ReadLine();
        //    if(!s.Equals("Yes") && !s.Equals("No")){
        //        Console.WriteLine("Invalid Input");
        //    }

        //    ad.reviewRequest(request_id-1,s);
        //}
        //public void register()
        //{
        //    Console.WriteLine("Please give following information for registration");
        //    Console.Write("Username - ");
        //    string s = Console.ReadLine();
        //    Console.Write("Email - ");
        //    string s2 = Console.ReadLine();
        //    Console.Write("Password - ");
        //    string s3 = Console.ReadLine();

        //    auth_manager.register(s, s2, s3,0);
        //}

        //public void request_new_product()
        //{
        //    List<Department> list = database_manager.getDepartments();
        //    int i = 1;
        //    foreach(Department department in list)
        //    {
        //        Console.WriteLine(i + ". " + department.Name);
        //        i++;
        //    }

        //    Console.WriteLine("Choose a Department from above List");

        //    int department_id = Convert.ToInt32(Console.ReadLine());
        //    if(department_id < 1 || department_id >= i)
        //    {
        //        Console.WriteLine("Invalid Input");
        //    }

        //    List<Product> pr = database_manager.GetProducts(department_id-1);
        //    int j = 1;
        //    foreach(Product product in pr)
        //    {
        //        Console.WriteLine(j + " " + product.Name + " " + "Quantity - " + product.Quantity);
        //    }
        //    Console.WriteLine("Choose a Product from above List");
        //    int product_id = Convert.ToInt32(Console.ReadLine());
        //    if(product_id < 1 || product_id >= j)
        //    {
        //        Console.WriteLine("Invalid Input");
        //    }

        //}

    }
}
