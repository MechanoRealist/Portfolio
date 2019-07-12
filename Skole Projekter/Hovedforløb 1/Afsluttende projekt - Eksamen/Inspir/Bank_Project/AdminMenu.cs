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

namespace Bank_Project
{
    public partial class AdminMenu : Form
    {
        //Skrevet af Rasmus
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void LukKnap_Click(object sender, EventArgs e)//Genstarter programmet så ny bruger kan logge ind
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void LavKontoKnap_Click(object sender, EventArgs e)// laver en ny konto
        {
            string kontoType = kontoTypeBox.Text;
            string rente = renteBox.Text.Replace(',','.');
            string saldo = saldoBox.Text.Replace(',', '.');
            string kundeID = kundeIDBox.Text;
            Random rnd = new Random();
            int pinKode = rnd.Next(1000, 9999);// generere en tilfældig Pinkode
            string kontoID;


            SQL.SQLInserter("Konti(kontoType,renter,saldo,KundeID,pinKode)", "'" + kontoType + "'" + "," + rente + "," + saldo + "," + kundeID + "," + pinKode, ")");// tilføjer den nye konto
            kontoID = SQL.SQLReturner("Konti", "KontoID", " Where KundeID = " + kundeID+" ORDER BY KontoID DESC");
            MessageBox.Show("KontoID:       " + kontoID + "\nKode:      " + Convert.ToString(pinKode));//udskriver bruger id og kode på den nye Konto
        }

        private void NewAccKnap_Click(object sender, EventArgs e)//viser de rigtige knapper til at lave en ny konto og skjuler alt andet åbent i vinduet
        {

            lavKontoKnap.Show();
            tableLayoutPanelAccount.Show();
            tableLayoutPanelCustomer.Hide();
            lavKundeKnap.Hide();
            tableLayoutPanelRedigerKunde.Hide();
            tableLayoutPanelkundersøg.Hide();
            dataGridView3.Hide();
            sletKundeKnap.Hide();
            sletKontoKnap.Hide();
            tableLayoutPanelsøgTransaktion.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            tableLayoutPaneleditAccount.Hide();
        }

        private void NewCustomerKnap_Click(object sender, EventArgs e)//viser de rigtige knapper til at lave en ny Kunde og skjuler alt andet åbent i vinduet
        {
            tableLayoutPanelCustomer.Show();
            lavKundeKnap.Show();
            lavKontoKnap.Hide();
            tableLayoutPanelkundersøg.Hide();
            tableLayoutPanelRedigerKunde.Hide();
            tableLayoutPanelAccount.Hide();
            dataGridView3.Hide();
            sletKundeKnap.Hide();
            sletKontoKnap.Hide();
            tableLayoutPanelsøgTransaktion.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            tableLayoutPaneleditAccount.Hide();
        }

        private void nyKundeKnap_Click(object sender, EventArgs e)//Laver en ny kunde
        {
            SQL.SQLInserter("Kunder(navn,efterNavn,adresse,tlf,kundeType,firmaNavn)", "'" + fornavnBox.Text + "'" + "," + "'" + efternavnBox.Text + "'" + "," + "'" + adresseBox.Text + "'" + "," + "'" + tlfBox.Text + "'" + "," + "'" + kundeTypeBox.Text + "'" + "," + "'" + firmaBox.Text + "'", ")");
            MessageBox.Show("Ny kunde Oprettet");
        }

        private void KundeKnap_Click(object sender, EventArgs e)//viser de rigtige knapper til at redigere en Kunde og skjuler alt andet åbent i vinduet
        {
            lavKontoKnap.Hide();
            tableLayoutPanelAccount.Hide();
            tableLayoutPanelCustomer.Hide();
            dataGridView2.Hide();
            tableLayoutPaneleditAccount.Hide();
            dataGridView3.Hide();
            tableLayoutPanelsøgTransaktion.Hide();
            sletKundeKnap.Show();
            sletKontoKnap.Hide();
            tableLayoutPanelkundersøg.Show();
            dataGridView1.DataSource = SQL.SQLCon(1);
            tableLayoutPanelRedigerKunde.Show();
            dataGridView1.Show();
        }

        private void editKnap_Click(object sender, EventArgs e)//redigere kunde
        {
            string navn = editnavnBox.Text;
            string efternavn = editEfternavBox.Text;
            string adresse = editAdresseBox.Text;
            string kundeid = editKudnIDBox.Text;
            string tlf = editTlfBox.Text;
            string kundetype = editKundeTypeBox.Text;
            string frimanavn = editFirmanavnBox.Text;
            SQL.SQLUpdater("Kunder ", "navn=" + "'" + navn + "'" + ",efterNavn=" + "'" + efternavn + "'" + ",adresse=" + "'" + adresse + "'" + ",tlf=" + tlf + ",kundeType=" + "'" + kundetype + "'" + ",firmaNavn=" + "'" + frimanavn + "' ", "WHERE KundeID=" + kundeid);
            SQL.SQLCon(1);
        }

