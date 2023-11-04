using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Controller
{
    public class Controllers
    {
        public DepartmentController departmentController;
        public ProductController productController;

        private Controllers()
        {
            departmentController = new DepartmentController();
            productController = new ProductController();
        }

        private static Controllers _instance;

        public static Controllers Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Controllers();
                }
                return _instance;
            }
        }
    }
}
