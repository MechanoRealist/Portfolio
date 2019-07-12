using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Autorepairshop_Case
{
    class Customer : IDatabaseObject
    {
        public int CustomerID { get; private set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string HomeAddress { get; set; }
        public int TelephoneNr { get; set; }
        public DateTime CreationDate { get; set; }



        public static void Menu()
        {
            int choice = ConsoleHelper.Menu(false, 2, Program.MenuBottom.TopBoundary + 2, Program.MenuBottom.LeftBoundary + 10, "Read/Edit current Customers(sorted by Customer ID)", "Read/Edit current Customers(sorted by Lastname)", "Create new Customer", "Delete Customer");
            switch (choice)
            {
                case 0:
                    Reader();
                    break;
                case 1:
                    ReaderSorted();
                    break;
                case 2:
                    Creator();
                    break;
                case 3:
                    Deletor();
                    break;
            }

            Program.Main();
        }
        public static void Deletor()
        {
            List<Customer> customers = GetList();
            string[] options = ExtractUnique(customers);
            int listIndex = ConsoleHelper.Menu(true, 1, 0, 0, options);
            Customer highlighted = customers[listIndex];
            highlighted.Delete();
        }
        public static void Creator()
        {
            Customer newCustomer = new Customer();
            string[] descriptions = new string[] { "Firstname: ", "Lastname: ", "HomeAddress: ", "TelephoneNr: " };
            Program.MenuLeft.PrintContent(descriptions);
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[0].Length, 0);
            newCustomer.Firstname = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[1].Length, 1);
            newCustomer.Lastname = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[2].Length, 2);
            newCustomer.HomeAddress = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[3].Length, 3);
            newCustomer.TelephoneNr = Convert.ToInt32(Console.ReadLine());
            newCustomer.Create();
            Program.MenuLeft.Clear();
        }
        public static void ReaderSorted()
        {
            Program.Customers.OrderBy(o => o.Lastname).ToList();
            Reader();
        }
        public static void Reader()
        {

            string[] options = ExtractUnique(Program.Customers);
            int listIndex = ConsoleHelper.Menu(true, 1, 0, 0, options);
            Customer highlighted = Program.Customers[listIndex];
            
            string[] descriptions = new string[] { "Firstname: ", "Lastname: ", "HomeAddress: ", "TelephoneNr: " };
            string[] lines = new string[]
            {
                descriptions[0] + highlighted.Firstname,
                descriptions[1] + highlighted.Lastname,
                descriptions[2] + highlighted.HomeAddress,
                descriptions[3] + highlighted.TelephoneNr

            };

            Program.MenuRight.PrintContent(lines);
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[0].Length, 0);
            string input;
            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.Firstname = input;
            }

            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[1].Length, 2);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.Lastname = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[2].Length, 4);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.HomeAddress = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[3].Length, 6);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.TelephoneNr = Convert.ToInt32(input);
            }
            //Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[4].Length, 8);

            highlighted.Update();
        }
        public static string[] ExtractUnique(List<Customer> list)
        {

            string[] options = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                options[i] = list[i].CustomerID.ToString() + " " + list[i].Lastname +", " + list[i].Firstname;
            }

            return options;
        }

        #region SQL Commands
        //Create og Remove arbejder på objektet selv.
        public int Create()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers(firstName,lastName,homeAddress,tlf) VALUES(@fname, @lname, @homeAddress, @tlf);");
            SqlParameter[] parameters = new SqlParameter[] { //SQL parametre begrænser hvad der kan indtastes i variablerne.
                new SqlParameter("@fname", SqlDbType.NVarChar, 60),
                new SqlParameter("@lname", SqlDbType.NVarChar, 60),
                new SqlParameter("@homeAddress", SqlDbType.NVarChar, 60),
                new SqlParameter("@tlf", SqlDbType.Int)
            };
            cmd.Parameters.AddRange(parameters);
            parameters[0].Value = Firstname;
            parameters[1].Value = Lastname;
            parameters[2].Value = HomeAddress;
            parameters[3].Value = TelephoneNr;

            return SQL.SqlNonQuery(cmd);
        }

        public int Update()
        {
            SqlCommand cmd = new SqlCommand("UPDATE Customers SET firstName=@fname, lastname=@lname, homeAddress=@homeAddress, tlf=@tlf WHERE customerID=@customerID");

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@fname", SqlDbType.VarChar, 255),
                new SqlParameter("@lname", SqlDbType.VarChar, 255),
                new SqlParameter("@homeAddress", SqlDbType.VarChar, 255),
                new SqlParameter("@tlf", SqlDbType.VarChar, 255),
                new SqlParameter("@customerID", SqlDbType.Int)
            };
            cmd.Parameters.AddRange(parameters);
            parameters[0].Value = Firstname;
            parameters[1].Value = Lastname;
            parameters[2].Value = HomeAddress;
            parameters[3].Value = TelephoneNr;
            parameters[4].Value = CustomerID;
            return SQL.SqlNonQuery(cmd);
        }

        public int Delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE customerID=@idParam;");
            SqlParameter idParam = new SqlParameter("@idParam", SqlDbType.Int);
            cmd.Parameters.Add(idParam);
            idParam.Value = CustomerID;

            return SQL.SqlNonQuery(cmd);
        }
        #endregion


        /// <summary>
        /// Henter tabellen Kunder fra databasen og lægger den ind i en liste af Kunde objekter
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetList()
        {
            List<Customer> customers = new List<Customer>();
            DataTable table = SQL.GetTable("SELECT * FROM Customers");
            DataTableReader reader = table.CreateDataReader();

            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    CustomerID = (int)reader.GetValue(0),
                    Firstname = (string)reader.GetValue(1),
                    Lastname = (string)reader.GetValue(2),
                    HomeAddress = (string)reader.GetValue(3),
                    TelephoneNr = (int)reader.GetValue(4),
                    CreationDate = (DateTime)reader.GetValue(5)
                });
            }
            return customers;
        }

        public static void PrintList(List<Customer> list)
        {
            foreach (Customer i in list)
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}{5,-20:dd-MM-yyyy}",
                    i.CustomerID, i.Firstname, i.Lastname, i.HomeAddress, i.TelephoneNr, i.CreationDate);
            }
        }
    }
}
