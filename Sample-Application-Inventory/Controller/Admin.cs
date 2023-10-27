using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
//using Sample_Application_Inventory.Controller;

namespace Sample_Application_Inventory
{
    internal class Admin : User
    {
        
       
        public Admin(string user_name,string email_address,string password) : base(user_name,password,email_address,(int)roles.Admin)
        {
        }
        
        public void create_new_Department(string name)
        {
            Department department = new Department(name,database_manager.generateId());
            database_manager.addDepartment(department);
        }
        public bool remove_Department(string name)
        {
            List<Department> ls = database_manager.getDepartments();
            foreach(Department department in ls)
            {
                if (department.Name.Equals(name))
                {
                    database_manager.RemoveDepartment(department);
                    return true;

                }
            }
            return false;
        }

        public void create_new_Product(string name, string department_name, int quantity,int department_id,string d_id)
        {
            Product product = new Product(name, database_manager.generateId(), d_id, quantity);
            database_manager.AddProduct(product, department_id);
        }

        public void remove_Product()
        {

        }

        public bool Add_Admin(string user_name,string email_address,string password)
        {
            return auth_manager.register(user_name, email_address, password,1);
        }
        

        public void reviewRequest(int request_id,string isAccepted)
        {
            if (isAccepted.Equals("Yes"))
            {
                acceptRequest(request_id);
            }
            else if (isAccepted.Equals("No"))
            {
                declineRequest(request_id);
            }
        }


        public bool acceptRequest(int request_id)
        {
            List<Request> requests = database_manager.GetRequests();
            Request request = requests[request_id];
            int quantity_requested = request.quantity;

            int department_id = request.department_id;
            int product_id = request.product_id;

            List<Product> products = database_manager.GetProducts(department_id);
            Product requested_product = products[product_id];

            if(quantity_requested <= requested_product.Quantity)
            {
                requested_product.Quantity -= quantity_requested;
                List<Employee> employees = database_manager.getEmployees();

                foreach (Employee employee in employees)
                {
                    if (employee.email_address.Equals(request.email_address))
                    {
                        employee.addProduct(requested_product, quantity_requested);
                        break;
                    }
                }

                request.status = "Accepted";
                database_manager.removeRequest(request_id);
                return true;
            }
            else
            {
                requests[request_id].status = "Requested Quantity Not Available";
                database_manager.removeRequest(request_id);
                return false;
            }

        }
        public void declineRequest(int request_id)
        {
            List<Request> req = database_manager.GetRequests();
            
            req[request_id].status = "Declined";
            database_manager.removeRequest(request_id);
        }
    }
}
