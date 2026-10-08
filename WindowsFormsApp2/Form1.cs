using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Color szovegSzin = Color.Black;
        MyThread mt;

        public Form1()
        {
            InitializeComponent();
            mt = new MyThread(Draw, () => this.ClientSize.Width);
        }

        public void Draw(int x)
        {
            using (Graphics g = this.CreateGraphics())
            using (Font f = new Font("Arial", 20))
            using (SolidBrush b = new SolidBrush(szovegSzin))
            {
                g.Clear(this.BackColor);
                g.DrawString("Szia", f, b, x, 100);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            mt.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mt.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = this.BackColor;

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = dlg.Color;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = szovegSzin;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                szovegSzin = dlg.Color;
            }
        }
    }
}
