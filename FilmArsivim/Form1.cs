using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Web.WebView2.WinForms;
namespace FilmArsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=localhost\SQLEXPRESS01;initial Catalog=FilmArsiv;Integrated Security=true");
        Random rnd = new Random();
        int sonRenk = -1;

        Color[] renkler =
        {
            Color.LightSlateGray,
            Color.SteelBlue,
            Color.CadetBlue,
            Color.DarkSeaGreen,
            Color.IndianRed,
            Color.Goldenrod,
            Color.MediumPurple,
            Color.LightCoral,
            Color.Teal,
            Color.DarkOrange
        };


        void filmler()
        {
            SqlDataAdapter db = new SqlDataAdapter("Select * from TblFilmler", baglanti);
            DataTable dt= new DataTable();
            db.Fill(dt);
            dataGridView1.DataSource = dt;


        }




        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            filmler();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TblFilmler (AD,KATEGORI,LINK) VALUES (@P1,@P2,@P3)", baglanti);
            komut.Parameters.AddWithValue("@P1", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@P2", txtKategoriAd.Text);
            komut.Parameters.AddWithValue("@P3", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Listenize Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmler();
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Navigate(link);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            if (webView21.Source == null || webView21.Source.ToString() == "about:blank")
            {
                MessageBox.Show("Önce listeden bir film seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Form1'deki videoyu durdur ki iki ses birden çalmasın
            webView21.ExecuteScriptAsync("document.querySelector('video')?.pause()");

            Form2 frm = new Form2(webView21.Source.ToString());
            frm.Show();
        }

        private void btnRenkDegis_Click(object sender, EventArgs e)
        {
            int yeni;
            do
            {
                yeni = rnd.Next(renkler.Length);
            } while (yeni == sonRenk);   // aynı renk arka arkaya gelmesin

            sonRenk = yeni;
            this.BackColor = renkler[yeni];
        }
    }
}
