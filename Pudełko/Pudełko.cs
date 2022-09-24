using System;
using System.Collections.Generic;
using System.Text;

namespace Pudełko
{
    public sealed class Pudełko
    {

        UnitOfMeasure miara { get; set; }
        //Zaimplementuj properties o nazwach A, B i C zwracające wymiary pudełka w metrach(z dokładnością do 3 miejsc po przecinku).
        private double _a;
        private double _b;
        private double _c;
        public double A   
        {
            get { return _a; }
            set
            {
                if (miara == UnitOfMeasure.meter)
                { 
               _a = Math.Round(value, 3); }
                else if (miara == UnitOfMeasure.centimeter)
                {
                    
                    _a = Math.Round((value *100), 3);
                }
                else if (miara == UnitOfMeasure.milimeter)
                {
                   
                    _a = Math.Round((value * 1000), 3);
                }
            }
        }
        public double B
        {
            get { return _b; }
            set
            {
                if (miara == UnitOfMeasure.meter)
                {
                    _b = Math.Round(value, 3);
                }
                else if (miara == UnitOfMeasure.centimeter)
                {

                    _b = Math.Round((value * 100), 3);
                }
                else if (miara == UnitOfMeasure.milimeter)
                {

                    _b = Math.Round((value * 1000), 3);
                }
            }
        }
        public double C
        {
            get { return _c; }
            set
            {
                if (miara == UnitOfMeasure.meter)
                {
                    _c = Math.Round(value, 3);
                }
                else if (miara == UnitOfMeasure.centimeter)
                {

                    _c = Math.Round((value * 100), 3);
                }
                else if (miara == UnitOfMeasure.milimeter)
                {

                    _c = Math.Round((value * 1000), 3);
                }
            }
        }


        private List<double> ListaPo = new List<double>();

        public Pudełko(List<double> lista = default(List<double>)/*null?*/, UnitOfMeasure u = UnitOfMeasure.meter)
        {
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
            _a = lista[0];
            _b = lista[1];
            _c = lista[2];
            miara = u;
            ListaPo = lista;
        }
    }
}
