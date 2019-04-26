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
    public partial class Form4 : Form
    {
        string danasnjiDatum = DateTime.Today.ToString("dd.MM.yyyy" + ".");
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zvukPitanjaRezultati";

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = "Osvojio si " + Form1.player.dohvatiBodove() + " poena!";
            StreamWriter sw = new StreamWriter(path + "\\rezultati.txt", true);
                sw.WriteLine(Form1.player.ToString() + "\t" + danasnjiDatum);
            sw.Dispose();
        }
    }
}
