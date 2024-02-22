//Tallentaja.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Viikko5_3
{
    internal static class Tallentaja
    {
        private const string TIEDOSTO_NIMI = "kivet.json";
        public static string testi()
        {
            return TIEDOSTO_NIMI;
        }

        private static string GetJsonPath()
        {
            string polku = System.Reflection.Assembly.GetExecutingAssembly().Location;
            polku = Path.GetDirectoryName(polku);
            string oikeaPolku = Path.Combine(polku, TIEDOSTO_NIMI);

            return oikeaPolku;
        }
        public static void TallennaKivet(List<Kivi> kivet)
        {
            try
            {
                var jsonKivilista = JsonSerializer.Serialize(kivet);
                File.WriteAllText(GetJsonPath(), jsonKivilista); // bin ->
            } 
            catch (Exception ex) { Console.WriteLine(ex);  }
            
        }
        public static List<Kivi> LataaKivet()
        {
            try
            {
                string polku = GetJsonPath();
                string raakaJson = File.ReadAllText(polku);
                var kivilista = JsonSerializer.Deserialize<List<Kivi>>(raakaJson);

                if(kivilista == null || kivilista.Count == 0) return new List<Kivi>();
            } 
            catch (Exception ex) { Console.WriteLine(ex); }

            return new List<Kivi>();
        }
    }
}
