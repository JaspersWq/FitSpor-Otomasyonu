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
using System.Web.UI.WebControls;

namespace SporProgramı
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=COUNTZ\\SQLEXPRESS;Initial Catalog=FitSporDB;Integrated Security=True");
        
        
        private void veriler()
        {
            dataGridView1.Rows.Clear();
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from FitSporTable", baglan);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr["ID"].ToString(), rdr["Ad"].ToString(),
                rdr["Soyad"].ToString(),
                rdr["Telefon"].ToString(),
                rdr["TC"].ToString(),
                rdr["Giris_Tarihi"].ToString(),
                rdr["Cikis_Tarihi"].ToString(),
                rdr["Cinsiyet"].ToString()
                );
            }
            baglan.Close();

        }
        private void btnUye_Click(object sender, EventArgs e)
        {
            veriler();
        }

        private void btnUye_Click_1(object sender, EventArgs e)
        {
            veriler();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (baglan.State != ConnectionState.Open)
            {
                baglan.Open();

            }
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglan;
            komut.CommandText = "delete from FitSporTable where Id = @Id";

            komut.Parameters.AddWithValue("@Id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            komut.ExecuteNonQuery();
            baglan.Close();
            veriler();

            txtAd.Text = " ";
            txtSoyad.Text = " ";
            mTxtTel.Text = " ";
            txtTC.Text = " ";
            mTxtGiris.Text = " ";
            mTxtCikis.Text = " ";
            cbCinsiyet.Text = " ";


        }
        int id = 0;
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            mTxtTel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            mTxtGiris.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            mTxtCikis.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cbCinsiyet.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();

            SqlCommand komut = new SqlCommand("UPDATE FitSporTable SET Ad=@Ad, Soyad=@Soyad, Telefon=@Telefon, TC=@TC, Giris_Tarihi=@GirisTarihi, Cikis_Tarihi=@CikisTarihi, Cinsiyet=@Cinsiyet WHERE Id=@Id", baglan);
            komut.Parameters.AddWithValue("@Ad", txtAd.Text);
            komut.Parameters.AddWithValue("@Soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@Telefon", mTxtTel.Text);
            komut.Parameters.AddWithValue("@TC", txtTC.Text);
            komut.Parameters.AddWithValue("@GirisTarihi", mTxtGiris.Text);
            komut.Parameters.AddWithValue("@CikisTarihi", mTxtCikis.Text);
            komut.Parameters.AddWithValue("Cinsiyet", cbCinsiyet.Text);
            komut.Parameters.AddWithValue("@Id", id); 
           
            komut.ExecuteNonQuery();
            baglan.Close();
            veriler();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from FitSporTable where TC like '%" + txtAra.Text + "%'", baglan);
            SqlDataReader rdr = cmd.ExecuteReader();
            int rowCount = 0; 
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr["ID"].ToString(), rdr["Ad"].ToString(),
                rdr["Soyad"].ToString(),
                rdr["Telefon"].ToString(),
                rdr["TC"].ToString(),
                rdr["Giris_Tarihi"].ToString(),
                rdr["Cikis_Tarihi"].ToString(),
                rdr["Cinsiyet"].ToString()
                );
                rowCount++; 
            }
            baglan.Close();

            if (rowCount == 0)
            {
                MessageBox.Show("Böyle bir müşteri kaydı bulunmuyor!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtAra.Text = "";          
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {         
            txtAd.Copy();
            txtSoyad.Copy();
            mTxtTel.Copy();
            txtTC.Copy();
            mTxtGiris.Copy();
            mTxtCikis.Copy();                   
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            txtAd.Paste();
            txtSoyad.Paste();
            mTxtTel.Paste();
            txtTC.Paste();
            mTxtGiris.Paste();
            mTxtCikis.Paste();
            txtAra.Paste();
            
        }

        private void tamEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void küçükEkranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Dosyası |*.docx"; 
            DialogResult cevap = sfd.ShowDialog();
            if (cevap == DialogResult.OK)
            {
                
            }

        }














































































































































































































































































































































































































































































































































































































































































































































































































































































        

        private void koyuTemaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.DimGray;
            groupBox2.BackColor = Color.DimGray;

            groupBox1.ForeColor = Color.WhiteSmoke;
            groupBox2.ForeColor = Color.WhiteSmoke;

            this.BackColor = Color.DimGray;

            dataGridView1.BackgroundColor = Color.DimGray;
        }

        private void açıkTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.BackColor = Color.Gainsboro;
            groupBox2.BackColor = Color.Gainsboro;

            groupBox1.ForeColor = Color.Black;
            groupBox2.ForeColor = Color.Black;

            this.BackColor = Color.SlateGray;

            dataGridView1.BackgroundColor = Color.Gainsboro;
        }   

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from FitSporTable where Ad like '%" + txtAra.Text + "%'", baglan);
            SqlDataReader rdr = cmd.ExecuteReader();
            int rowCount = 0;
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(rdr["ID"].ToString(), rdr["Ad"].ToString(),
                rdr["Soyad"].ToString(),
                rdr["Telefon"].ToString(),
                rdr["TC"].ToString(),
                rdr["Giris_Tarihi"].ToString(),
                rdr["Cikis_Tarihi"].ToString(),
                rdr["Cinsiyet"].ToString()
                );
                rowCount++;
            }
            baglan.Close();

            if (rowCount == 0)
            {
                MessageBox.Show("Böyle bir müşteri kaydı bulunmuyor!",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
