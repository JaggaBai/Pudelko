using System;
using System.Collections.Generic;
using System.Text;

namespace Pudełko
{
    public sealed class Pudełko
    {

        UnitOfMeasure miara { get; set; }
        //private double A { get
        //    set
        //    {
        //        ListaPo[0];
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

            if (lista == null)
            {
                lista = new List<double>();
                lista.Add(10);
                lista.Add(10);
                lista.Add(10);
                u = UnitOfMeasure.centimeter;
            }
            //Jeśli podano mniej niż 3 wartości liczbowe, pozostałe przyjmuje się jako o wartości 10 cm, ale dla ustalonej jednostki miary.
            if (lista.Count < 3) //może być prościej ale nie wiem jak to kompetentnie zrobić/ bez błędu
            {
                if (lista.Count == 0)
                { if (u == UnitOfMeasure.milimeter)
                    {
                        lista.Add(1000);
                        lista.Add(1000);
                        lista.Add(1000);
                    }
                    else if (u == UnitOfMeasure.centimeter)
                    {
                        lista.Add(10);
                        lista.Add(10);
                        lista.Add(10);
                    }
                    else
                    {
                        lista.Add(0.1);
                        lista.Add(0.1);
                        lista.Add(0.1);
                    }
                }
                else if (lista.Count == 1)
                {


                    if (u == UnitOfMeasure.milimeter)
                    {
                        lista.Add(1000);
                        lista.Add(1000);
                    }
                    else if (u == UnitOfMeasure.centimeter)
                    {
                        lista.Add(10);
                        lista.Add(10);
                    }
                    else
                    {
                        lista.Add(0.1);
                        lista.Add(0.1);
                    }

                }
                else if (lista.Count == 2)
                {
                    if (u == UnitOfMeasure.milimeter)
                    {
                        lista.Add(1000);
                    }
                    else if (u == UnitOfMeasure.centimeter)
                    {
                        lista.Add(10);
                    }
                    else
                    {
                        lista.Add(0.1);
                    }
                }
            }

            ListaPo = lista;
        }
    }
}
