using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
//using Sample_Application_Inventory.Controller;

namespace Sample_Application_Inventory
{


    static class database_manager
    {
        static private List<Department> departments;
        static private List<Employee> employees;
        static private List<Admin> admins;
        static private List<Request> requests;
        static public Dictionary<string, Product> products_map;
        static public Dictionary<string, Department> departments_map;
        static public Dictionary<string, Request> requests_map;
        //static private List<Product> products;



        static private string department_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\departments.json";
        static private string employees_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\employees.json";
        static private string admins_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\admins.json";
        static private string requests_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\requests.json";
        //static private string products_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Database\\products.json";


        static database_manager()
        {
            string department_data = File.ReadAllText(department_path);
            departments = JsonConvert.DeserializeObject<List<Department>>(department_data);
            if (departments == null)
            {
                departments = new List<Department>();
            }

            string employees_data = File.ReadAllText(employees_path);
            employees = JsonConvert.DeserializeObject<List<Employee>>(employees_data);
            if(employees == null)
            {
                employees = new List<Employee>();
            }


            string admins_data = File.ReadAllText(admins_path);
            admins = JsonConvert.DeserializeObject<List<Admin>>(admins_data);
            if(admins == null)
            {
                admins = new List<Admin>();
            }


            string requests_data = File.ReadAllText(requests_path);
            requests = JsonConvert.DeserializeObject<List<Request>>(requests_data);
            if (requests == null)
            {
                requests = new List<Request>();
            }

            intialization();
        }
        static void intialization()
        {
            products_map = new Dictionary<string, Product>(); ;
            departments_map = new Dictionary<string, Department>();
            requests_map = new Dictionary<string, Request>();

            foreach(Request r in requests)
            {
                requests_map.Add(r.Id, r);
            }
            foreach(Department d in departments)
            {
                departments_map.Add(d.Id, d);
                List<Product> department_product = d.getProducts();
                foreach(Product p in department_product)
                {
                    products_map.Add(p.Id, p);
                }
            }
            
        }


        private static void updateDepartment()
        {
            string new_department_data = JsonConvert.SerializeObject(departments);
            File.WriteAllText(department_path, new_department_data);
        }
        private static void updateEmployees()
        {
            string new_employee_data = JsonConvert.SerializeObject(employees);
            File.WriteAllText(employees_path,new_employee_data);
        }
        private static void updateAdmins()
        {
            string new_admins_data = JsonConvert.SerializeObject(admins);
            File.WriteAllText(admins_path, new_admins_data);
        }
        private static void updateRequests()
        {
            string new_requests_data = JsonConvert.SerializeObject(requests);
            File.WriteAllText(requests_path, new_requests_data);
        }


        public static void addEmployee(Employee e)
        {
            employees.Add(e);
            updateEmployees();
        }
        public static void addDepartment(Department d)
        {
            departments.Add(d);
            departments_map.Add(d.Id, d);
            updateDepartment();
        } 
        public static void addAdmin(Admin a)
        {
            admins.Add(a);
            updateAdmins();
        }

        public static List<Department> getDepartments()
        {
            return departments;
        }
        public static List<Employee> getEmployees()
        {
            return employees;
        }

        public static List<Admin> getAdmins()
        {
            return admins;
        }

        public static void RemoveDepartment(Department d)
        {
            foreach(Department e in departments)
            {
                if(d == e)
                {
                    departments.Remove(e);
                }
            }
            updateDepartment();
        }

        public static void AddProduct(Product p,int department_index)
        {
            departments[department_index].Add_Product(p);
            products_map.Add(p.Id, p);
            updateDepartment();
        }

        public static void AddRequest(Request r)
        {
            requests.Add(r);
            requests_map.Add(r.Id, r);
            updateRequests();
            updateEmployees();
        }

        public static List<Product> GetProducts(int department_id)
        {
            return departments[department_id].getProducts();
        }

        public static List<Request> GetRequests()
        {
            return requests;
        }

        public static void removeRequest(int request_id)
        {
            //requests.RemoveAt(request_id);
            updateRequests();
            updateEmployees();
            updateDepartment();
        }

        public static string generateId()
        {
            StringBuilder builder = new StringBuilder();
            Enumerable
               .Range(65, 26)
                .Select(e => ((char)e).ToString())
                .Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
                .Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
                .OrderBy(e => Guid.NewGuid())
                .Take(11)
                .ToList().ForEach(e => builder.Append(e));
            string id = builder.ToString();

            return id;
        }



        public static List<Request> getRequestsforEmployees(List<string> data)
        {
            List<Request> ls = new List<Request>();
            foreach(string s in data)
            {
                ls.Add(requests_map.GetValueOrDefault(s));
            }
            return ls;
        }

        public static List<Product> getProductById(List<string> data)
        {
            List<Product> ls = new List<Product>();
            foreach(string p in data)
            {
                ls.Add(products_map.GetValueOrDefault(p));
            }
            return ls;
        }
    }
}
