using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace BankDatabase
{
    static class DatabaseAction
    {
        //Objekt til forbindelse til SQL server der befinder sig på denne computer.
        static SqlConnection sqlConnection = new SqlConnection(@"Server = localhost; Integrated Security = true; Database=Netbank");

        #region Other methods
        /// <summary>
        /// Henter en tabel fra databasen og lægger den ind i et DataTable objekt
        /// </summary>
        /// <param name="querySelect"></param>
        /// <returns></returns>
        public static DataTable GetTable(string querySelect)
        {
            SqlCommand cmd = new SqlCommand(querySelect, sqlConnection);
            DataTable table = new DataTable();
            sqlConnection.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                table.Load(reader);
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }
            return table;
        }
        /// <summary>
        /// Udfører SQL kommandoer som foretager ændringer i databasen
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private static int SqlNonQuery(params SqlCommand[] cmds)
        {
            int rowsAffected = 0;

            sqlConnection.Open();
            try
            {
                for (int i = 0; i < cmds.Length; i++)
                {
                    rowsAffected += cmds[i].ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }
            return rowsAffected;
        }
        #endregion

        #region Kunde
        //Tilføjer en kunde til databasen
        public static int AddCustomer(DateTime dato, string fornavn, string efternavn, string organisation)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Kunder VALUES(@oprettelsedato, @fname, @lname, @org);", sqlConnection);
            SqlParameter[] parameters = new SqlParameter[] { //SQL parametre begrænser hvad der kan indtastes i variablerne.
                new SqlParameter("@oprettelsedato", SqlDbType.Date),
                new SqlParameter("@fname", SqlDbType.NVarChar, 60),
                new SqlParameter("@lname", SqlDbType.NVarChar, 60),
                new SqlParameter("@org", SqlDbType.NVarChar, 60)
            };
            cmd.Parameters.AddRange(parameters);
            parameters[0].Value = dato;
            parameters[1].Value = fornavn;
            parameters[2].Value = efternavn;
            if (organisation == "")
            {
                parameters[3].Value = DBNull.Value;
            }
            else
            {
                parameters[3].Value = organisation;
            }

            return SqlNonQuery(cmd);
        }

        //Fjerner en kunde fra databasen
        public static int RemoveCustomer(int id)
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM Kunder WHERE Kundenummer=@idParam;", sqlConnection);
            SqlParameter idParam = new SqlParameter("@idParam", SqlDbType.Int);
            cmd.Parameters.Add(idParam);
            idParam.Value = id;

            return SqlNonQuery(cmd);
        }
        #endregion

        #region Konto
        //Tilføjer en konto til databasen
        public static int AddAccount(int saldo, string kontotype, DateTime dato, int kundenummer)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Konti VALUES(@saldo, @kontotype, @dato, @kundenummer);", sqlConnection);
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@kontotype", SqlDbType.NVarChar, 60),
                new SqlParameter("@dato", SqlDbType.Date),
                new SqlParameter("@saldo", SqlDbType.Int),
                new SqlParameter("@kundenummer", SqlDbType.Int)
            };
            cmd.Parameters.AddRange(parameters);
            parameters[0].Value = kontotype;
            parameters[1].Value = dato;
            parameters[2].Value = saldo;
            parameters[3].Value = kundenummer;
            return SqlNonQuery(cmd);
        }
        //Fjerner en konto fra databasen
        public static int RemoveAccount(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Konti WHERE Kontonummer=@idParam;", sqlConnection);
            SqlParameter idParam = new SqlParameter("@idParam", SqlDbType.Int);
            cmd.Parameters.Add(idParam);
            idParam.Value = id;

            return SqlNonQuery(cmd);
        }

        /// <summary>
        /// Henter en saldo fra en konto. Den int som gives tilbage er i kr.
        /// </summary>
        /// <param name="kontonr"></param>
        /// <returns></returns>
        public static int GetSaldo(int kontonr)
        {
            int saldo;
            SqlCommand cmd = new SqlCommand("SELECT Saldo FROM Konti WHERE Kontonummer = @kontonrParam", sqlConnection);
            SqlParameter kontonrParam = new SqlParameter("@kontonrParam", SqlDbType.Int);
            kontonrParam.Value = kontonr;
            cmd.Parameters.Add(kontonrParam);
            sqlConnection.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                saldo = (int)reader.GetValue(0);
            }
            catch (Exception)
            {
                throw;
            }
            finally { sqlConnection.Close(); }
            return saldo;
        }

        #endregion

        #region Transaktion
        /// <summary>
        /// Skriver en ny linje i tabellen "Transaktioner" og opdaterer saldo på den givne konto.
        /// </summary>
        /// <param name="saldo"></param>
        /// <param name="beløb"></param>
        /// <param name="dato"></param>
        /// <param name="kontonummer"></param>
        /// <returns></returns>
        public static int AddTransaction(int saldo, int beløb, DateTime dato, int kontonummer)
        {
            int rowsAffected;
            SqlCommand insertInto = new SqlCommand("INSERT INTO Transaktioner VALUES(@saldo, @beløb, @dato, @kontonummer);", sqlConnection);
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@saldo", SqlDbType.Int),
                new SqlParameter("@beløb", SqlDbType.Int),
                new SqlParameter("@dato", SqlDbType.Date),
                new SqlParameter("@kontonummer", SqlDbType.Int)
            };
            insertInto.Parameters.AddRange(parameters);
            parameters[0].Value = saldo;
            parameters[1].Value = beløb;
            parameters[2].Value = dato;
            parameters[3].Value = kontonummer;

            SqlCommand saldoUpdate = new SqlCommand("UPDATE Konti SET Saldo = @saldo WHERE Kontonummer = @kontonummer", sqlConnection);
            SqlParameter saldoParam = new SqlParameter("@saldo", SqlDbType.Int);
            SqlParameter kontonummerParam = new SqlParameter("@kontonummer", SqlDbType.Int);
            saldoParam.Value = saldo;
            kontonummerParam.Value = kontonummer;
            saldoUpdate.Parameters.Add(saldoParam);
            saldoUpdate.Parameters.Add(kontonummerParam);

            rowsAffected = SqlNonQuery(insertInto, saldoUpdate);
            return rowsAffected;
        }
        //Fjerner en transaktion fra databasen
        public static int RemoveTransaction(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Transaktion WHERE Transaktionsnummer=@idParam;", sqlConnection);
            SqlParameter idParam = new SqlParameter("@idParam", SqlDbType.Int);
            cmd.Parameters.Add(idParam);
            idParam.Value = id;

            return SqlNonQuery(cmd);
        }

        #endregion
    }
}
