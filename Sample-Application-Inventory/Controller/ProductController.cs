using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Controller
{
    public class ProductController
    {
        public void CreateNewProduct(string name, string department_name, int quantity, int department_id, string d_id)
        {
            Product product = new Product(name, Guid.NewGuid().ToString(), d_id, quantity);
            DBDepartment.Instance.AddProduct(product, department_id);
        }


        public Dictionary<Product, int> GetEmployeeProducts(Employee employee)
        {
            List<string> ls = new List<string>();
            foreach (var product in employee.products)
            {
                ls.Add(product.Key);
            }

            //Dictinary<string,Product> product_map = 


            //List<Product> ls = new List<Product>();
            //foreach (string p in data)
            //{
            //    ls.Add(products_map.GetValueOrDefault(p));
            //}
            //return ls;


            List<Product> ls1 = DBDepartment.Instance.GetEmployeesProduct(ls);
            Dictionary<Product, int> dict = new Dictionary<Product, int>();
            int i = 0;
            foreach (Product product in ls1)
            {
                dict.Add(product, employee.products.ElementAt(i++).Value);
            }

            return dict;
        }

        public void returnProduct(Employee employee,Product p, int quantity, int product_id)
        {
            int quant = employee.products.ElementAt(product_id).Value;
            if (quantity == quant)
            {
                employee.products.Remove(p.Id);
                p.Quantity += quantity;
            }
            else
            {
                employee.products.Remove(p.Id);
                employee.products.Add(p.Id, quant - quantity);
                p.Quantity += quantity;
            }

            DBDepartment.Instance.UpdateReturnProduct();
        }

        public void addProduct(Employee employee,Product p, int quantity)
        {
            if (employee.products.ContainsKey(p.Id))
            {
                int quant = employee.products.GetValueOrDefault(p.Id);
                employee.products.Remove(p.Id);
                employee.products.Add(p.Id, quant + quantity);
            }
            else
            {
                employee.products.Add(p.Id, quantity);
            }
        }
    }
}
