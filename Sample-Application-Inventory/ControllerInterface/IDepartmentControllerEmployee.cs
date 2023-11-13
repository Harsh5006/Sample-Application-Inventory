using Sample_Application_Inventory.Models;


namespace Sample_Application_Inventory.ControllerInterface
{
    public interface IDepartmentControllerEmployee
    {
        public List<Department> GetAllDepartments();

        public Department GetDepartmentById(string id);
    }
}
