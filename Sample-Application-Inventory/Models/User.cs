namespace Sample_Application_Inventory.Models
{


    public class User
    {
        public string id;
        public string username;
        public string password;
        public string emailAddress;

        public User(string userName, string password, string emailAddress)
        {
            this.id = Guid.NewGuid().ToString();
            username = userName;
            this.password = password;
            this.emailAddress = emailAddress;
        }
    }
}
