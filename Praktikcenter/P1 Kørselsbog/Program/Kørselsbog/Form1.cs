using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kørselsbog
{
    public partial class Form1 : Form
    {
        string sqlConnectionString = "Server=localhost;Integrated Security=true;Database=Kørselsbog"; //Localhost er den maskine programmet kører på. Integrated Security betyder at der anvendes Windows bruger login for adgang til SQL serveren. Database er navnet på databasen.
        SqlDataAdapter sqlAdapter;
        SqlConnection con; //SQL forbindelse
        SqlCommand fullnameCommand, numberplateCommand, dateCommand, kilometerCommand, fillCommand; //SQL kommandoer deklareres.
        SqlParameter fullnameParam = new SqlParameter("@Fullname", SqlDbType.VarChar, 60); //SQL parametre der svarer til de værdier som kolonnerne i tabellen kan have.
        SqlParameter numberplateParam = new SqlParameter("@Numberplate", SqlDbType.VarChar, 20);
        SqlParameter startDateParam = new SqlParameter("@StartDate", SqlDbType.Date);
        SqlParameter endDateParam = new SqlParameter("@EndDate", SqlDbType.Date);
        SqlParameter kilometerParam = new SqlParameter("@Kilometer", SqlDbType.SmallInt);

        public Form1() //Konstruktor for Form1. Objekter initialiseres her for brug i programmet.
        {
            con = new SqlConnection(sqlConnectionString);
            fillCommand = new SqlCommand("SELECT * FROM MedarbejderKørsel", con); //Henter alt fra databasen.
            fullnameCommand = new SqlCommand("SELECT * FROM MedarbejderKørsel WHERE FuldNavn LIKE @Fullname", con); //Leder i FuldNavn efter et stykke tekst.
            fullnameCommand.Parameters.Add(fullnameParam); //Tilføjer parametre til SQL kommandoen.
            numberplateCommand = new SqlCommand("SELECT * FROM MedarbejderKørsel WHERE Nummerplade LIKE @Numberplate", con); //Leder i Nummerplade efter et stykke tekst.
            numberplateCommand.Parameters.Add(numberplateParam);
            dateCommand = new SqlCommand("SELECT * FROM MedarbejderKørsel WHERE Dato BETWEEN @StartDate AND @EndDate", con); //Leder efter rækker der er mellem to datoer.
            dateCommand.Parameters.Add(startDateParam);
            dateCommand.Parameters.Add(endDateParam);
            kilometerCommand = new SqlCommand("SELECT * FROM MedarbejderKørsel WHERE Kilometer > @Kilometer", con); //Leder efter rækker hvor antal kilometer er støre end det indtastede.
            kilometerCommand.Parameters.Add(kilometerParam);
            InitializeComponent(); //Dette er en indbygget Windows Forms metode til at starte alle kontrollerne på formen.
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startDate_DTP.Value = DateTime.Today; //Sikrer at DateTimePickerne starter på dags dato.
            endDate_DTP.Value = DateTime.Today;
            medarbejderKørselTabel.DataSource = bindingSource1; //Binder DataGridView kontrollen til en data binding.
            CommandTheTable(fillCommand);
        }

        private void search_BTN_Click(object sender, EventArgs e) //En metode som er bundet til et klik på "Søg i databasen" knappen i Windows Forms.
        {
            if(showAll_RB.Checked) //Tjekker hvilken af radiokanpperne der er aktiveret
            {
                CommandTheTable(fillCommand);
            }
            else if(fuldNavn_RB.Checked)
            {
                fullnameParam.Value = string.Format("{0}{1}{0}","%", fuldNavn_TB.Text); //Sætter SQL LIKE wildcards "%" på parameteren og taget værdien fra tekstboksen.
                CommandTheTable(fullnameCommand); //Sender SQL kommandoen til tabel metoden.
            }
            else if(nummerplade_RB.Checked)
            {
                numberplateParam.Value = string.Format("{0}{1}{0}", "%", nummerplade_TB.Text);
                CommandTheTable(numberplateCommand);
            }
            else if(startDate_RB.Checked)
            {
                startDateParam.Value = startDate_DTP.Value; //Sætter værdierne på SQL parametrene.
                endDateParam.Value = endDate_DTP.Value;
                CommandTheTable(dateCommand);
            }
            else if(kilometer_RB.Checked)
            {
                try
                {
                    kilometerParam.Value = Convert.ToInt16(kilometer_TB.Text); //Dette er kilometer tekstboksen som konverteres til hvad der svarer til en SQL Smallint.
                    CommandTheTable(kilometerCommand);
                }
                catch
                {
                    kilometer_TB.Text = null; //Try Catch løser fejlen hvis Convert får noget som ikke er et tal.
                    MessageBox.Show("Kilometer må kun være et tal.");
                }
            }
        }

        private void update_BTN_Click(object sender, EventArgs e) //Et klik på "Gem ændringer" knappen.
        {
            sqlAdapter.Update((DataTable)bindingSource1.DataSource); //Sender ændringerne som er foretaget i DataGridView kontrollen til databasen.
            CommandTheTable(sqlAdapter.SelectCommand); //Opdaterer (refresh) DataGridView kontrollen med det gældende filter.
        }
        
        private void CommandTheTable(SqlCommand sqlCommand) //Metode for at fylde DataGridView kontrollen med en tabel fra databasen via SQL kommandoer.
        {
            sqlAdapter = new SqlDataAdapter(sqlCommand); //Sætter data adapteren for den SQL kommando der er givet. Den formidler SQL kommandoen og forbindelsen til SQL serveren.
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlAdapter); //Denne er for at automatisk skabe de SQL Update, Create og Delete kommandoer som kan forekomme når sqlAdapter.Update bruges for at sende data tilbage.
            DataTable workspaceTable = new DataTable(); //Denne repræsenterer en tabel i hukommelsen.
            sqlAdapter.Fill(workspaceTable); //Udfylder tabellen med data fra SQL databasen baseret på den SQL kommando der var gevet.
            bindingSource1.DataSource = workspaceTable; //Sender tabellen til data bindingen som så automatisk sender den videre til DataGridView kontrollen for at blive vist.
        }

        //Disse to metoder er for de to DateTimePickers og sørger for at slutDato ikke kan være før startDato.
        private void startDatePickedCheck(object sender, EventArgs e)
        {
            if (startDate_DTP.Value > endDate_DTP.Value)
            {
                endDate_DTP.Value = startDate_DTP.Value;
            }
        }

        private void endDatePickedCheck(object sender, EventArgs e)
        {
            if(endDate_DTP.Value < startDate_DTP.Value)
            {
                startDate_DTP.Value = endDate_DTP.Value;
            }
        }
    }
}
