using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{


    public class User
    {
        public string user_name;
        public string password;
        public string email_address;

        public User(string user_name, string password, string email_address)
        {
            this.user_name = user_name;
            this.password = password;
            this.email_address = email_address;
        }
    }
}
