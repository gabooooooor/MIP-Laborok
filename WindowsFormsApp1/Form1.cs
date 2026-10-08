using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Felfele mesz?", "UP", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //textBox1.Text = result.ToString();

            this.Top -= 10;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Hiba tortent!", "DOWN", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            //textBox1.Text = result.ToString();

            this.Top += 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Mentsuk el a valtozasokat?", "LEFT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            //textBox1.Text = result.ToString();

            this.Left -= 10;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Folytatod?", "RIGHT", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            //textBox1.Text = result.ToString();

            this.Left += 10;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        Random rnd = new Random();

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { 
                int ertek;
                if (int.TryParse(textBox2.Text, out ertek) && ertek > 0)
                {
                    timer1.Interval = ertek;
                }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label3.Location = new Point(0, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label3.Location = new Point(this.ClientSize.Width - label3.Width, 0);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label3.Location = new Point(0, this.ClientSize.Height - label3.Height);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label3.Location = new Point(this.ClientSize.Width - label3.Width, this.ClientSize.Height - label3.Height);
        }
        bool fent = false;

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            //label3.Location = new Point(rnd.Next(this.ClientSize.Width - label3.Width), rnd.Next(this.ClientSize.Height - label3.Height));
            if (fent)
            {
                label3.Location = new Point(0,this.ClientSize.Height - label3.Height);
                fent = false;
            }
            else
            {
                label3.Location = new Point(0, 0);
                fent = true;
            }
        }

        int hely;

        private void button11_MouseEnter(object sender, EventArgs e)
        {
            Rectangle kepernyo = Screen.PrimaryScreen.WorkingArea;

            if(hely == 0)
            {
                this.Location = new Point(kepernyo.Width - this.Width, 0);
                hely = 1;
            }
            else if (hely == 1)
            {
                this.Location = new Point(kepernyo.Width - this.Width, kepernyo.Height - this.Height);
                hely = 2;
            }
            else if (hely == 2)
            {
                this.Location = new Point(0, kepernyo.Height - this.Height);
                hely = 3;
            }
            else
            {
                this.Location = new Point(0, 0);
                hely = 0;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(button12.Text == "Valtozason megyek keresztul")
            {
                button12.Text = "Meg varom a valtozasom";
            }
            else
                button12.Text = "Valtozason megyek keresztul";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            button16.BackColor = Color.Green;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            button16.BackColor = Color.Red;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
            label4.Font = new Font("Arial", 20, FontStyle.Bold);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Blue;
            label4.Font = new Font("Times New Roman", 15, FontStyle.Underline | FontStyle.Bold);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            label4.Font = new Font("Comic Sans MS", 20, FontStyle.Italic);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen toll = new Pen(Color.Black, 2);
            g.DrawRectangle(toll, 600, 200, 200, 100);
            g.DrawLine(toll, 600, 200, 800, 300);
            g.DrawLine(toll, 800, 200, 600, 300);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int meret = rnd.Next(20, 101);
            Graphics g = this.CreateGraphics();
            Pen toll = new Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)), 2);
            int x = rnd.Next(this.ClientSize.Width - meret);
            int y = rnd.Next(this.ClientSize.Height - meret);
            int type = rnd.Next(4); // 0: rectangle, 1: ellipse, 2: line
            
            switch (type)
            {
                case 0:
                    g.DrawRectangle(toll, x, y, meret, meret);
                    break;
                case 1:
                    g.DrawEllipse(toll, x, y, meret, meret);
                    break;
                case 2:
                    g.DrawLine(toll, x, y, x + meret, y + meret);
                    break;
                case 3:
                    g.DrawLine(toll, x + meret, y, x, y + meret);
                    break;  
            }
        }
    }
}
