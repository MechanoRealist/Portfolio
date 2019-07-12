using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Autorepairshop_Case
{
    class CarServicing : IDatabaseObject
    {
        public int VisitNr { get; private set; }
        public DateTime Arrival { get; set; }
        public string Numberplate { get; set; }
        public double Price { get; set; }   
        public string IssueDescription { get; set; }
        public string MechanicsNotes { get; set; }

        //Create og Remove arbejder på objektet selv.

        public static void Menu()
        {
            int choice = ConsoleHelper.Menu(false, 2, Program.MenuBottom.TopBoundary + 2, Program.MenuBottom.LeftBoundary + 10, "Read/Edit current Car Servicings", "Create new Car Servicings", "Delete Serving", "Search Car Servings");
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
                case 3:
                    CarSearcher();
                    break;
            }
            Program.Main();
        }
        public static void Deletor()
        {
            List<CarServicing> carServicings = GetList();
            string[] options = ExtractUnique(carServicings);
            int listIndex = ConsoleHelper.Menu(true, 1, 0, 0, options);
            CarServicing highlighted = carServicings[listIndex];
            highlighted.Delete();


        }
        public static void Creator()
        {
            CarServicing newServicing = new CarServicing();
            string[] descriptions = new string[] {"Plate: ", "Price: ", "Issue: ", "Note: " };
            Program.MenuLeft.PrintContent(descriptions);
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[0].Length, 0);
            newServicing.Numberplate = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[1].Length, 2);
            newServicing.Price = Convert.ToDouble(Console.ReadLine());
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[2].Length, 4);
            newServicing.IssueDescription = Console.ReadLine();
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + descriptions[3].Length, 6);
            newServicing.MechanicsNotes = Console.ReadLine();
            newServicing.Create();
            Program.MenuLeft.Clear();
        }

        public static void CarSearcher()
        {
            string[] info = new string[] { "Write the numberplate of the car.", "Plate: " };
            Program.MenuLeft.PrintContent(info);
            Console.SetCursorPosition(Program.MenuLeft.LeftBoundary + info[1].Length, 2);
            string input;
            input = Console.ReadLine();
            Reader(GetSearch(input));
        }

        public static void Reader()
        {
            Reader(Program.CarServicings);
        }
        
        public static void Reader(List<CarServicing> carServicings)
        {
            
            string[] options = ExtractUnique(carServicings);
            int listIndex = ConsoleHelper.Menu(true, 1, 0, 0, options);
            CarServicing highlighted = carServicings[listIndex];
            string[] descriptions = new string[] { "Last Worked on: ","Plate: ","Price: ",  "Issue: ","Note: " };
            string[] lines = new string[]
            {
                descriptions[0] + highlighted.Arrival.ToString(),
                descriptions[1] + highlighted.Numberplate,
                descriptions[2] + highlighted.Price.ToString(),
                descriptions[3] + highlighted.IssueDescription,
                descriptions[4] + highlighted.MechanicsNotes
            };

            Program.MenuRight.PrintContent(lines);
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[0].Length , 0);
            string input;
            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.Arrival = Convert.ToDateTime(input);
            }
            
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[1].Length, 2);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.Numberplate = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[2].Length, 4);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.Price = Convert.ToDouble(input);
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[3].Length, 6);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.IssueDescription = input;
            }
            Console.SetCursorPosition(Program.MenuRight.LeftBoundary + descriptions[4].Length, 8);

            input = Console.ReadLine();
            if (!(input == ""))
            {
                highlighted.MechanicsNotes = input;
            }
            highlighted.Update();
        }

        #region SQL Commands
        public int Create()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CarServicings(numberplate, price, issueDescription, mechanicsNotes) VALUES(@numberplate, @price, @issueDescription, @mechanicsNotes);");
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@numberplate", SqlDbType.VarChar, 255),
                new SqlParameter("@price", SqlDbType.Money),
                new SqlParameter("@issueDescription", SqlDbType.Text),
                new SqlParameter("@mechanicsNotes", SqlDbType.Text)
            };
            cmd.Parameters.AddRange(parameters);

            parameters[0].Value = Numberplate;
            parameters[1].Value = Price;
            parameters[2].Value = IssueDescription;
            if (MechanicsNotes == "")
            {
                parameters[3].Value = DBNull.Value;
            }
            else
            {
                parameters[3].Value = MechanicsNotes;
            }

            return SQL.SqlNonQuery(cmd);
        }

        public int Update()
        {
            SqlCommand cmd = new SqlCommand("UPDATE CarServicings SET arrival=@arrival, numberplate=@numberplate, price=@price, issueDescription=@issueDescription, mechanicsNotes=@mechanicsNotes WHERE visitNr=@visitNr");

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@visitNr", SqlDbType.Int),
                new SqlParameter("@arrival", SqlDbType.Date),
                new SqlParameter("@numberplate", SqlDbType.VarChar, 255),
                new SqlParameter("@price", SqlDbType.Money),
                new SqlParameter("@issueDescription", SqlDbType.Text),
                new SqlParameter("@mechanicsNotes", SqlDbType.Text)
            };
            cmd.Parameters.AddRange(parameters);

            parameters[0].Value = VisitNr;
            parameters[1].Value = Arrival;
            parameters[2].Value = Numberplate;
            parameters[3].Value = Price;
            parameters[4].Value = IssueDescription;
            if (MechanicsNotes == "")
            {
                parameters[5].Value = DBNull.Value;
            }
            else
            {
                parameters[5].Value = MechanicsNotes;
            }

            return SQL.SqlNonQuery(cmd);
        }

        //Fjerner en Værkstedsbesøg fra databasen
        public int Delete()
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM CarServicings WHERE visitNr=@idParam;");
            SqlParameter idParam = new SqlParameter("@idParam", SqlDbType.Int);
            cmd.Parameters.Add(idParam);
            idParam.Value = VisitNr;

            return SQL.SqlNonQuery(cmd);
        }
        #endregion


        
        public static List<CarServicing> GetList(string sqlString = "SELECT * FROM CarServicings")
        {
            List<CarServicing> carServicings = new List<CarServicing>();
            DataTable table = SQL.GetTable(sqlString);
            DataTableReader reader = table.CreateDataReader();

            while (reader.Read())
            {
                carServicings.Add(new CarServicing
                {
                    VisitNr = (int)reader.GetValue(0),
                    Arrival = (DateTime)reader.GetValue(1),
                    Numberplate = (string)reader.GetValue(2),
                    Price = Convert.ToDouble(reader.GetValue(3)),
                    IssueDescription = (string)reader.GetValue(4),
                    MechanicsNotes = reader.GetValue(5) == DBNull.Value ? "" : (string)reader.GetValue(4) // DBNull (SQL) så den kan genkendes i C#
                });
            }
            return carServicings;
        }

        //This will be fugly
        public static List<CarServicing> GetSearch(string searchString)
        {
            string sqlString = "SELECT * FROM CarServicings WHERE numberplate LIKE '%" + searchString + "%'";
            Program.MenuLeft.Clear();
            return GetList(sqlString);
        }

        public static string[] ExtractUnique(List<CarServicing> list)
        {
            string[] options = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                options[i] = list[i].VisitNr.ToString() + "    " + list[i].Numberplate;
            }
            return options;
        }

        #region example code
        public static void PrintList(List<IDatabaseObject> list)
        {
            if (list.GetType() == typeof(CarServicing))
            {

            }
            foreach (CarServicing i in list)
            {
                Console.WriteLine("{0,-20}{1,-20:dd-MM-yyyy}{2,-20}{3,-20}{4,-20}{5,-20}",
                    i.VisitNr, i.Arrival, i.Numberplate, i.Price, i.IssueDescription, i.MechanicsNotes);
            }

        }
        #endregion
    }
}
