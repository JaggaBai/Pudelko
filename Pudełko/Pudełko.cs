using System;
using System.Collections.Generic;
using System.Text;

namespace Pudełko
{
    public class Pudełko
    {
        UnitOfMeasure miara { get; set; }
        private double A { get; set; }
        private double B { get; set; }
        private double C { get; set; }

        public Pudełko(double a = 0.1, double b = 0.1, double c =0.1, UnitOfMeasure u = UnitOfMeasure.meter)
        {
            A = a;
            B = b;
            C = c;
            miara = u;
        }
    }
}
