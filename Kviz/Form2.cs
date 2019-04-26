using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Kviz
{
    public partial class Form2 : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zvukPitanjaRezultati";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Moraš da uneseš pitanje, odgovor i vrednost pitanja.");
                return;
            }
            else
            {
                listBox1.Items.Add(new Pitanje(textBox1.Text, textBox2.Text, Convert.ToInt32(numericUpDown1.Value)));
                
                textBox1.Clear();
                textBox2.Clear();
                numericUpDown1.Value = 3;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1) MessageBox.Show("Moraš da obeležiš pitanje u listbox-u.");
            else
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listBox1.Items.Count == 0)
                return;
            StreamWriter sw = new StreamWriter(File.Create(path + "\\pitanja.txt"));
            foreach (var red in listBox1.Items)
                sw.WriteLine(red.ToString());
            sw.Dispose();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (File.Exists(path + "\\pitanja.txt"))
            {
                StreamReader sr = new StreamReader(File.OpenRead(path + "\\pitanja.txt"));
                while (!sr.EndOfStream)
                    listBox1.Items.Add(sr.ReadLine());
                sr.Dispose();
            }
        }
    }
}
