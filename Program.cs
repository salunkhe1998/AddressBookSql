using System.Data;
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

            Program program = new Program();
            ComponentModel componentModel = new ComponentModel();
            program.connection.Open();
            int option = 1;
            do
            {
                Console.WriteLine("Choose an option");
                Console.WriteLine("1 to Insert in AddressBook");
                Console.WriteLine("0 to EXIT");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Write("Enter the number of contacts you want to enter: ");
                        int count = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < count; i++)
                        {
                            program.InsertContact();
                        }
                        break;
                    default:
                        break;
                }
            } while (option != 0);
            program.connection.Close();
        }
        public void InsertContact()
        {
            ComponentModel componentModel = new ComponentModel();
            Console.WriteLine("\nFill in the details");
            Console.Write("Enter First Name: ");
            componentModel.FirstName = Console.ReadLine();
            if (componentModel.FirstName == "")
            {
                Console.WriteLine("First name can't be empty");
                return;
            }
            Console.Write("Enter Last Name: ");
            componentModel.LastName = Console.ReadLine();
            Console.Write("Enter Address: ");
            componentModel.Address = Console.ReadLine();
            Console.Write("Enter City: ");
            componentModel.City = Console.ReadLine();
            Console.Write("Enter State: ");
            componentModel.State = Console.ReadLine();
            Console.Write("Enter Zip Code: ");
            componentModel.ZipCode = Console.ReadLine();
            Console.Write("Enter Phone Number: ");
            componentModel.PhoneNumber = Console.ReadLine();
            Console.Write("Enter Email: ");
            componentModel.Email = Console.ReadLine();
            DisplayDetails(componentModel);
            InsertContact(componentModel);
            Console.WriteLine("Contact information for {0} {1} was saved to the database.\n",
                componentModel.FirstName, componentModel.LastName);
        }
        public void InsertContact(ComponentModel componentModel)
        {
            string SPstr = "dbo.InsertContact";
            SqlCommand cmd = new SqlCommand(SPstr, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", componentModel.FirstName);
            cmd.Parameters.AddWithValue("@LastName", componentModel.LastName);
            cmd.Parameters.AddWithValue("@Address", componentModel.Address);
            cmd.Parameters.AddWithValue("@City", componentModel.City);
            cmd.Parameters.AddWithValue("@State", componentModel.State);
            cmd.Parameters.AddWithValue("@ZipCode", componentModel.ZipCode);
            cmd.Parameters.AddWithValue("@PhoneNumber", componentModel.PhoneNumber);
            cmd.Parameters.AddWithValue("@Email", componentModel.Email);
            //cmd.ExecuteNonQuery();
        }
        public void DisplayDetails(ComponentModel componentModel)
        {
            Console.WriteLine("\n-------------------------------------------------------");
            Console.WriteLine("The details for {0} {1} are:\nAddress: {2}\nCity: {3}\nState: " +
                "{4}\nZip Code: {5}\nPhone Number: {6}\nEmail: {7}", componentModel.FirstName,
                componentModel.LastName, componentModel.Address, componentModel.City, componentModel.State, componentModel.ZipCode,
                componentModel.PhoneNumber, componentModel.Email);
            Console.WriteLine("-------------------------------------------------------\n");

        }
    }
}