using Sample_Application_Inventory.DBInterface;
using Sample_Application_Inventory.Models;


namespace Sample_Application_Inventory.Database
{
    public class DBRequest : DBHandler<Request>, IDBRequest
    {
        Dictionary<string, Request> requestMap;


        private DBRequest() : base(FilePaths.requests_path)
        {
            requestMap = new Dictionary<string, Request>();
            foreach (Request r in values)
            {
                requestMap.Add(r.id, r);
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


        override public void Put(Request r)
        {
            base.Put(r);
            requestMap.Add(r.id, r);
            DBEmployee.Instance.UpdateInFile();
        }


        public void UpdateRequest()
        {
            UpdateInFile();

            DBEmployee.Instance.UpdateInFile();
            DBDepartment.Instance.UpdateInFile();
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
                
                if (request.status == StatusType.NotAddressed)
                {

                    ls.Add(request, i);
                }
                i++;
            }


            return ls;
        }


    }
}
