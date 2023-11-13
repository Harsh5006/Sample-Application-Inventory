using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.ControllerInterface
{
    public interface IRequestControllerEmployee
    {
        List<Request> GetEmployeeRequests(Employee employee);
        void RequestProduct(Employee employee, Request request);
    }
}