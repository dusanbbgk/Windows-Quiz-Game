using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kviz
{
    public class Pitanje
    {
        private string pitanje;
        private string odgovor;
        private int vrednost;

        public Pitanje(string pitanje, string odgovor, int vrednost)
        {
            this.pitanje = pitanje;
            this.odgovor = odgovor;
            this.vrednost = vrednost;
        }
        
        public string dohvatiPitanje()
        {
            return pitanje;
        }

        public string dohvatiOdgovor()
        {
            return odgovor;
        }

        public int dohvatiVrednost()
        {
            return vrednost;
        }

        public override string ToString()
        {
            return pitanje + " - " + odgovor + " - " + vrednost;
        }
    }
}
