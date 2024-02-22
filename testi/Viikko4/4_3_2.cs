//Engine.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viikko4_3
{
    internal class Engine
    {
        public double Size { get; set; }

        public Engine(double v)
        {
            Size = v;
        }

        public override string? ToString()
        {
            return " has " + Size + "l engine";
        }
    }
}
