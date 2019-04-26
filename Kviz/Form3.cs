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
using System.Media;

namespace Kviz
{
    public partial class Form3 : Form
    {
        List<Pitanje> pitanja = new List<Pitanje>();
        int sekunde = 60;
        string trenutniOdgovor = "";
        int trenutnaVrednost = 0;
        int indexTrenutnogPitanja = 0;
        int brTacnihOdgovora = 0;
        int poeni = 0;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\zvukPitanjaRezultati";
        Igrac igrac = Form1.player;
        SoundPlayer zvukTacno = new SoundPlayer(@"C:\Users\Dusan Mandrapa\source\repos\Kviz\ding.wav");
        SoundPlayer zvukNetacno = new SoundPlayer(@"C:\Users\Dusan Mandrapa\source\repos\Kviz\wrong.wav");
        Random rnd = new Random();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!File.Exists(path + "\\pitanja.txt"))
            {
                MessageBox.Show("Trenutno nema pitanja u bazi.");
                Environment.Exit(0);
            }
            StreamReader sr = new StreamReader(File.OpenRead(path + "\\pitanja.txt"));
            while (!sr.EndOfStream)
            {
                string red = sr.ReadLine();
                string[] deloviPitanja = red.Split('-');
                string pitanje = deloviPitanja[0].Trim();
                string odgovor = deloviPitanja[1].Trim();
                int vrednost = Convert.ToInt32(deloviPitanja[2].Trim());
                pitanja.Add(new Pitanje(pitanje, odgovor, vrednost));
            }
            
            prikaziNovoPitanje();
            timer1.Start();
            timer2.Start();
            textBox1.Select();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            MessageBox.Show("Vreme je isteklo! Moraš biti malo brži.");
            igrac.upisiPoene(poeni);
            Form4 forma4 = new Form4();
            this.Hide();
            forma4.ShowDialog();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = "" + --sekunde;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.Equals(trenutniOdgovor.Trim(), textBox1.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                var soundPlayer = new System.Media.SoundPlayer(path + "\\ding.wav");
                soundPlayer.Play();
                //zvukTacno.Play();
                poeni += trenutnaVrednost;
                brTacnihOdgovora++;
                label5.Text = "Broj tačnih odgovora: " + Convert.ToString(brTacnihOdgovora);
                label7.Text = "Trenutni poeni: " + Convert.ToString(poeni);
                pitanja.RemoveAt(indexTrenutnogPitanja);
                textBox1.Clear();
                prikaziNovoPitanje();
            }
            else
            {
                var soundPlayer = new System.Media.SoundPlayer(path + "\\wrong.wav");
                soundPlayer.Play();
                //zvukNetacno.Play();
                textBox1.Clear();
                MessageBox.Show("Odgovor nije tačan! Pokušaj ponovo ili preskoči pitanje.");         
            }
        }
        public void prikaziNovoPitanje()
        {
            if (pitanja.Count > 0)
            {  
                label9.Text = "Još " + pitanja.Count + " pitanja do kraja.";
                int r = rnd.Next(0, pitanja.Count);
                label3.Text = pitanja[r].dohvatiPitanje();
                trenutniOdgovor = pitanja[r].dohvatiOdgovor();
                trenutnaVrednost = pitanja[r].dohvatiVrednost();
                indexTrenutnogPitanja = r;
            }
            else
            {
                label9.Text = "Nema više pitanja";
                timer1.Stop();
                timer2.Stop();
                MessageBox.Show("Odgovorio si na sva pitanja tačno! Čestitamo!");
                poeni += sekunde;
                timer1.Stop();
                timer2.Stop();
                igrac.upisiPoene(poeni);
                Form4 forma4 = new Form4();
                this.Hide();
                forma4.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            if (pitanja.Count == 1)
                MessageBox.Show("Ovo je poslednje pitanje.");
            else
            {
                prikaziNovoPitanje();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }
    }
}