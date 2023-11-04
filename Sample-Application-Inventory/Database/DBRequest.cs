using Sample_Application_Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sample_Application_Inventory.Database
{
    public class DBRequest : DBHandler<Request>
    {
        Dictionary<string, Request> requestMap;


        private DBRequest() : base(FilePaths.requests_path)
        {
            foreach (Request r in values)
            {
                requestMap.Add(r.Id, r);
            }
        }

        private static DBRequest _instance;

        public static DBRequest Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBRequest();
                }
                return _instance;
            }

        }


        override public void put(Request r)
        {
            base.put(r);
            requestMap.Add(r.Id, r);
            DBEmployee.Instance.updateInFile();
        }


        public void updateRequest()
        {
            updateInFile();

            DBEmployee.Instance.updateInFile();
            DBDepartment.Instance.updateInFile();
        }


        public List<Request> getEmployeeReqeusts(List<string> data)
        {
            List<Request> ls = new List<Request>();
            foreach (string s in data)
            {
                ls.Add(requestMap.GetValueOrDefault(s));
            }

            return ls;
        }


        public Dictionary<Request, int> getUnaddresedRequests()
        {
            Dictionary<Request, int> ls = new Dictionary<Request, int>();
            int i = 0;


            foreach (Request request in values)
            {
                if (request.status_Id == 1)
                {

                    ls.Add(request, i);
                }
                i++;
            }


            return ls;
        }


    }
}
