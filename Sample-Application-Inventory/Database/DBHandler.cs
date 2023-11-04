using Newtonsoft.Json;
using Sample_Application_Inventory.Models;

namespace Sample_Application_Inventory.Database
{
    public class DBHandler<T>
    {
        protected List<T> values;
        private string path;

        protected DBHandler(string path)
        {
            this.path = path;

            try
            {
                string data = File.ReadAllText(path);
                values = JsonConvert.DeserializeObject<List<T>>(data);
            }
            catch(Exception ex)
            {
                values = new List<T>();
            }
            
        }


        public void updateInFile()
        {
            string newData = JsonConvert.SerializeObject(values);
            File.WriteAllText(path, newData);
        }
        

        public List<T> Get()
        {
            return values;
        }

        virtual public void put(T item)
        {
            values.Add(item);
            updateInFile();
        }
    }
}
