namespace Sample_Application_Inventory.Models
{
    public class Admin : User
    {
        public Admin(string user_name, string email_address, string password) : base(user_name, password, email_address)
        {

        }
    }
}
