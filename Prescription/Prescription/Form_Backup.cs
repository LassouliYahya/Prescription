using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prescription
{
    public partial class Form_Backup : Form
    {
        //for move the mouse
        int mouve;
        int mouveX;
        int mouveY;
        //Backup and restore
        string DBName;
        string backupName;   
        string restoreName;

        public Form_Backup()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//btn mini fenetre
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;//btn grand fenetre
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
             mouve = 1;
             mouveX = e.X;
             mouveY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouve = 0;
        }

        private void panel1_Move(object sender, EventArgs e)
        {}

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouve == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mouveX, MousePosition.Y - mouveY);
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form_Control f = new Form_Control();
            f.Show();
            this.Hide();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            Form_AddPrescription fa = new Form_AddPrescription();
            fa.P_Patient.BringToFront();
            this.Hide();
            fa.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form_Home f = new Form_Home();
            f.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var rslt = ofd.ShowDialog();
            if (rslt==DialogResult.OK)
            {
                DBName = ofd.FileName;
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            var rslt = ofd.ShowDialog();
            if (rslt == DialogResult.OK)
            {
                backupName = ofd.SelectedPath;
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=" + DBName + ";Integrated Security=True");
                string FileName = backupName + "\\Prescription";
                string requette = " BACKUP DATABASE [" + DBName + "] TO DISK='" + FileName + ".bak' ";
                SqlCommand cmd = new SqlCommand(requette, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Save seccufull");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            var rslt = ofd.ShowDialog();
            if (rslt == DialogResult.OK)
            {
                restoreName = ofd.FileName;
            }
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=" + DBName + ";Integrated Security=True");
                string requette = "alter database  [" + DBName + "] set offline with rollback immediate  ;restore DATABASE [" + DBName + "] from DISK='" + restoreName + "' ";
                SqlCommand cmd = new SqlCommand(requette, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("restore seccufull");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
