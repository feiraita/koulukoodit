using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_1
{
    internal class Oppilas
    {
        public string Nimi { get; set; }
        public List<Opintojakso> Opintojaksot { get; set; }

        public Oppilas(string nimi)
        {
            Nimi = nimi;
            Opintojaksot = new List<Opintojakso>();
        }

        public void LisaaOpintojakso(Opintojakso opintojakso)
        {
            Opintojaksot.Add(opintojakso);
        }

        public override string ToString()
        {
            string stringgi = "";
            foreach (var opintojakso in Opintojaksot)
            {
                stringgi += opintojakso.ToString() + " \n";
            }
            return "Oppilas: " + Nimi + "\n" + stringgi;
        }
    }
}
