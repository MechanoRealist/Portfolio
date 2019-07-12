using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Project
{
    public partial class Login : Form
    {
        //Skrevet af Rasmus
        public Login()
        {
            InitializeComponent();
        }

        public static int ID = 0;
        private void LoginKnap_Click(object sender, EventArgs e)//logger brugeren ind alt efter om admin eller almendelig konto
        {
            int pin = Convert.ToInt32(passBox.Text);
            int konto = Convert.ToInt32(idBox.Text);
            ID = konto;
            bool loginSucces;
            bool loginAdmin = false;
            loginSucces = SQL.SQLLogin(konto, pin, "", ref loginAdmin);
            Hide();
            if (loginAdmin == true && loginSucces == true)//vis administrator konto logger ind
            {
                AdminMenu open = new AdminMenu();
                open.Show();
            }
            if (loginSucces == true && loginAdmin == false)//vis bruger konto logger ind
            {
                KontoMenu open = new KontoMenu();
                open.Show();                
            }
        }

        private void LukKnap_Click(object sender, EventArgs e)//lukker programmet
        {
            Environment.Exit(1);
        }
    }
}