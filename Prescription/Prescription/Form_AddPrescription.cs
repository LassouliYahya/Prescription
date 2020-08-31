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
    public partial class Form_AddPrescription : Form
    {
        //for move the mouse
        int mouve;
        int mouveX;
        int mouveY;

        public Form_AddPrescription()
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //if (P_Trait_Info.Visible)
            //{
            //    P_Patient.BringToFront();
            //}
            //else
            {
                P_Patient.SendToBack();
     Form_Home h = new Form_Home();
            h.Show();
            this.Close();
            }
           
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox3.Text==""|| bunifuMaterialTextbox1.Text==""|| comboBox2.Text=="")
            {
                txt_Message.Text = "All Fileds Requered !";
                bunifuTransition1.ShowSync(P_Message);
            }
            else
            {
              ClassPatients p = new ClassPatients();
            p.insertPatient(bunifuMaterialTextbox3.Text,int.Parse( bunifuMaterialTextbox1.Text), comboBox2.Text);
                txt_Message.ForeColor = Color.SeaGreen;
                txt_Message.Text = "Save Succefull";
                bunifuTransition1.ShowSync(P_Message);
                P_Trait_Info.BringToFront();
            }
        }

        private void Form_AddPrescription_Activated(object sender, EventArgs e)
        {
            ClassTreatments t = new ClassTreatments();
          var dataRow= t.searchTreatmentSansID();
            //had code 3la hsab i9tira7at f txtbox1
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            foreach (DataRow row in dataRow.Rows)
                    {
                Collection.Add(row[0].ToString() );
            }
            textBox1.AutoCompleteCustomSource = Collection;

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || bunifuMaterialTextbox5.Text == "" || comboBox1.Text == "" || comboBox3.Text == "")
            {
                bunifuCustomLabel13.Text = "All Fileds Requered !";
                bunifuTransition1.ShowSync(panel2);
            }
            else
            {
                ClassTreatments_Patients p = new ClassTreatments_Patients();
                //bach njib id marid l howa akhir str drto ana f db
                ClassPatients pt = new ClassPatients();
               var dt = pt.readPatient();
                int lastRow = dt.Rows.Count;
                  int idP=int.Parse( dt.Rows[lastRow-1][0].ToString());

                p.insertTreatments_Patients(idP,textBox1.Text, comboBox1.Text, bunifuMaterialTextbox5.Text, comboBox3.Text);
                txt_Message.ForeColor = Color.SeaGreen;
                bunifuCustomLabel13.Text = "Save Succefull";
                bunifuTransition1.ShowSync(panel2);
            }
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            ClassPatients p = new ClassPatients();
            var dt = p.readPatient();
            int lastRow = dt.Rows.Count;
            int idP = int.Parse(dt.Rows[lastRow - 1][0].ToString());
            string name =        dt.Rows[lastRow - 1][1].ToString();
            int age = int.Parse(dt.Rows[lastRow - 1][2].ToString());
            string patientType = dt.Rows[lastRow - 1][3].ToString();
            Form_Print print = new Form_Print();
            print.Lb_Print_NamePatient.Text = name;
            print.bunifuCustomLabel9.Text = patientType;
            print.bunifuCustomLabel7.Text = age.ToString();
            print.Show();
            P_Patient.BringToFront();
        }
    }
}
