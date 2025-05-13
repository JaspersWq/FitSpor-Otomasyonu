using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SporProgramı
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection sql = new SqlConnection("Data Source=COUNTZ\\SQLEXPRESS;Initial Catalog=FitSporDB;Integrated Security=True");


        private void yeniÜyeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            sql.Open();
            SqlCommand sqlCom;
            if (string.IsNullOrWhiteSpace(mTxtCikis.Text))
            {
              sqlCom = new SqlCommand("insert into FitSporTable (Ad, Soyad, Telefon, TC, Giris_Tarihi, Cikis_Tarihi, Cinsiyet) values('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mTxtTel.Text + "','" + txtTC.Text + "','" + mTxtGiris.Text + "','" + cbCinsiyet.Text + "')", sql);
            }
            else
            {
                sqlCom = new SqlCommand("insert into FitSporTable (Ad, Soyad, Telefon, TC, Giris_Tarihi, Cikis_Tarihi, Cinsiyet) values('" + txtAd.Text + "','" + txtSoyad.Text + "','" + mTxtTel.Text + "','" + txtTC.Text + "','" + mTxtGiris.Text + "','" + mTxtCikis.Text + "','" + cbCinsiyet.Text + "')", sql);
            }
           


            sqlCom.ExecuteNonQuery();
            sql.Close();

            MessageBox.Show("Müşteri Eklendi","YENİ MÜŞTERİ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            txtAd.Text = " ";
            txtSoyad.Text = " ";
            mTxtTel.Text = " ";
            txtTC.Text = " ";
            mTxtGiris.Text = " ";
            mTxtCikis.Text = " ";
            cbCinsiyet.Text = " ";
        }
    }
}
