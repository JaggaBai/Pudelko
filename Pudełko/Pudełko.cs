using System;
using System.Collections.Generic;
using System.Text;

namespace Pudełko
{
    public sealed class Pudełko
    {
       
        UnitOfMeasure miara { get; set; }
        //private double A { get
        //    set { ListaPo[0];
        //private double B { get; set; }
        //private double C { get; set; }

       
        private List<double> ListaPo = new List<double>();

        public Pudełko(List<double> lista = default(List<double>)/*null?*/, UnitOfMeasure u = UnitOfMeasure.meter)
        {
            miara = u;
            foreach (double n in lista)
            {
                //W przypadku próby utworzenia pudełka z którymkolwiek z parametrów niedodatnim, zgłaszany jest wyjątek ArgumentOutOfRangeException
                if (n < 0)
                { throw new ArgumentOutOfRangeException(); }
                //W przypadku próby utworzenia pudełka z którymkolwiek z parametrów większym niż 10 metrów, zgłaszany jest wyjątek ArgumentOutOfRangeException.
                else if (((u == UnitOfMeasure.milimeter) & (n > 100000)) || ((u == UnitOfMeasure.centimeter) & (n > 10000)) || ((u == UnitOfMeasure.meter) & (n > 10)))

                { throw new ArgumentOutOfRangeException(); }
            }
           // Wszystkie parametry konstruktora są opcjonalne.
        if (lista ==null)
            {
                lista = new List<double>();
                lista.Add(10);
                lista.Add(10);
                lista.Add(10); //mogłoby być prościej note
                u = UnitOfMeasure.centimeter;
            }
            
        }
    }
}
