using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{
    enum status_type
    {
        NotAddressed = 1,
        Accepted = 2,
        Rejected = 3
    }
    public class Request
    {
        public string Id;
        public int product_id;
        public int department_id;
        public int quantity;
        public string product_name;
        public string department_name;
        public string email_address;
        public string status;
        public int status_Id;

        public Request(string Id, int product_id, int department_id, int quantity, string product_name, string department_name, string email_address)
        {
            this.Id = Id;
            this.product_id = product_id;
            this.department_id = department_id;
            this.quantity = quantity;
            this.product_name = product_name;
            this.department_name = department_name;
            this.email_address = email_address;
            status = "Not addressed yet.";
            status_Id = (int)status_type.NotAddressed;
        }
        public void changeStatus(int num)
        {
            status_Id = num;
        }
    }
}
