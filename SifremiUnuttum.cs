using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SporProgramı
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.CheckState == CheckState.Checked)
            {
                txtSifre.UseSystemPasswordChar = false;
                checkBox1.ForeColor = Color.Silver;
            }
            else
            {
                txtSifre.UseSystemPasswordChar = true;
                checkBox1.ForeColor = Color.LightSlateGray;

            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
        }
        
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
