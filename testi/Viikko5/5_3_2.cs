//Kivi.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viikko5_3
{
    internal class Kivi
    {
        public string nimi { get; set; }
        public int paino {  get; set; } // gramma
        public string karheusAste {  get; set; }

        private int _yleisArvosana { get; set; }
        public int yleisArvosana
        {
            get
            {
                return _yleisArvosana;
            }
            set
            {
                var tempNumero = value;
                if (tempNumero < 0) tempNumero = 0;
                if (tempNumero > 10) tempNumero = 10;
                _yleisArvosana = tempNumero;
            }
        }

        public string tunnisteTieto { get
            {
                return nimi[0] + (paino * 3).ToString();
            }
        }

        public Kivi(string nimi, int paino, string karkeusAste, int ylesiArvosana) 
        {
            this.nimi = nimi;
            this.paino = paino;
            this.karheusAste = karkeusAste;
            this.yleisArvosana = ylesiArvosana;
        }
    }
}
