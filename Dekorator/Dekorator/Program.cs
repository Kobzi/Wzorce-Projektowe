using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dekorator
{
    // Standardowy motocykl
    abstract class Motocykl
    {
        protected string motocykl = "Motocykl podstawowy";

        virtual public String opis()
        {
            return motocykl;
        }

        public abstract double cena();
    }

    // abstrakcyjny dekorator
    abstract class Dekorator : Motocykl
    {
        public abstract override String opis();
    }

    // Przykładowe marki motocykli
    class Yamaha : Motocykl
    {

        public Yamaha()
        {
            motocykl = "Yamaha";
        }

        public override double cena()
        {
            return 195000;
        }
    }

    class Honda : Motocykl
    {

        public Honda()
        {
            motocykl = "Honda";
        }

        public override double cena()
        {
            return 180000;
        }
    }

    class Kawasaki : Motocykl
    {

        public Kawasaki()
        {
            motocykl = "Kawasaki";
        }

        public override double cena()
        {
            return 200000;
        }
    }

    /* czas na same dodatki */
    class Bagaznik : Dekorator
    {
        Motocykl motor;

        public Bagaznik(Motocykl motocykl)
        {
            motor = motocykl;
        }

        public override String opis()
        {
            return motor.opis() + " + bagażnik";
        }

        public override double cena()
        {
            if (motor is Yamaha)
            {
                return motor.cena() + 10000;
            }
            else if (motor is Honda)
            {
                return motor.cena() + 20000;
            }
            else if (motor is Kawasaki)
            {
                return motor.cena() + 15000;
            }
            return 0;
        }
    }

    class MocniejszaWersja : Dekorator
    {
        Motocykl motor;

        public MocniejszaWersja(Motocykl motocykl)
        {
            motor = motocykl;
        }

        public override String opis()
        {
            return motor.opis() + " + mocniejsza wersja silnikowa";
        }
        
        public override double cena()
        {
            return motor.cena() + 30000;
        }
    }


    public class Application
    {
        public static void Main(String[] args)
        {
            Motocykl s1 = new Yamaha();
            Motocykl s2 = new Honda();
            Motocykl s3 = new Kawasaki();

            Console.WriteLine("Ceny motocykli bez wyposazenia");
            Console.WriteLine(s1.opis() + " " + s1.cena());
            Console.WriteLine(s2.opis() + " " + s2.cena());
            Console.WriteLine(s3.opis() + " " + s2.cena());


            Console.WriteLine("\nCeny motocykli z różnym wyposazeniem");
            s1 = new Bagaznik(s1);
            s2 = new Bagaznik(s2);
            s3 = new Bagaznik(s3);
            Console.WriteLine(s1.opis() + " " + s1.cena());
            Console.WriteLine(s2.opis() + " " + s2.cena());
            Console.WriteLine(s3.opis() + " " + s3.cena());

            s1 = new MocniejszaWersja(s1);
            s2 = new MocniejszaWersja(s2);
            Console.WriteLine(s1.opis() + " " + s1.cena());
            Console.WriteLine(s2.opis() + " " + s2.cena());

            s1 = new MocniejszaWersja(new Yamaha());
            s2 = new MocniejszaWersja(new Honda());
            Console.WriteLine(s1.opis() + " " + s1.cena());
            Console.WriteLine(s2.opis() + " " + s2.cena());


            Console.WriteLine("\nPelne wyposazenie");
            s3 = new MocniejszaWersja(new Bagaznik(new Kawasaki()));
            Console.WriteLine(s3.opis() + " " + s3.cena());
            Console.ReadLine();
        }
    }
}
