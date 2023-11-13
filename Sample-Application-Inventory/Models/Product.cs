

namespace Sample_Application_Inventory.Models
{
    public class Product
    {
        public string id;
        public string name;
        public string departmentId;
        public int quantity;


        public Product(string name, string departmentId, int quantity)
        {
            this.id = Guid.NewGuid().ToString();
            this.name = name;
            this.departmentId = departmentId;
            this.quantity = quantity;
        }
    }
}
