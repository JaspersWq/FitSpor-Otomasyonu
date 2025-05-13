using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SporProgramı
{
    public partial class Form1 : Form
    {
        string kullanıcı = "Admin";
        string sifre = "123abc";
      

        public Form1()
        {
            
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=COUNTZ\\SQLEXPRESS;Initial Catalog=FitSporDB;Integrated Security=True");

                
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

        // ------------------------------------------------------------
        
                               
        private void btnGiris_Click_1(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                string sql = "Select * From AdminGiris where Ad=@Ad AND Sifre=@Sifre";
                SqlParameter parola1 = new SqlParameter("@Ad", txtKullanıcı.Text.Trim());
                SqlParameter parola2 = new SqlParameter("@Sifre", txtSifre.Text.Trim());
                SqlCommand komut = new SqlCommand(sql, baglanti);

                komut.Parameters.Add(parola1);
                komut.Parameters.Add(parola2);
                DataTable dt = new DataTable();
                SqlDataAdapter dp = new SqlDataAdapter(komut);
                dp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    this.Visible = false;

                    Form3 form3 = new Form3();
                    form3.FormClosed += (s, args) => this.Close();
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya Şifre yanlış!", "HATALI GİRİŞ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
        }

       

        private void txtSifre_TextChanged_1(object sender, EventArgs e)
        {
            txtSifre.UseSystemPasswordChar = true;
        }

        private void linkŞifre_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Visible = false;

            SifremiUnuttum formSifre = new SifremiUnuttum();
            formSifre.Show();
        }
    }
}
