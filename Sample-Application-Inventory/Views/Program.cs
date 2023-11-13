//using Sample_Application_Inventory.Views;
using Sample_Application_Inventory;
class Program
{
    public static App app;
    
    public static void Main(string[] args)
    {
        try
        {
            app = new App();
            app.Start();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Something went wrong. Application Exiting." + ex.ToString());
            Environment.Exit(0);
        }

    }
}
