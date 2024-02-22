// Car.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viikko4_3
{
    internal class Car
    {
        //property -> prop
        public Engine Engine { get; set; }
        public Person Driver { get; set; }
        public string Model { get; set; }

        //Constructor
        public Car(double v) 
        {
            Engine = new Engine(v);
            // Engine.Size = v;
        }
        public override string? ToString()
        {
            return 
                Model + " " + 
                Engine.ToString() + ", and" + 
                Driver.ToString();
        }
    }

}
