using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Models;
//using Sample_Application_Inventory.Controller;

//namespace Sample_Application_Inventory
//{


//    public sealed class database_manager
//    {
//        List<Department> departments;
//        List<Employee> employees;
//        List<Admin> admins;
//        List<Request> requests;
//        List<ExceptionModel> exceptions;
//        Dictionary<string, Product> products_map;
//        Dictionary<string, Department> departments_map;
//        Dictionary<string, Request> requests_map;
        



//        string department_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\departments.json";
//        string employees_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\employees.json";
//        string admins_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\admins.json";
//        string requests_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\requests.json";
//        string exceptions_path = "C:\\Users\\hbhargava\\source\\repos\\Sample-Application-Inventory\\Sample-Application-Inventory\\Data\\exceptions.json";
        

//        private static database_manager _instance = null;

//        private static readonly object lockObj = new object();

        


//        private database_manager()
//        {

//            string exceptions_data = File.ReadAllText(exceptions_path);

//            try
//            {
//                exceptions = JsonConvert.DeserializeObject<List<ExceptionModel>>(exceptions_data);
//                //throw new Exception();
//            }
//            catch(Exception e)
//            {
//                exceptions = new List<ExceptionModel>();
//                AddException(e.ToString());
//            }
//            string department_data = File.ReadAllText(department_path);
            
//            try
//            {
//                departments = JsonConvert.DeserializeObject<List<Department>>(department_data);
//            }
//            catch(Exception e)
//            {
//                departments = new List<Department>();
//                AddException(e.ToString());

//            }

//            string employees_data = File.ReadAllText(employees_path);

//            try
//            {
//                employees = JsonConvert.DeserializeObject<List<Employee>>(employees_data);
//            }
//            catch(Exception e)
//            {
//                employees = new List<Employee>();
//                AddException(e.ToString());
//            }
           
            


//            string admins_data = File.ReadAllText(admins_path);
//            try
//            {
//                admins = JsonConvert.DeserializeObject<List<Admin>>(admins_data);
//            }
//            catch(Exception e)
//            {
//                admins = new List<Admin>();
//                AddException(e.ToString());
//            }
            


//            string requests_data = File.ReadAllText(requests_path);
            
//            try
//            {
//                requests = JsonConvert.DeserializeObject<List<Request>>(requests_data);
//            }
//            catch(Exception e)
//            {
//                requests = new List<Request>();
//                AddException(e.ToString());
//            }

//            intialization();

//        }

//        public static database_manager Instance
//        {
//            get
//            {
//                lock (lockObj)
//                {
//                    if (_instance == null)
//                    {
//                        _instance = new database_manager();
//                    }
//                }
//                return _instance;
//            }
//        }


//        private void intialization()
//        {
//            products_map = new Dictionary<string, Product>();
//            departments_map = new Dictionary<string, Department>();
//            requests_map = new Dictionary<string, Request>();

//            foreach (Request r in requests)
//            {
//                requests_map.Add(r.Id, r);
//            }

//            foreach (Department d in departments)
//            {
//                departments_map.Add(d.Id, d);
//                List<Product> department_product = d.getProducts();
//                foreach (Product p in department_product)
//                {
//                    products_map.Add(p.Id, p);
//                }
//            }
//        }


//        private  void updateDepartment()
//        {
//            string new_department_data = JsonConvert.SerializeObject(departments);
//            File.WriteAllText(department_path, new_department_data);
//        }
//        private  void updateEmployees()
//        {
//            string new_employee_data = JsonConvert.SerializeObject(employees);
//            File.WriteAllText(employees_path,new_employee_data);
//        }
//        private  void updateAdmins()
//        {
//            string new_admins_data = JsonConvert.SerializeObject(admins);
//            File.WriteAllText(admins_path, new_admins_data);
//        }
//        private  void updateRequests()
//        {
//            string new_requests_data = JsonConvert.SerializeObject(requests);
//            File.WriteAllText(requests_path, new_requests_data);
//        }

//        private void updateExceptions()
//        {
//            string new_exceptions_data = JsonConvert.SerializeObject(exceptions);
//            File.WriteAllText(exceptions_path, new_exceptions_data);
//        }

//        private void update<T>(string path,List<T> list)
//        {
//            string new_data = JsonConvert.SerializeObject(list);
//            File.WriteAllText(path, new_data);
//        }





//        public void addEmployee(Employee e)
//        {
//            employees.Add(e);
//            //updateEmployees();

//            update<Employee>(employees_path, employees);
//        }
//        public void addDepartment(Department d)
//        {
//            departments.Add(d);
//            departments_map.Add(d.Id, d);
//            updateDepartment();
//        }
//        public  void addAdmin(Admin a)
//        {
//            admins.Add(a);
//            updateAdmins();
//        }

//        public List<Department> getDepartments()
//        {
//            return departments;
//        }
//        public List<Employee> getEmployees()
//        {
//            return employees;
//        }

//        public List<Admin> getAdmins()
//        {
//            return admins;
//        }

        

//        public  void AddProduct(Product p,int department_index)
//        {
//            departments[department_index].Add_Product(p);
//            products_map.Add(p.Id, p);
//            updateDepartment();
//        }

//        public void AddRequest(Request r)
//        {
//            requests.Add(r);
//            requests_map.Add(r.Id, r);
//            updateRequests();
//            updateEmployees();
//        }

//        public List<Product> GetProducts(int department_id)
//        {
//            return departments[department_id].getProducts();
//        }

//        public  List<Request> GetRequests()
//        {
//            return requests;
//        }

//        public void removeRequest(int request_id)
//        {
//            //requests.RemoveAt(request_id);
//            updateRequests();
//            updateEmployees();
//            updateDepartment();
//        }




//        public List<Request> getRequestsforEmployees(List<string> data)
//        {
//            List<Request> ls = new List<Request>();
//            foreach(string s in data)
//            {
//                ls.Add(requests_map.GetValueOrDefault(s));
//            }

//            //data.ForEach((d)=>ls.Add(requests_map.GetValueOrDefault(d)));
//            return ls;
//        }

//        public List<Product> getProductById(List<string> data)
//        {
//            List<Product> ls = new List<Product>();
//            foreach(string p in data)
//            {
//                ls.Add(products_map.GetValueOrDefault(p));
//            }
//            return ls;
//        }


//        public Dictionary<Request,int> getUnaddresedRequests()
//        {
//            Dictionary<Request, int> ls = new Dictionary<Request, int>();
//            int i = 0;


//            foreach (Request request in requests)
//            {
//                if (request.status_Id == 1)
//                {

//                    ls.Add(request, i);
//                }
//                i++;
//            }


//            return ls;
//        }

//        public void updateforReturnproduct()
//        {
//            updateDepartment();
//            updateEmployees();
//            intialization();
//        }

//        public void AddException(string message)
//        {
//            ExceptionModel exceptionMessage = new ExceptionModel(message);
//            exceptions.Add(exceptionMessage);
//            updateExceptions();
//        }
//    }
//}
