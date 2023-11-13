
using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.Models.Enums;

namespace Sample_Application_Inventory
{
    class AdminController
    {
        public bool AddAdmin(User user)
        {   
            return AuthManager.Instance.Register(user,Roles.Admin);
        }

        public List<Employee> GetEmployees()
        {
            return DBEmployee.Instance.Get();
        }   
    }
}
