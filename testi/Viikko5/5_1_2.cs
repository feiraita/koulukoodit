// OmaCanvas.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Viikko5_1
{
    internal class OmaCanvas : Canvas
    {
        double x = 200;
        double y = 200;
        public List<System.Windows.Point> pisteet { get; } = [];

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc); // Väri, Reunaväri(väri, paksuus), Koordinaatit, Radius
            foreach(var item in pisteet)
            {
                dc.DrawEllipse(Brushes.MistyRose, new Pen(Brushes.HotPink, 2), item, 50, 50);
            }
        }

        public void SetXY(double uusi_x, double uusi_y)
        {
            x = uusi_x;
            y = uusi_y;
            var p = new Point(x, y);
            pisteet.Add(p);

            InvalidateVisual();
        }
    }
}
