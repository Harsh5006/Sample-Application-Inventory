using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.DBInterface
{
    public interface IDBRequest : IDBHandler<Request>
    {
        List<Request> getEmployeeReqeusts(List<string> data);
        Dictionary<Request, int> getUnaddresedRequests();
        void Put(Request r);
        void UpdateRequest();
    }
}