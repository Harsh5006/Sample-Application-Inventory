using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{
    public class Product
    {
        public string Id;
        public string Name;
        public string Department_Id;
        public int Quantity;


        public Product(string name, string Id, string department_Id, int Quantity)
        {
            Name = name;
            this.Id = Id;
            Department_Id = department_Id;
            this.Quantity = Quantity;
        }
    }
}
