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
    public partial class Form_Control : Form
    {
        //for move the mouse
        int mouve;
        int mouveX;
        int mouveY;
        public string userState;
        public Form_Control()
        {
            InitializeComponent();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {

            if (Panel_Navbar_sidebar.Size.Width == 163)
            {
                Panel_Navbar_sidebar.Width = 60;
            }
            else
            {
                Panel_Navbar_sidebar.Width = 163;
            }
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
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            Form_Home f = new Form_Home();
            f.Show();
            this.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {//ma7tajinach DATABASE
            if (bunifuMaterialTextbox2.Text == "" || bunifuMaterialTextbox3.Text == "" || bunifuMaterialTextbox4.Text == "")
            {
                //Form_Error_Fields FERIC = new Form_Error_Fields();
                //FERIC.Show();
                txt_Message.Text = "All Fileds Requered !";
                bunifuTransition1.ShowSync(P_Message);
            }
            else
            {
                Properties.Settings.Default.Width = int.Parse(txt_width.Text);
                Properties.Settings.Default.Height = int.Parse(bunifuMaterialTextbox8.Text);
                Properties.Settings.Default.Doctor = bunifuMaterialTextbox4.Text;
                Properties.Settings.Default.Phone = bunifuMaterialTextbox3.Text;
                Properties.Settings.Default.Adress = bunifuMaterialTextbox1.Text;
                Properties.Settings.Default.description = bunifuMaterialTextbox5.Text;
                Properties.Settings.Default.Informations = bunifuMaterialTextbox6.Text;
                Properties.Settings.Default.specialty = bunifuMaterialTextbox2.Text;
                txt_Message.ForeColor =Color.SeaGreen;
                txt_Message.Text = "Save Succefull";
                bunifuTransition1.ShowSync(P_Message);

                Properties.Settings.Default.Save();
            }
           
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            Form_Print p = new Form_Print();
            p.Show();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            P_Message.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P_Option.BringToFront();//wla dir visible=true//lmhm bach nbaynoha l user
        }

        private void button3_Click(object sender, EventArgs e)
        {
            P_Traitement.BringToFront();
        }

        private void Form_Control_Activated(object sender, EventArgs e)
        {   //Auth
            if (userState == "Admin")
            {
                bunifuThinButton211.Enabled = true;
                button4.Enabled = true;
            }
            else
            {
                bunifuThinButton211.Enabled = false;
                button4.Enabled = false;

            }
            //  3ilajat
            ClassTreatments t = new ClassTreatments();
            DataGrid_Traitement.DataSource= t.readTreatments();
            //marid
            ClassPatients p = new ClassPatients();
            dataGridView1.DataSource = p.readPatient();
            //user
            ClassUser u = new ClassUser();
            dataGridView2.DataSource = u.readUsers();
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
        
            try
            {
                if (bunifuMaterialTextbox7.Text != DataGrid_Traitement.CurrentRow.Cells[1].Value.ToString())
                {
                    ClassTreatments t = new ClassTreatments();
                    t.insertTreatments(bunifuMaterialTextbox7.Text.ToString());
                    MessageBox.Show("addition good");
                }
                else
                {
                    MessageBox.Show("Treatment is exist");
                }
            }
            catch 
            {//7int ila kant db khawya o awl mra tbghi dir add kaygolik error 3liha db tjibha f catch 
                ClassTreatments t = new ClassTreatments();
                t.insertTreatments(bunifuMaterialTextbox7.Text.ToString());
                MessageBox.Show("addition good");
            }

        }

        private void Form_Control_Load(object sender, EventArgs e)
        {
            P_Option.BringToFront();//wla dir visible=true//lmhm bach nbaynoha l user
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            try
            {
                ClassTreatments t = new ClassTreatments();
                t.deleteTreatments(int.Parse(DataGrid_Traitement.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("delete good");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void DataGrid_Traitement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var x = DataGrid_Traitement.CurrentRow.Cells[1].Value;
            bunifuMaterialTextbox7.Text = DataGrid_Traitement.CurrentRow.Cells[1].Value.ToString();
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            try
            {
                ClassTreatments t = new ClassTreatments();
                t.updateTreatments(int.Parse(DataGrid_Traitement.CurrentRow.Cells[0].Value.ToString()), bunifuMaterialTextbox7.Text);
                MessageBox.Show("update good");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuMaterialTextbox7_OnValueChanged(object sender, EventArgs e)
        {
            ClassTreatments t = new ClassTreatments();
            DataGrid_Traitement.DataSource = t.searchTreatments(bunifuMaterialTextbox7.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Prescription.BringToFront();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            try
            {
                ClassPatients p = new ClassPatients();
                p.deletePatient(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("delete good");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            //details
            try
            {
                Form_Print print = new Form_Print();
                ClassTreatments_Patients p = new ClassTreatments_Patients();
                print.dataGridView1_Print.DataSource = p.readTreatments_Patients(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                print.Lb_Print_NamePatient.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                print.bunifuCustomLabel7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                print.bunifuCustomLabel9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                print.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void bunifuMaterialTextbox9_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            P_User.BringToFront();

        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            try
            {
                ClassUser u = new ClassUser();
                u.insertUser(bunifuMaterialTextbox10.Text, bunifuMaterialTextbox12.Text, bunifuMaterialTextbox11.Text, comboBox2.Text, "false");
                MessageBox.Show("add is seccess");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
        {
            try
            {
                ClassUser t = new ClassUser();
                t.updateUser(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()), bunifuMaterialTextbox10.Text, bunifuMaterialTextbox12.Text, bunifuMaterialTextbox11.Text, comboBox2.Text);
                MessageBox.Show("update good");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bunifuMaterialTextbox10.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            bunifuMaterialTextbox12.Text= dataGridView2.CurrentRow.Cells[2].Value.ToString();
           bunifuMaterialTextbox11.Text= dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text= dataGridView2.CurrentRow.Cells[4].Value.ToString();
        }

        private void bunifuThinButton211_Click(object sender, EventArgs e)
        {
            try
            {
                ClassUser p = new ClassUser();
                p.deleteUser(int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()));
                MessageBox.Show("delete good");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuImageButton3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//btn mini fenetre
        }
    }
}
