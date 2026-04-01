namespace FirstOfMany.Models
{
    public class Motorcycle
    {
        public string Merkki { get; set; } = string.Empty; /* tai vaan = ""; */
        public string Malli { get; set; } = string.Empty;
        public int Vuosi { get; set; }
        public string Vari { get; set; } = string.Empty;

        public Motorcycle(string merkki, string malli, int vuosi, string vari) {
            Merkki = merkki;
            Malli = malli;
            Vuosi = vuosi;
            Vari = vari;
        }
    }
}
