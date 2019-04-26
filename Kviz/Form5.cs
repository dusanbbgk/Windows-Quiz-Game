using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kviz
{
    public partial class Form5 : Form
    {
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zvukPitanjaRezultati";

        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label2.Text = "ime" + "       " + "poeni" + "             " + "datum";
            if (File.Exists(path + "\\rezultati.txt"))
            {
                StreamReader sr = new StreamReader(File.OpenRead(path + "\\rezultati.txt"));
                while (!sr.EndOfStream)
                    listBox1.Items.Add(sr.ReadLine());
                sr.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
