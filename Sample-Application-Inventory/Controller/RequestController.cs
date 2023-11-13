using Sample_Application_Inventory.ControllerInterface;
using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Controller
{
    public class RequestController : IRequestControllerEmployee, IRequestControllerAdmin
    {
        IProductControllerAdmin productController;
        public RequestController()
        {
            this.productController = new ProductController();
        }

        public bool ReviewRequest(int requestIndex, string isAccepted)
        {
            if (isAccepted.Equals("Yes"))
            {
                return AcceptRequest(requestIndex);
            }
            else
            {
                return DeclineRequest(requestIndex);
            }
        }


        public bool AcceptRequest(int requestIndex)
        {
            List<Request> requests = DBRequest.Instance.Get();
            Request request = requests[requestIndex];
            int quantityRequested = request.quantity;

            
            string productId = request.productId;

            Product productRequested = DBDepartment.Instance.GetProductById(productId);

            if (quantityRequested <= productRequested.quantity)
            {
                productRequested.quantity -= quantityRequested;
                List<Employee> employees = DBEmployee.Instance.Get();

                foreach (Employee employee in employees)
                {
                    if (employee.id.Equals(request.userId))
                    {

                        productController.AddProductToEmployee(employee, productRequested, quantityRequested);
                        break;
                    }
                }
                request.status = StatusType.Accepted;
                DBRequest.Instance.UpdateRequest();
                return true;
            }
            else
            {
                request.status = StatusType.Rejected;
                DBRequest.Instance.UpdateRequest();
                return false;
            }

        }
        public bool DeclineRequest(int request_id)
        {
            List<Request> requests = DBRequest.Instance.Get();

            Request request = requests[request_id];

            request.status = StatusType.Rejected;

            DBRequest.Instance.UpdateRequest();
            return true;
        }

        public Dictionary<Request, int> GetUnaddressedRequests()
        {
            return DBRequest.Instance.getUnaddresedRequests();
        }




        public void RequestProduct(Employee employee, Request request)
        {
            employee.requests.Add(request.id);
            DBRequest.Instance.Put(request);
        }

        public List<Request> GetEmployeeRequests(Employee employee)
        {
            List<Request> employeeRequests = DBRequest.Instance.getEmployeeReqeusts(employee.requests);
            return employeeRequests;
        }
    }
}
