using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main()
        {
            MatmaProxy proxy = new MatmaProxy();

            Console.WriteLine("wykonuje funkcje matematyczne przy użyciu proxy");
            Console.WriteLine( "3 + 4 = " + proxy.Dodawanie(3, 4) );
            Console.WriteLine( "3 - 1 = " + proxy.Odejmowanie(3, 1) );
            Console.WriteLine( "3 * 4 = " + proxy.Mnozenie(3, 4) );
            Console.WriteLine( "6 / 3 = " + proxy.Dzielenie(6, 3) );

            Console.ReadLine();
        }
    }

    public interface IMatma
    {
        double Dodawanie(double x, double y);
        double Odejmowanie(double x, double y);
        double Mnozenie(double x, double y);
        double Dzielenie(double x, double y);
    }

    class Matma : IMatma
    {
        public double Dodawanie(double x, double y) { return x + y; }
        public double Odejmowanie(double x, double y) { return x - y; }
        public double Mnozenie(double x, double y) { return x * y; }
        public double Dzielenie(double x, double y) { return x / y; }
    }


    class MatmaProxy : IMatma
    {
        private Matma matma = new Matma();
        public double Dodawanie(double x, double y)
        {
            return matma.Dodawanie(x, y);
        }

        public double Odejmowanie(double x, double y)
        {
            return matma.Odejmowanie(x, y);
        }

        public double Mnozenie(double x, double y)
        {
            return matma.Mnozenie(x, y);
        }

        public double Dzielenie(double x, double y)
        {
            return matma.Dzielenie(x, y);
        }
    }
}