        private void DataGridView1_Click(object sender, EventArgs e)//smider informationerne brugeren klikkede på i datagridet ned i text boxene
        {
            editnavnBox.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            editEfternavBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            editAdresseBox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            editKudnIDBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            editTlfBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            editKundeTypeBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            editFirmanavnBox.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void KontoKnap_Click(object sender, EventArgs e)//viser de rigtige knapper til at redigere en konto og skjuler alt andet åbent i vinduet
        {
            lavKontoKnap.Hide();
            tableLayoutPanelAccount.Hide();
            tableLayoutPanelCustomer.Hide();
            lavKundeKnap.Hide();
            dataGridView1.Hide();
            tableLayoutPanelCustomer.Hide();
            tableLayoutPanelkundersøg.Hide();
            dataGridView3.Hide();
            sletKundeKnap.Hide();
            sletKontoKnap.Show();
            tableLayoutPanelsøgTransaktion.Hide();
            dataGridView2.DataSource = SQL.SQLCon(2);
            tableLayoutPaneleditAccount.Show();
            tableLayoutPanelRedigerKunde.Hide();
            dataGridView2.Show();
        }

        private void editKonti_Click(object sender, EventArgs e)//Redigere en konto
        {
            int KontiID = Convert.ToInt32(editKontoIDBox.Text);
            string KontoType = editKontoTypeBox.Text;
            string Rente = editRenteBox.Text.Replace(',', '.');
            string Saldo = editSaldoBox.Text.Replace(',', '.');
            int Pin = Convert.ToInt32(editPinkodeBox.Text);
            int Ejer = Convert.ToInt32(editEjerBox.Text);
            SQL.SQLUpdater("Konti ", "kontoType=" + "'" + KontoType + "'" + ",renter=" + Rente + ",saldo=" + Saldo + ",pinKode=" + Pin + ",KundeID=" + Ejer, " Where  KontoID=" + KontiID);
            SQL.SQLCon(2);
        }

        private void DataGridView2_Click(object sender, EventArgs e)//smider informationerne brugeren klikkede på i datagridet ned i text boxene
        {
            editKontoIDBox.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            editKontoTypeBox.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            editRenteBox.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            editSaldoBox.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            editPinkodeBox.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            editEjerBox.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
        }

        private void søgKontoKnap_Click(object sender, EventArgs e)//søger efter konto
        {
            int søg = Convert.ToInt32(søgKontoIDBox.Text);
            SQL.SQLCon(2, " WHERE kontoID  LIKE " + "'%" + søg + "%'");
        }

        private void søgKundeKnap_Click(object sender, EventArgs e)
        {
            string søg = søgNavnBox.Text;
            SQL.SQLCon(1, " WHERE navn LIKE " + "'%" + søg + "%'");
        }

        private void transaktionerKnap_Click(object sender, EventArgs e)//viser de rigtige knapper til at redigere og søge i transaktioner og skjuler alt andet åbent i vinduet
        {
            lavKontoKnap.Hide();
            tableLayoutPanelAccount.Hide();
            tableLayoutPanelCustomer.Hide();
            lavKundeKnap.Hide();
            tableLayoutPaneleditAccount.Hide();
            dataGridView1.Hide();
            dataGridView2.Hide();
            tableLayoutPanelCustomer.Hide();
            tableLayoutPanelkundersøg.Hide();
            sletKundeKnap.Hide();
            sletKontoKnap.Hide();
            dataGridView3.DataSource = SQL.SQLCon(3);
            dataGridView3.Show();
            tableLayoutPanelsøgTransaktion.Show();
        }

        private void søgTransaktionerKnap_Click(object sender, EventArgs e)
        {
            int søg = Convert.ToInt32(søgTransaktionBox.Text);
            SQL.SQLCon(3, " WHERE kontoID LIKE " + "'%" + søg + "%'");
        }

        private void SletKundeKnap_Click(object sender, EventArgs e)//sletter en kunde vis alle konto fra kunden er slettet
        {
            if (SQL.SQLReturner("Konti ","*","Where kundeID = "+editKudnIDBox.Text)=="")
            {
                SQL.SQLDeleter("Kunder", "kundeID = " + editKudnIDBox.Text);
                SQL.SQLCon(1);
            }
            else
            {
                MessageBox.Show("Error Customer Still have Accounts with us");
            }
        }

        private void SletKontoKnap_Click(object sender, EventArgs e)//sletter en konto vis alle transaktioner fra kontoen er slettet
        {
            if (SQL.SQLReturner("Transaktioner ","*","Where kontoID = "+editKontoIDBox.Text)=="")
            {
                SQL.SQLDeleter("Konti", "kontoID =" + editKontoIDBox.Text);
                SQL.SQLCon(2);
            }
            else
            {
                MessageBox.Show("Error Account still have Transactions Bound to it");
            }
        }

        private void sletTransaktionKnap_Click(object sender, EventArgs e)//sletter en transaktion
        {
            SQL.SQLDeleter("Transaktioner ", "transaktionsNummer =" + sletTransaktionBox.Text);
            SQL.SQLCon(3);
        }

        private void DataGridView3_Click(object sender, EventArgs e)//smider informationerne brugeren klikkede på i datagridet ned i text boxene
        {
            søgTransaktionBox.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            sletTransaktionBox.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
