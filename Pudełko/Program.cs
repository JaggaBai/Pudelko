using System;
using System.Collections.Generic;

namespace Pudełko
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> wkład = new List<double>(){ 2.5, 9.321, 0.1 };
            Pudełko p = new Pudełko(wkład, UnitOfMeasure.meter);
            var pp=p.A;
           
            Console.WriteLine(pp);
            string g = p.ToString("cm");
            Console.WriteLine(g);

        }
    }
}
