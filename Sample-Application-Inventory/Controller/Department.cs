using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory
{
    internal class Department
    {
        public string Name;
        public  string Id;
        public  List<Product> products;

        public Department(string name,string id)
        {
            this.Name = name;
            this.Id = id;
            this.products = new List<Product>();
        }


        public void Add_Product(Product product)
        {
            products.Add(product);
        }

        public List<Product> getProducts()
        {
            return products;
        }
    }
}
