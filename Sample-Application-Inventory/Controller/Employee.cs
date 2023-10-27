using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory
{
    internal class Employee : User
    {

        public Dictionary<string, int> products;
        public List<string> requests;
        

        


        public Employee(string user_name,string email_address,string password) : base(user_name,password,email_address,(int)roles.Employee)
        {
            this.products = new Dictionary<string,int>();
            this.requests = new List<string>();
        }



        public void requestProduct(int product_id,int department_id,int quantity,string product_name,string department_name)
        {
            Request r = new Request(database_manager.generateId(),product_id, department_id, quantity,product_name,department_name,email_address);
            requests.Add(r.Id);
            database_manager.AddRequest(r);
        }
        
        public void returnProduct()
        {

        }

        //public List<Product> getAllocatedProducts()
        //{

        //    List<string> ls = new List<string>();


        //    //List<Product> ls = database_manager.getProductById()
        //}

        public List<Request> getRequests()
        {
            List<Request> ls = database_manager.getRequestsforEmployees(requests);
            return ls;
        }

        public void addProduct(Product p,int quantity)
        {
            products.Add(p.Id, quantity);
        }
    }
}
