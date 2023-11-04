using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.Database
{
    public class DBDepartment : DBHandler<Department>
    {
        private Dictionary<string, Department> departmentMap;
        private Dictionary<string, Product> productMap;


        private DBDepartment() : base(FilePaths.department_path)
        {
            updateMap();
        }

        private void updateMap()
        {
            departmentMap = new Dictionary<string, Department>();
            productMap = new Dictionary<string, Product>();


            foreach (Department d in values)
            {
                departmentMap.Add(d.id, d);
                List<Product> department_product = d.GetProducts();
                foreach (Product p in department_product)
                {
                    productMap.Add(p.Id, p);
                }
            }
        }

        private static DBDepartment _instance;

        public static DBDepartment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBDepartment();
                }
                return _instance;
            }

        }


        public void AddProduct(Product p, int department_index)
        {
            values[department_index].AddProduct(p); 
            productMap.Add(p.Id, p);
            updateInFile();
        }

        public List<Product> GetProductsByDepartmentId(int department_id)
        {
            return values[department_id].GetProducts();
        }


        public List<Product> GetEmployeesProduct(List<string> data)
        {
            List<Product> ls = new List<Product>();
            foreach (string p in data)
            {
                ls.Add(productMap.GetValueOrDefault(p));
            }
            return ls;
        }


        public void UpdateReturnProduct()
        {
            updateInFile();
            DBEmployee.Instance.updateInFile();
            updateMap();
        }
    }
}
