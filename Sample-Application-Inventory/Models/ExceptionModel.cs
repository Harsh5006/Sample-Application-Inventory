using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Application_Inventory.Models
{
    public class ExceptionModel
    {
        public string exceptionDescription;
        public DateTime dateTime;

        public ExceptionModel(string s)
        {
            this.exceptionDescription = s;
            dateTime = DateTime.Now;
        }
    }
}
