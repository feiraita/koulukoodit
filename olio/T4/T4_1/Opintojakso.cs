using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4_1
{
    internal class Opintojakso
    {
        public string Nimi { get; set; }
        public List<Opettaja> Opettajat { get; set; }

        public Opintojakso(string nimi)
        {
            Nimi = nimi;
            Opettajat = new List<Opettaja>();
        }

        public void LisaaOpettaja(Opettaja opettaja)
        {
            Opettajat.Add(opettaja);
        }

        public override string ToString()
        {
            string stringgi = "";
            foreach (var opettaja in Opettajat)
            {
                stringgi += opettaja.ToString() + " ";
            }
            return "Opintojakso: " + Nimi + " Opettaja: " + stringgi;
        }
    }
}