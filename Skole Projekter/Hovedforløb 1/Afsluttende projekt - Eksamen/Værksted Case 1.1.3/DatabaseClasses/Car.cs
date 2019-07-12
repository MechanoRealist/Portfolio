using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Autorepairshop_Case
{
    class Car : IDatabaseObject 
    {
        public string Numberplate { get; set; } // property field for the car-object etc. - mirroring the columns 
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNr { get; set; }
        public int CustomerID { get; set; }
        public DateTime FirstSeen { get; set; }

        public static void Menu() // menu for car
        {
            int choice = ConsoleHelper.Menu(false,3, Program.MenuBottom.TopBoundary + 2, Program.MenuBottom.LeftBoundary + 10, "Read/Edit current Car", "Create new Car", "Delete a Car");
            switch (choice)
            {
                case 0:
                    Reader();
                    break;
                case 1:
                    Creator();
                    break;
                case 2:
                    Deletor();
                    break;
            }
            
            Program.Main(); // return to MAIN menu (functioning a little as loop)
        }
        public static void Deletor()
        {
            string[] options = ExtractUnique(Program.Cars);
            int listIndex = ConsoleHelper.Menu(true, 1, 0, 0, options); // creating a menu from the extracted data
            Car highlighted = Program.Cars[listIndex]; // extracting item and isolating the item, which means a focus on chosen choice in menu
            highlighted.Delete(); // executing the delete-method on the isolated item
        }
        public static void Creator()
        {
            Car newCar = new Car(); // instantiates new Car-object
            string[] descriptions = new string[] { "Plate: ", "Brand: ", "Model: ", "Serial Number: ", "Owner ID: " }; 
            Program.MenuLeft.PrintContent(descriptions);
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[0].Length, 0); // positions input
            newCar.Numberplate = Console.ReadLine(); // gets input into the object
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[1].Length, 2);
            newCar.Brand = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[2].Length, 4);
            newCar.Model = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[3].Length, 6);
            newCar.SerialNr = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[4].Length, 8);
            newCar.CustomerID = Convert.ToInt32(Console.ReadLine());
            newCar.Create(); // executing the create-method on the object
            Program.MenuLeft.Clear();
        }
        public static void Reader()
        {
            string[] options = ExtractUnique(Program.Cars);
            int listIndex = ConsoleHelper.Menu(true, 1, 0, 0, options);
            Car highlighted = Program.Cars[listIndex];
            string[] descriptions = new string[] { "Licence Plate: ", "Brand: ", "Model: ", "Serial Number: ", "CustomerID: ", "First Seen: " };
            string[] lines = new string[] // bundling descriptions and data for later use (print)
            {
                descriptions[0] + highlighted.Numberplate, 
                descriptions[1] + highlighted.Brand,
                descriptions[2] + highlighted.Model,
                descriptions[3] + highlighted.SerialNr,
                descriptions[4] + highlighted.CustomerID,
                descriptions[5] + highlighted.FirstSeen
            };

            Program.MenuRight.PrintContent(lines); // NOW it is Later
            string input;
            
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[1].Length, 2); // set cursor to the right of description

            input = Console.ReadLine();
            if (!(input == "")) // checking input is not empty - do fill in
            {
                highlighted.Brand = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[2].Length, 4);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.Model = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[3].Length, 6);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.SerialNr = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[4].Length, 8);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.CustomerID = Convert.ToInt32(input);
            }

            highlighted.Update(); // executing the update-method on the object
        }
        public static string[] ExtractUnique(List<Car> list) // exstracts data for display in menu (left)
        {

            string[] options = new string[list.Count]; // creates an array with the same size as the list
            for (int i = 0; i < list.Count; i++)
            {
                options[i] = list[i].CustomerID.ToString() + "    " + list[i].Numberplate; // copying data from objects to string array
            }

            return options;
        }


        //Tilføjer en Bil til databasen
        #region SQL Commands
        public int Create()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Cars(numberplate, brand, model, serialNr, customerID) VALUES(@numberplate, @brand, @model, @serialNr, @customerID);"); // creates query cmd for later use
            SqlParameter[] parameters = new SqlParameter[] { // creates the parameter-types corresponding with columns in the sql-database table
                new SqlParameter("@numberplate", SqlDbType.VarChar, 255),
                new SqlParameter("@brand", SqlDbType.VarChar, 255),
                new SqlParameter("@model", SqlDbType.VarChar, 255),
                new SqlParameter("@serialNr", SqlDbType.VarChar, 255),
                new SqlParameter("@customerID", SqlDbType.Int)
            };
            cmd.Parameters.AddRange(parameters); // 'fuses' parameters to the cmd
            parameters[0].Value = Numberplate;
            parameters[1].Value = Brand;
            parameters[2].Value = Model;
            parameters[3].Value = SerialNr;
            parameters[4].Value = CustomerID;
            return SQL.SqlNonQuery(cmd); // sends the cmd to the sql-class
        }

        public int Update() // see create-method
        {
            SqlCommand cmd = new SqlCommand("UPDATE Cars SET brand=@Brand, model=@Model, serialNr=@SerialNr WHERE customerID=@customerID");
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@brand", SqlDbType.VarChar, 255),
                new SqlParameter("@model", SqlDbType.VarChar, 255),
                new SqlParameter("@serialNr", SqlDbType.VarChar, 255),
                new SqlParameter("@customerID", SqlDbType.Int)
            };
            cmd.Parameters.AddRange(parameters);
            parameters[0].Value = Brand;
            parameters[1].Value = Model;
            parameters[2].Value = SerialNr;
            parameters[3].Value = CustomerID;
            return SQL.SqlNonQuery(cmd);

        }

        
        public int Delete() // see create-method
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Cars WHERE numberplate=@idParam;");
            SqlParameter idParam = new SqlParameter("@idParam", SqlDbType.VarChar);
            cmd.Parameters.Add(idParam);
            idParam.Value = Numberplate;

            return SQL.SqlNonQuery(cmd);
        }
        #endregion

        public static List<Car> GetList() 
        {
            List<Car> cars = new List<Car>(); // creates a new list of the Car-object 
            DataTable table = SQL.GetTable("SELECT * FROM Cars"); // mirroring sql into the table
            DataTableReader reader = table.CreateDataReader(); 

            while (reader.Read()) // using reader to read the table
            {
                cars.Add(new Car // adding new Car-object with data (adding new Car to the list)
                {
                    Numberplate = (string)reader.GetValue(0),
                    Brand = (string)reader.GetValue(1),
                    Model = (string)reader.GetValue(2),
                    SerialNr = (string)reader.GetValue(3),
                    CustomerID = (int)reader.GetValue(4),
                    FirstSeen = (DateTime)reader.GetValue(5)
                });
            }
            return cars; // returning the Car-list
        }
        
    }
}
