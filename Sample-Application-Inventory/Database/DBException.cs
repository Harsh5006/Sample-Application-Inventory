using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Database
{
    public class DBException : DBHandler<ExceptionModel>
    {


        private DBException() : base(FilePaths.exceptions_path)
        {
            
        }

        private static DBException _instance;

        public static DBException Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new DBException();
                }
                return _instance;
            }
            
        }


    }
}
