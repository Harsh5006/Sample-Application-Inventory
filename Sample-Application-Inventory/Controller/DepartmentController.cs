using Sample_Application_Inventory.ControllerInterface;
using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;


namespace Sample_Application_Inventory.Controller
{
    public class DepartmentController : IDepartmentControllerEmployee,IDepartmentControllerAdmin
    {
        public void CreateNewDepartment(string name)
        {

            Department department = new Department(name, Guid.NewGuid().ToString());
            DBDepartment.Instance.Put(department);
        }

        public List<Department> GetAllDepartments()
        {
            return DBDepartment.Instance.Get();
        }

        public Department GetDepartmentById(string id) {
            return DBDepartment.Instance.GetDepartmentById(id);
        }
    }
}
