using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BankDatabase
{
    class Konto : DatabaseItem
    {
        public int Kontonummer { get; private set; }
        public int Saldo { get; set; }
        public string Kontotype { get; set; }
        public DateTime Opretelsesdato { get; set; }
        public int Kundenummer { get; set; }

        //Create og Remove arbejder på objektet selv.
        public int CreateKonto()
        {
            return DatabaseAction.AddAccount(Saldo, Kontotype, Opretelsesdato, Kundenummer);
        }
        public int RemoveKonto()
        {
            return DatabaseAction.RemoveAccount(Kontonummer);
        }
        /// <summary>
        /// Henter tabellen Konti fra databasen og lægger den ind i en liste af Konto objekter
        /// </summary>
        /// <returns></returns>
        public static List<Konto> GetKontiList()
        {
            List<Konto> konti = new List<Konto>();
            DataTable table = DatabaseAction.GetTable("SELECT * FROM Konti");
            DataTableReader reader = table.CreateDataReader();

            while (reader.Read())
            {
                konti.Add(new Konto
                {
                    Kontonummer = (int)reader.GetValue(0),
                    Saldo = (int)reader.GetValue(1),
                    Kontotype = (string)reader.GetValue(2),
                    Opretelsesdato = (DateTime)reader.GetValue(3),
                    Kundenummer = (int)reader.GetValue(4)
                });
            }
            return konti;
        }
        /// <summary>
        /// Udskriver data fra en liste af Konto objekter i konsollen
        /// </summary>
        /// <param name="list"></param>
        public static void PrintList(List<Konto> list)
        {
            foreach (Konto k in list)
            {
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20:dd-MM-yyyy}{4,-20}",
                    k.Kontonummer, k.Saldo, k.Kontotype, k.Opretelsesdato, k.Kundenummer);
            }
        }
    }
}
