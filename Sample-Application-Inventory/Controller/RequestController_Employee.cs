using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Controller
{
    class RequestController_Employee
    {
        Employee employee;
        public RequestController_Employee(Employee employee)
        {
            this.employee = employee;
        }
        public void RequestProduct(int product_id, int department_id, int quantity, string product_name, string department_name)
        {
            Request r = new Request(Guid.NewGuid().ToString(), product_id, department_id, quantity, product_name, department_name, employee.email_address);
            employee.requests.Add(r.Id);
            DBRequest.Instance.put(r);
        }

        public List<Request> GetEmployeeRequests()
        {
            List<Request> ls = DBRequest.Instance.getEmployeeReqeusts(employee.requests);
            return ls;
        }

    }
}
