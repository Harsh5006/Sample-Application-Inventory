

using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.ControllerInterface
{
    public interface IProductControllerAdmin
    {
        public void AddProductToEmployee(Employee employee, Product p, int quantity);
        public void CreateNewProduct(Product product,int departmentIndex);
        public Product GetProductById(string id);
    }
}
