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
    public partial class Form_Home : Form
    {
        //for move the mouse
        int mouve;
        int mouveX;
        int mouveY;

        public Form_Home()
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

        private void panel6_MouseHover(object sender, EventArgs e)
        {//mn kan7t mouse fo9 panel
            panel6.BackColor = Color.LightSalmon;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {//mn kanb3d lmouse 3la panel

            panel6.BackColor = Color.Transparent;
        }

        private void panel5_MouseHover(object sender, EventArgs e)
        {
            panel5.BackColor = Color.LightSalmon;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel5.BackColor = Color.Transparent;
        }

        private void panel4_MouseHover(object sender, EventArgs e)
        {
            panel4.BackColor = Color.LightSalmon;
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel4.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.LightSalmon;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void bunifuCustomLabel7_MouseHover(object sender, EventArgs e)
        {
            bunifuCustomLabel7.BackColor = Color.LightSalmon;
        }

        private void bunifuCustomLabel7_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel7.BackColor = Color.Transparent;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form_Control f = new Form_Control();
            f.userState = bunifuCustomLabel5.Text; 
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

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            Form_Backup fa = new Form_Backup();
            fa.Show();
            this.Hide();
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            ClassUser d = new ClassUser();
            d.logout();
            this.Close();
            Form_Login f = new Form_Login();
            f.Show();
        }

        private void Form_Home_Load(object sender, EventArgs e)
        {
        }

        private void Form_Home_Activated(object sender, EventArgs e)
        {
            bunifuCustomLabel3.Text = Properties.Settings.Default.Email;
            bunifuCustomLabel5.Text = Properties.Settings.Default.Role;
            Form_Control m = new Form_Control();
            m.userState = Properties.Settings.Default.Role;
            if (bunifuCustomLabel5.Text == "Admin")
            {
                panel5.Enabled = true;
            }
            else
            {
                panel5.Enabled = false;
            }
        }
    }
}
