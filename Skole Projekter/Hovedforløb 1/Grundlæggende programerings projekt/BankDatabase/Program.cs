using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running) //Programmet kører til running er false
            {
                switch (UserInterface.Start()) //Menu valg for hovedmenuen
                {
                    case 'A':
                        UserInterface.KundeMenu();
                        break;
                    case 'S':
                        UserInterface.KontoMenu();
                        break;
                    case 'Q':
                        running = false;
                        break;
                }
            }
        }

        #region Deprecated
        private static void PrintTable(DataTable dataTable)
        {
            DataTableReader reader = dataTable.CreateDataReader();
            //dataTable.Columns
            foreach (DataColumn d in dataTable.Columns)
            {
                Console.Write(string.Format("{0,-20}", d.ColumnName));
            }
            Console.Write("\r\n\r\n");
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (reader.GetFieldType(i) == typeof(System.DateTime))
                    {
                        Console.Write(string.Format("{0,-20:dd-MM-yyyy}", reader.GetValue(i)));
                    }
                    else
                    {
                        Console.Write(string.Format("{0,-20}", reader.GetValue(i)));
                    }
                }
                Console.WriteLine();
            }
        }
        #endregion
    }

}

