using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Ajoneuvo
    {
        string nimi;
        int ika;

        // Constructor method
        public Ajoneuvo(string nimi, int ika)
        {
            //this on "tämä objekti"
            this.nimi = nimi;
            Ika = ika;
        }

        // PROPERTY
        public string Omistaja { get; set; }

        // public int Ika { get => ika; set => ika = value; }
        public int Ika
        {
            get => ika;
            set
            {
                if(value >= 0)
                {
                    ika = value;
                }
            }
        }

        public void asetaNimi(string uusi)
        {
            nimi = uusi;
        }

        public string lueNimi()
        {
            return nimi;
        }

        public void asetaIka(int uusi)
        {
            if (ika >= 0) ika = uusi;
           
        }

        public int lueIka()
        {
            return ika;
        }
        public string Tiedot()
        {
            return nimi + " " + ika;
        }

        public override string ToString()
        {
            return nimi + " " + ika;
        }

        public void Tulosta()
        {
            Console.WriteLine(nimi + " " + ika);
        }
    }

    
}
