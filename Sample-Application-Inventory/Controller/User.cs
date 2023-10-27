using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory
{

    enum roles
    {
        Admin = 1,
        Employee = 2
    }
    class User
    {
        public string user_name;
        public string password;
        public string email_address;
        public int role;

        public User(string user_name,string password,string email_address,int role)
        {
            this.user_name = user_name;
            this.password = password;
            this.email_address = email_address;
            this.role = role;
        }
    }
}
