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
    public partial class Stok : Form
    {
        public Stok()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=COUNTZ\\SQLEXPRESS;Initial Catalog=FitSporDB;Integrated Security=True");
        void veriler()
        {
            dataGridView1.Rows.Clear();
            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from StokTable", baglan);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                dataGridView1.Rows.Add(
                rdr["Yiyecekler"].ToString(),
                rdr["Icecekler"].ToString(),
                rdr["Aletler"].ToString()
                );
            }
            baglan.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand cmd = new SqlCommand("insert into StokTable (Yiyecekler, Icecekler, Aletler) values ('" + txtYiyeck.Text + "','" + txtIceck.Text + "','" + txtAlet.Text + "')",baglan);
            cmd.ExecuteNonQuery();
            baglan.Close();
            veriler();
        }

        private void Stok_Load(object sender, EventArgs e)
        {
            veriler();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtYiyeck.Text, out int textBox1Value) &&
            int.TryParse(txtIceck.Text, out int textBox2Value) &&
            int.TryParse(txtAlet.Text, out int textBox3Value))
            {
                
                int sayi1 = textBox1Value * 15;
                int sayi2 = textBox2Value * 7;
                int sayi3 = textBox3Value * 50;

                
                int toplamSonuc = sayi1 + sayi2 + sayi3;

                
                lblGider.Text = $"-{toplamSonuc}";
            }
        }
    }
}
