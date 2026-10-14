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
using Microsoft.Win32;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        List<string> blockedSites = new List<string> { "facebook", "instagram", "twitter", "kutya" };
        bool engedelyezett = false;
        private async void Navigalas(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return;

            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                if (url.Contains(" ") || !url.Contains("."))
                {
                    url = "https://www.bing.com/search?q=" + Uri.EscapeDataString(url);
                }
                else
                {
                    url = "http://" + url;
                }
            }

            string lowerUrl = url.ToLower();
            string talalat = await Task.Run(() => blockedSites.FirstOrDefault(w => lowerUrl.Contains(w)));

            if(talalat != null)
            {
                LogAsync("Blocked site attempt: " + url);
                MessageBox.Show("This site is blocked: " + talalat);
            }
            else
            {
                LogAsync("Navigated to: " + url);
                webBrowser1.Navigate(url);
            }
        }

        private void Bongeszoverzio()
        {
            string exe = Process.GetCurrentProcess().ProcessName + ".exe";
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION"))
            {
                key.SetValue(exe, 11001, RegistryValueKind.DWord);
            }
        }
        public Form1()
        {
            Bongeszoverzio();
            InitializeComponent();
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;
            toolStripComboBox1.Items.AddRange(blockedSites.ToArray());
        }

        
        private Task LogAsync(string uzenet)
        {
            string sor = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " - " + uzenet;
            return Task.Run(() => Trace.WriteLine(sor));
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
            LogAsync("Home button pushed: " + webBrowser1.Url);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
            LogAsync("Back button pushed: " + webBrowser1.Url);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
            LogAsync("Forward button pushed: " + webBrowser1.Url);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Navigalas(toolStripTextBox1.Text);
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Navigalas(toolStripTextBox1.Text);
                e.SuppressKeyPress = true; // Prevents the ding sound when pressing Enter
            }
        }

        

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string url = e.Url.ToString().ToLower();
            string talalat = blockedSites.FirstOrDefault(w => url.Contains(w));

            if (talalat != null)
            {
                e.Cancel = true;
                MessageBox.Show("This site is blocked: " + talalat);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            string szo = toolStripTextBox2.Text.Trim().ToLower();
            if (szo == "") return;

            if (blockedSites.Any(w => w == szo))
            {
                MessageBox.Show("Mar a listaban van: " + szo);
            }
            else
            {
                blockedSites.Add(szo);
                toolStripComboBox1.Items.Add(szo);
                LogAsync("Uj kulcsszo: " + szo);
            }
            toolStripTextBox2.Clear();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
