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
    //Lavet af Jesper
    public partial class KontoMenu : Form
    {
        public KontoMenu()
        {
            InitializeComponent();
        }

        private void LogudKnap_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void LukKnap_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }
        public static int hævIndsætValg = 0;
        private void HævKnap_Click(object sender, EventArgs e)
        {
            hævIndsætValg = 0;
            hævIndsæt open = new hævIndsæt(hævIndsætValg);
            Hide();
            open.Show();
        }

        private void IndsætKnap_Click(object sender, EventArgs e)
        {
            hævIndsætValg = 1;
            hævIndsæt open = new hævIndsæt(hævIndsætValg);
            Hide();
            open.Show();
        }
    }
}
