using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Bank_Project
{
    class SQL
    {
        //Lavet af Rasmus og Jesper Selve Database Lavet af Jesper, Nicholas Og Rasmus
        public static int ID = 0;
        //public static string Connectionstring = @"Data Source=DESKTOP-6M9QTUB;Initial Catalog=Bank;Persist Security Info=True;User ID=nimdA;Password=Changeme123"; // en string der holder login info til sql databasen Til local editing
        public static string Connectionstring = @"Data Source=tcp:80.197.69.234;Initial Catalog=Bank;Persist Security Info=True;User ID=nimdA;Password=Changeme123"; // en string der holder login info til sql databasen til Remote connection (Rasmus Computer)
        public static DataTable kunder = new DataTable();// en datatabel til at holde data fra sql databasen
        public static DataTable datakonto = new DataTable();
        public static DataTable dataTransaktion = new DataTable();
        //SQL CON
        public static DataTable SQLCon(int valg, string søg = "")
        {
            kunder.Clear();
            datakonto.Clear();
            dataTransaktion.Clear();
            if (valg == 1)
            {
                SqlDataAdapter sqlKunde = new SqlDataAdapter("SELECT * FROM Kunder" + søg, Connectionstring);
                sqlKunde.Fill(kunder);
                sqlKunde.Update(kunder);
                return kunder;
            }
            else if (valg == 2)
            {
                SqlDataAdapter sqlKonti = new SqlDataAdapter("SELECT * FROM Konti" + søg, Connectionstring);
                sqlKonti.Fill(datakonto);
                sqlKonti.Update(datakonto);
                return datakonto;
            }
            else if (valg == 3)
            {
                SqlDataAdapter sqlTransaktioner = new SqlDataAdapter("SELECT * FROM Transaktioner" + søg, Connectionstring);
                sqlTransaktioner.Fill(dataTransaktion);
                sqlTransaktioner.Update(dataTransaktion);
                return dataTransaktion;
            }
            return kunder;
        }
        //SQL READ
        public static string SQLReturner(string tabel = "", string data = "", string key = "")
        {
            using (SqlConnection Connection = new SqlConnection(Connectionstring))
            {
                string query = "Select " + data + " From " + tabel + key;
                //SqlDataAdapter sqlDa = new SqlDataAdapter(query, Connectionstring);

                SqlCommand cmd = new SqlCommand(query, Connection);
                Connection.Open();
                string result = Convert.ToString(cmd.ExecuteScalar());
                Connection.Close();
                return result;
            }

        }
        public static bool SQLLogin(int kontoLogin, int brugerKode, string tabel, ref bool admin)
        {
            bool loginValue = false;
            if (kontoLogin <= 999)
            {
                tabel = "Admins";
            }
            else if (kontoLogin >= 1000)
            {
                tabel = "Konti";
            }
            using (SqlConnection Connection = new SqlConnection(Connectionstring))
            {
                SqlCommand sqlUsername = new SqlCommand("SELECT KontoID FROM " + tabel + " WHERE kontoID = @KontiID", Connection);
                SqlCommand sqlPassword = new SqlCommand("SELECT pinKode FROM " + tabel + " WHERE kontoID = @KontiID", Connection);
                SqlCommand sqladmin = new SqlCommand("SELECT adminCheck FROM " + tabel + " WHERE kontoID = @KontiID", Connection);
                SqlCommand sqllogin = new SqlCommand("UPDATE " + tabel + " SET sidsteLogin = getdate() WHERE kontoID = " + kontoLogin, Connection);               
                Connection.Open();
                sqllogin.ExecuteNonQuery();
                sqlUsername.Parameters.AddWithValue("@KontiID", kontoLogin);
                sqlPassword.Parameters.AddWithValue("@KontiID", kontoLogin);
                sqladmin.Parameters.AddWithValue("@KontiID", kontoLogin);
                int username;
                int kode;
                bool isAdmin;
                username = (int)sqlUsername.ExecuteScalar();
                kode = (int)sqlPassword.ExecuteScalar();
                isAdmin = (bool)sqladmin.ExecuteScalar();
                if (username == kontoLogin && kode == brugerKode)
                {
                    loginValue = true;
                    if (isAdmin)
                    {
                        admin = true;
                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is invalid.");
                    loginValue = false;
                }
            }


            return loginValue;
        }
        //SQL INSERT
        public static string SQLInserter(string tabel = "", string data = "", string key = "")
        {
            using (SqlConnection Connection = new SqlConnection(Connectionstring))
            {
                string query = "INSERT INTO " + tabel + " VALUES(" + data + key;
                //SqlDataAdapter sqlDa = new SqlDataAdapter(query, Connectionstring);

                SqlCommand cmd = new SqlCommand(query, Connection);

                Connection.Open();
                string result = Convert.ToString(cmd.ExecuteNonQuery());
                Connection.Close();
                return result;
            }
        }

        //SQL UPDATE
        public static string SQLUpdater(string tabel = "", string data = "", string key = "")
        {
            using (SqlConnection Connection = new SqlConnection(Connectionstring))
            {
                string query = "UPDATE " + tabel + " SET " + data + key;
                //SqlDataAdapter sqlDa = new SqlDataAdapter(query, Connectionstring);

                SqlCommand cmd = new SqlCommand(query, Connection);

                Connection.Open();
                string result = Convert.ToString(cmd.ExecuteNonQuery());
                Connection.Close();
                return result;
            }

        }
        //SQL DELETE
        public static string SQLDeleter(string tabel = "", string key = "")
        {
            using (SqlConnection Connection = new SqlConnection(Connectionstring))
            {
                string query = "DELETE FROM " + tabel + " WHERE " + key;
                //SqlDataAdapter sqlDa = new SqlDataAdapter(query, Connectionstring);

                SqlCommand cmd = new SqlCommand(query, Connection);

                Connection.Open();
                string result = Convert.ToString(cmd.ExecuteNonQuery());
                Connection.Close();
                return result;
            }
        }
    }
}
