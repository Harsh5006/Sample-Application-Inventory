using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.Database
{
    internal class DBAdmin : DBHandler<Admin>
    {


        private DBAdmin() : base(FilePaths.admins_path)
        {
        }


        private static DBAdmin _instance;

        public static DBAdmin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBAdmin();
                }
                return _instance;
            }
        }

    }
}
