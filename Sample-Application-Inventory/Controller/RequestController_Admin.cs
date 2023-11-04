using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Controller
{
    class RequestController_Admin
    {


        public bool ReviewRequest(int request_id, string isAccepted)
        {
            if (isAccepted.Equals("Yes"))
            {
                return AcceptRequest(request_id);
            }
            else
            {
                return DeclineRequest(request_id);
            }
        }


        public bool AcceptRequest(int request_id)
        {
            List<Request> requests = DBRequest.Instance.Get();
            Request request = requests[request_id];
            int quantity_requested = request.quantity;

            int department_id = request.department_id;
            int product_id = request.product_id;

            List<Product> products = DBDepartment.Instance.GetProductsByDepartmentId(department_id);
            Product requested_product = products[product_id];

            if (quantity_requested <= requested_product.Quantity)
            {
                requested_product.Quantity -= quantity_requested;
                List<Employee> employees = DBEmployee.Instance.Get();

                foreach (Employee employee in employees)
                {
                    if (employee.email_address.Equals(request.email_address))
                    {
                        
                        Controllers.Instance.productController.addProduct(employee,requested_product, quantity_requested);
                        break;
                    }
                }

                request.status = "Accepted";
                request.changeStatus(2);
                DBRequest.Instance.updateRequest();
                return true;
            }
            else
            {
                requests[request_id].status = "Requested Quantity was not Available";
                requests[request_id].changeStatus(3);
                DBRequest.Instance.updateRequest();
                return false;
            }

        }
        public bool DeclineRequest(int request_id)
        {
            List<Request> req = DBRequest.Instance.Get();

            req[request_id].status = "Declined";
            req[request_id].changeStatus(3);
            DBRequest.Instance.updateRequest();
            return true;
        }

        public Dictionary<Request, int> GetUnaddressedRequests()
        {
            return DBRequest.Instance.getUnaddresedRequests();
        }
    }
}
