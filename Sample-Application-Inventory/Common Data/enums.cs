using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{
    public enum admin_homepage_options
    {
        view_departments = 1,
        view_employees = 2,
        create_new_department = 3,
        create_new_product = 4,
        create_new_admin = 5,
        review_requests = 6,
        logout = 7,
        Exit = 8,
    }

    enum employee_homepage_options
    {
        ViewPreviouslyAllocatedProducts = 1,
        ViewPreviouslyMadeRequests = 2,
        RequestProduct = 3,
        ReturnProduct = 4,
        Logout = 5,
        Exit = 6
    }

    public enum roles
    {
        Admin = 1,
        Employee = 2
    }

    enum options
    {
        login = 1,
        register = 2,
        exit = 3
    }




}
