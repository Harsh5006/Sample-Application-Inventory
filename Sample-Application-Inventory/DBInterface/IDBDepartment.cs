using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.DBInterface
{
    public interface IDBDepartment : IDBHandler<Department>
    {
        void AddProduct(Product product, int departmentIndex);
        Department GetDepartmentById(string id);
        List<Product> GetEmployeesProduct(Dictionary<string,int> employeeProducts);
        Product GetProductById(string id);
        List<Product> GetProductsByDepartmentId(int departmentId);
        void UpdateReturnProduct();
    }
}