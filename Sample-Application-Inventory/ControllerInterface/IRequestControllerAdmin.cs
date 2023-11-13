using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.ControllerInterface
{
    public interface IRequestControllerAdmin
    {
        bool AcceptRequest(int request_id);
        bool DeclineRequest(int request_id);
        Dictionary<Request, int> GetUnaddressedRequests();
        bool ReviewRequest(int request_id, string isAccepted);
    }
}