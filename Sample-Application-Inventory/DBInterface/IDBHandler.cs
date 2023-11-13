namespace Sample_Application_Inventory.DBInterface
{
    public interface IDBHandler<T>
    {
        List<T> Get();
        void Put(T item);
        void UpdateInFile();
    }
}