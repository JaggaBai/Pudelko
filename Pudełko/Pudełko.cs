using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Pudełko
{
    public sealed class Pudełko : IFormattable
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

                    _a = Math.Round((value * 100), 3);
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
                {
                    if (u == UnitOfMeasure.milimeter)
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


//        Zapewnij reprezentację tekstową obiektu według formatu:
//«liczba» «jednostka» × «liczba» «jednostka» × «liczba» «jednostka»
//znak rozdzielający wymiary, to znak mnożenia × (Unicode: U+00D7, multiplication sign, times)
//pomiędzy liczbami, nazwami jednostek miar i znakami × jest dokładnie jedna spacja
//domyślne formatowanie liczb(przesłonięcie ToString()) w metrach, z dokładnością 3. miejsc po przecinku
     public override string ToString()
        {
            return this.ToString("bez", CultureInfo.CurrentCulture);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "bez";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "bez":
                    return A.ToString("N3") + "m " + "× " + B.ToString("N3") + "m" + " ×" + C.ToString("N3") + " m";
                case "m":
                    return A.ToString("N3") + "m " + "× " + B.ToString("N3") + "m" + " ×" + C.ToString("N3") + " m";
                case "cm":
                    return A.ToString("N1") + "cm " + "× " + B.ToString("N1") + "cm" + " ×" + C.ToString("N1") + " cm";
                case "mm":
                    return A.ToString("N0") + "mm " + "× " + B.ToString("N0") + "mm" + " ×" + C.ToString("N0") + " mm";
                default:
                    throw new FormatException(String.Format("{0} to zły format", format));
            }
        }

    }
    }

