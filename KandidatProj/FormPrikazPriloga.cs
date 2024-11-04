using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace KandidatProj
{
    public partial class FormPrikazPriloga : Form
    {
        private string _filePath;
        private WebView2 webView;
        public FormPrikazPriloga(string filePath)
        {
            InitializeComponent();
            _filePath = filePath;
        }

        private void FormPrikazPriloga_Load(object sender, EventArgs e)
        {
            // Inicijalizujte WebView2
            InitializeWebView();
            // Učitajte sadržaj fajla
            LoadFileInWebView(_filePath);
        }

        private void InitializeWebView()
        {
            webView = new WebView2
            {
                Dock = DockStyle.Fill // Popunjava celu formu
            };
            this.Controls.Add(webView);
        }

        private async void LoadFileInWebView(string filePath)
        {
            try
            {
                // Proverite ekstenziju fajla kako biste učitali odgovarajući tip
                string fileExtension = System.IO.Path.GetExtension(filePath).ToLower();

                if (fileExtension == ".pdf")
                {
                    // Učitajte PDF fajl
                    await webView.EnsureCoreWebView2Async();
                    webView.Source = new Uri(filePath);
                }
                else if (fileExtension == ".docx" || fileExtension == ".doc")
                {
                    // Učitajte Word dokument 
                    await webView.EnsureCoreWebView2Async();
                    webView.Source = new Uri(filePath);
                }
                else
                {
                    MessageBox.Show("Nepodržani format fajla.", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom učitavanja fajla: {ex.Message}", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}
