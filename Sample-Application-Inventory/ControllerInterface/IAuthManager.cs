using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models.Enums;

namespace Sample_Application_Inventory.ControllerInterface
{
    public interface IAuthManager
    {
        object Login(string email, string password);
        bool Register(User user, Roles role);
    }
}