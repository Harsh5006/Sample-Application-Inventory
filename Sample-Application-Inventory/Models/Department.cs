namespace Sample_Application_Inventory.Models
{
    public class Department
    {
        public string name;
        public string id;
        public List<Product> products;

        public Department(string name, string id)
        {
            this.name = name;
            this.id = id;
            products = new List<Product>();
        }


        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
