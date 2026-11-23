using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
namespace FilmArsivim
{
    public partial class Form2 : Form
    {
        string link;
        public Form2(string gelenLink)
        {
            InitializeComponent();
            link = gelenLink;
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            await webView21.EnsureCoreWebView2Async();
            webView21.CoreWebView2.Navigate(link);
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
