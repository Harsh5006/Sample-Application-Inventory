

namespace Sample_Application_Inventory.Models
{
    public enum StatusType
    {
        NotAddressed = 1,
        Accepted = 2,
        Rejected = 3
    }
    public class Request
    {
        public string id;
        public string productId;
        public string departmentId;
        public string userId;
        public int quantity;
        public StatusType status;

        //public Request(string id, int product_id, int department_id, int quantity, string product_name, string department_name, string email_address)
        //{
        //    this.id = id;
        //    this.productId = product_id;
        //    this.departmentId = department_id;
        //    this.quantity = quantity;
        //    this.product_name = product_name;
        //    this.department_name = department_name;
        //    this.email_address = email_address;
        //    status = "Not addressed yet.";
        //    status_Id = (int)StatusType.NotAddressed;
        //}

        public Request(string productId,string departmentId,string userId,int quantity)
        {
            this.id = Guid.NewGuid().ToString();
            this.productId = productId;
            this.departmentId = departmentId;
            this.userId = userId;
            this.quantity = quantity;
            this.status = StatusType.NotAddressed;
        }
        
        //public void changeStatus(int num)
        //{
        //    status_Id = num;
        //}
    }
}
