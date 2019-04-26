using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kviz
{
    public partial class Form1 : Form
    {

        public static Igrac player;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Unesi ime!");
            else if(textBox1.Text.Trim() == "@admin")
            {
                textBox1.Clear();
                Form2 forma2 = new Form2();
                forma2.ShowDialog();

            }
            else
            {
                player = new Igrac(textBox1.Text.Trim());
                Form3 forma3 = new Form3();
                forma3.ShowDialog();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, new EventArgs());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 forma5 = new Form5();
            forma5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "@admin")
            { 
                textBox1.Clear();
                Form2 forma2 = new Form2();
                forma2.ShowDialog();
            }
            else MessageBox.Show("Samo admin može da doda pitanja! Ako si admin, unesi korisničko ime u textbox.");
        }
    }
}
