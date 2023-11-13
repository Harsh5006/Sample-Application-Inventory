using Sample_Application_Inventory.Models;


namespace Sample_Application_Inventory.ControllerInterface
{
    public interface IProductControllerEmployee
    {
        public Dictionary<Product, int> GetEmployeeProducts(Employee employee);
        public void ReturnProduct(Employee employee, Product product, int quantity,int productIndex);
        public Product GetProductById(string id);
    }
}
