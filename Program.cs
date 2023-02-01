using System.Data.SqlClient;

namespace AdvancedAddressBookProblem
{
    public class Program
    {
        static string ConnectionStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PayRollService240;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionStr);

        public static void Main(string[] args)
        {
            Console.WriteLine("*****Welcome to Advance Addressbook Program.*****");

        }
    }
}