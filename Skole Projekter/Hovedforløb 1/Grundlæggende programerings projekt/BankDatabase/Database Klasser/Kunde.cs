using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace BankDatabase
{
    class Kunde : DatabaseItem
    {
        public int Kundenummer { get; private set; }
        public DateTime Oprettelsesdato { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Organisation { get; set; }

        //Create og Remove arbejder på objektet selv.
        public int CreateKunde()
        {
            return DatabaseAction.AddCustomer(Oprettelsesdato, Fornavn, Efternavn, Organisation);
        }

        public int RemoveKunde()
        {
            return DatabaseAction.RemoveCustomer(Kundenummer);
        }
        /// <summary>
        /// Henter tabellen Kunder fra databasen og lægger den ind i en liste af Kunde objekter
        /// </summary>
        /// <returns></returns>
        public static List<Kunde> GetKunderList()
        {
            List<Kunde> kunder = new List<Kunde>();
            DataTable table = DatabaseAction.GetTable("SELECT * FROM Kunder");
            DataTableReader reader = table.CreateDataReader();

            while (reader.Read())
            {
                kunder.Add(new Kunde
                {
                    Kundenummer = (int)reader.GetValue(0),
                    Oprettelsesdato = (DateTime)reader.GetValue(1),
                    Fornavn = (string)reader.GetValue(2),
                    Efternavn = (string)reader.GetValue(3),
                    Organisation = reader.GetValue(4) == DBNull.Value ? "" : (string)reader.GetValue(4)
                });
            }
            return kunder;
        }
        /// <summary>
        /// Udskriver data fra en liste af Kunde objekter i konsollen
        /// </summary>
        /// <param name="list"></param>
        public static void PrintList(List<Kunde> list)
        {
            foreach(Kunde k in list)
            {
                Console.WriteLine("{0,-20}{1,-20:dd-MM-yyyy}{2,-20}{3,-20}{4,-20}",
                    k.Kundenummer, k.Oprettelsesdato, k.Fornavn, k.Efternavn, k.Organisation);
            }
        }
    }
}
