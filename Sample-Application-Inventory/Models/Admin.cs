using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{
    public class Admin : User
    {
        public Admin(string user_name, string email_address, string password) : base(user_name, password, email_address)
        {

        }
    }
}
