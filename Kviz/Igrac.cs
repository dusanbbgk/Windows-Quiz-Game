using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kviz
{
    public class Igrac
    {
        private string ime;
        private int bodovi;

        public Igrac(string ime)
        {
            this.ime = ime;
        }

        public string dohvatiIme()
        {
            return ime;
        }
        public int dohvatiBodove()
        {
            return bodovi;
        }

        public void upisiPoene(int poeni)
        {
            bodovi = poeni;
        }
        public override string ToString()
        {
            return ime + ":\t" + bodovi;
        }
    }
}
