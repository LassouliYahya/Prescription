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
    public partial class Form_Login : Form
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {

            try
            {
                ClassUser d = new ClassUser();
                DataTable dt = new DataTable();
                if (bunifuMaterialTextbox12.Text==""|| bunifuMaterialTextbox11.Text=="")
                {
                    MessageBox.Show("Please Entre your informations");
                }
                else
                {
                    dt = d.login(bunifuMaterialTextbox12.Text, bunifuMaterialTextbox11.Text);
                    if (dt.Rows.Count > 0)
                    {
                        d.updateLogin(bunifuMaterialTextbox12.Text, bunifuMaterialTextbox11.Text);
                        Form_Home m = new Form_Home();
                        m.bunifuCustomLabel3.Text = dt.Rows[0]["email"].ToString();
                        m.bunifuCustomLabel5.Text = dt.Rows[0]["roleUser"].ToString();
                        m.bunifuCustomLabel8.Text ="Dr."+ dt.Rows[0]["name"].ToString();
                        m.Show();
                        this.Hide();

                        Properties.Settings.Default.Email = dt.Rows[0]["email"].ToString();
                        Properties.Settings.Default.Role = dt.Rows[0]["roleUser"].ToString();
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("error for your informations");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
