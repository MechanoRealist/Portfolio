using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BankDatabase
{
    class Transaktion : DatabaseItem
    {
        public int Transaktionsnummer { get; private set; }
        public int Saldo { get; set; }
        public int Beløb { get; set; }
        public DateTime Dato { get; set; }
        public int Kontonummer { get; set; }

        //Create og Remove arbejder på objektet selv.
        public int CreateTransaktion()
        {
            return DatabaseAction.AddTransaction(Saldo, Beløb, Dato, Kontonummer);
        }
        public int RemoveTransaktion()
        {
            return DatabaseAction.RemoveTransaction(Transaktionsnummer);
        }
        /// <summary>
        /// Henter tabellen Transaktioner fra databasen og lægger den ind i en liste af Transaktion objekter
        /// </summary>
        /// <returns></returns>
        public static List<Transaktion> GetTransaktionerList()
        {
            List<Transaktion> transaktioner = new List<Transaktion>();
            DataTable table = DatabaseAction.GetTable("SELECT * FROM Transaktioner");
            DataTableReader reader = table.CreateDataReader();

            while (reader.Read())
            {
                transaktioner.Add(new Transaktion
                {
                    Transaktionsnummer = (int)reader.GetValue(0),
                    Saldo = (int)reader.GetValue(1),
                    Beløb = (int)reader.GetValue(2),
                    Dato = (DateTime)reader.GetValue(3),
                    Kontonummer = (int)reader.GetValue(4)
                });
            }
            return transaktioner;
        }
        /// <summary>
        /// Udskriver data fra en liste af Transaktion objekter i konsollen
        /// </summary>
        /// <param name="list"></param>
        public static void PrintList(List<Transaktion> list)
        {
            foreach (Transaktion t in list)
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20:dd-MM-yyyy}{4,-20}",
                    t.Transaktionsnummer, t.Saldo, t.Beløb, t.Dato, t.Kontonummer);
            }
        }
    }
}
