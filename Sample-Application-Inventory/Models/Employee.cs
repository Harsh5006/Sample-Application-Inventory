using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{
    public class Employee : User
    {
        public Dictionary<string, int> products;
        public List<string> requests;



        public Employee(string user_name, string email_address, string password) : base(user_name, password, email_address)
        {
            this.products = new Dictionary<string, int>();
            this.requests = new List<string>();
        }


    }
}
