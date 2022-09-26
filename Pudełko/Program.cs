using System;
using System.Collections.Generic;

namespace Pudełko
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> wkład = new List<double>(){ 3, 3, 2 };
            Pudełko p = new Pudełko(wkład, UnitOfMeasure.centimeter);
            var pp=p.A;
           
            Console.WriteLine(pp);
            //Console.WriteLine(zz);

        }
    }
}
