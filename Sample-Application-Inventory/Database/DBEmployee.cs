using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.Database
{
    public class DBEmployee : DBHandler<Employee>
    {
        private DBEmployee() : base(FilePaths.employees_path)
        {
            
        }

        private static DBEmployee _instance;

        public static DBEmployee Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBEmployee();
                }
                return _instance;
            }

        }

        

    }
}
