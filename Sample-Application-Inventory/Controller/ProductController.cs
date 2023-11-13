using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using Sample_Application_Inventory.ControllerInterface;


namespace Sample_Application_Inventory.Controller
{
    public class ProductController : IProductControllerEmployee,IProductControllerAdmin
    {
        public void CreateNewProduct(Product product,int departmentIndex)
        {
            DBDepartment.Instance.AddProduct(product, departmentIndex);            
        }


        public Dictionary<Product, int> GetEmployeeProducts(Employee employee)
        {
            List<Product> employeeAllocatedProducts = DBDepartment.Instance.GetEmployeesProduct(employee.products);
            Dictionary<Product, int> employeeAllocatedProductsWithQuantity = new Dictionary<Product, int>();
            int index = 0;
            foreach (Product product in employeeAllocatedProducts)
            {
                employeeAllocatedProductsWithQuantity.Add(product, employee.products.ElementAt(index++).Value);
            }

            return employeeAllocatedProductsWithQuantity;
        }

        public void ReturnProduct(Employee employee,Product product, int quantity, int productIndex)
        {
            int allocatedQuantity = employee.products.ElementAt(productIndex).Value;
            if (quantity == allocatedQuantity)
            {
                employee.products.Remove(product.id);
                product.quantity += quantity;
            }
            else
            {
                employee.products.Remove(product.id);
                employee.products.Add(product.id, allocatedQuantity - quantity);
                product.quantity += quantity;
            }

            DBDepartment.Instance.UpdateReturnProduct();
        }

        public void AddProductToEmployee(Employee employee,Product product, int quantity)
        {
            if (employee.products.ContainsKey(product.id))
            {
                int quant = employee.products.GetValueOrDefault(product.id);
                employee.products.Remove(product.id);
                employee.products.Add(product.id, quant + quantity);
            }
            else
            {
                employee.products.Add(product.id, quantity);
            }
        }

        public Product GetProductById(string id)
        {
            return DBDepartment.Instance.GetProductById(id);
        }
    }
}
