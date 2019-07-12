using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project
{
    public partial class hævIndsæt : Form
    {
        //Lavet af Jesper
        public hævIndsæt(object sender)
        {
            InitializeComponent();
            saldo.Text = SQL.SQLReturner("Konti", "saldo", " Where KontoID = " + Convert.ToString(Login.ID));

            if (KontoMenu.hævIndsætValg == 1)//INDSÆT
            {
                windowName.Text = "Insert";
                beløbKnap.Text = "Insert";
            }
            else if (KontoMenu.hævIndsætValg == 0)//HÆV
            {
                windowName.Text = "Withdraw";
                beløbKnap.Text = "Withdraw";
            }
        }

        private void BeløbKnap_Click(object sender, EventArgs e)
        {
            if (KontoMenu.hævIndsætValg == 1)//INDSÆT
            {
                SQL.SQLUpdater("Konti", "Saldo", " = saldo + " + beløbBox.Text + " Where KontoID = " + Convert.ToString(Login.ID));
                saldo.Text = SQL.SQLReturner("Konti", "saldo", " Where KontoID = " + Convert.ToString(Login.ID));

                SQL.SQLInserter("Transaktioner(KontoID,dato,beløb)", Login.ID + ", CURRENT_TIMESTAMP" + ", " + "+" + beløbBox.Text + ")", "");
                MessageBox.Show("Insert: " + beløbBox.Text);
            }
            else if (KontoMenu.hævIndsætValg == 0)//HÆV
            {
                string beløb = beløbBox.Text;
                int maxHæv = 6000;
                int nytBeløb;
                bool erTal = int.TryParse(beløb, out nytBeløb);
                if (erTal == false || nytBeløb > maxHæv)
                {
                    if (erTal == false)
                    {
                        MessageBox.Show("Amount has to be a number.");
                    }
                    else if (nytBeløb > maxHæv)
                    {
                        MessageBox.Show("you can max withdraw 6000 Money");
                    }
                }
                else
                {
                    SQL.SQLUpdater("Konti", "Saldo", " = saldo - " + beløbBox.Text + " Where KontoID = " + Convert.ToString(Login.ID));
                    saldo.Text = SQL.SQLReturner("Konti", "saldo", " Where KontoID = " + Convert.ToString(Login.ID));

                    SQL.SQLInserter("Transaktioner(KontoID,dato,beløb)", Login.ID + ", CURRENT_TIMESTAMP" + ", " + "-" + beløbBox.Text + ")", "");
                    MessageBox.Show("Withdraw: " + beløbBox.Text);
                }
            }
            this.Close();
        }

        private void LukKnap_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
    }
}
