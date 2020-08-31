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
    public partial class Form_Start : Form
    {
        public Form_Start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ClassUser d = new ClassUser();
                DataTable dt = new DataTable();
                Form_Login g = new Form_Login();
              
                    dt = d.startLoading();
                    if (dt.Rows.Count > 0)
                    {
                        d.updateLogin(g.bunifuMaterialTextbox12.Text, g.bunifuMaterialTextbox11.Text);
                        Form_Home m = new Form_Home();
                        m.bunifuCustomLabel3.Text = dt.Rows[0]["email"].ToString();
                        m.bunifuCustomLabel5.Text = dt.Rows[0]["roleUser"].ToString();
                        m.bunifuCustomLabel8.Text = "Dr." + dt.Rows[0]["name"].ToString();
                        m.Show();
                        this.Hide();
                        Properties.Settings.Default.Email = dt.Rows[0]["email"].ToString();
                        Properties.Settings.Default.Role = dt.Rows[0]["roleUser"].ToString();
                        Properties.Settings.Default.Save();
                        timer1.Enabled = false;
                    }
                    else
                    {
                    Form_Login l = new Form_Login();
                    l.Show();
                        timer1.Enabled = false;
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
}
}
