using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prescription
{
    public partial class Form_Print : Form
    {
        public Form_Print()
        {
            InitializeComponent();
        }

        private void Form_Print_Activated(object sender, EventArgs e)
        {
             panel2.Width = Properties.Settings.Default.Width;
             panel2.Height = Properties.Settings.Default.Height;
            bunifuCustomLabel1.Text= Properties.Settings.Default.Doctor;
            bunifuCustomLabel17.Text = Properties.Settings.Default.Phone ;
            bunifuCustomLabel13.Text = Properties.Settings.Default.Adress ;
            bunifuCustomLabel2.Text = Properties.Settings.Default.description ;
            bunifuCustomLabel14.Text = Properties.Settings.Default.Informations ;
            bunifuCustomLabel4.Text = Properties.Settings.Default.specialty ;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap b = new Bitmap(panel2.Width, panel2.Height);
            panel2.DrawToBitmap(b,new Rectangle(Point.Empty, panel2.Size));
            e.Graphics.DrawImage(b,0,0);
        }
    }
}
