using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3_1
{
    public class Moikkaaja
    {
        string moi;
        string kieli;

        public void ValitseKieli(string lyhenne)
        {
            string fi = "fi";
            string en = "en";

            if (lyhenne == "fi") kieli = fi;
            if (lyhenne == "en") kieli = en;

            HaeMoikkaus(kieli);
        }
        public void AsetaMoi(string uusiMoi) 
        {
            moi = uusiMoi;
        }

        public string HaeMoikkaus(string kieli)
        {
            if (moi == null && kieli == "fi") moi = "Moiii";
            if (moi == null && kieli == "en") moi = "Hiii";

            return moi;
        }
        public void Moikkaa()
        {
            
            Console.WriteLine(moi);
        }

        public void Moikkaa(string omaMoi)
        {
            moi = omaMoi;
            Console.WriteLine(moi);
        }
    }
}
