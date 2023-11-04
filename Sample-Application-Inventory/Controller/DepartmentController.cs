using Sample_Application_Inventory.Database;
using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Controller
{
    public class DepartmentController
    {
        public void create_new_Department(string name)
        {

            Department department = new Department(name, Guid.NewGuid().ToString());
            DBDepartment.Instance.put(department);
        }

        public List<Department> getDepartments()
        {
            return DBDepartment.Instance.Get();
        }
    }
}
