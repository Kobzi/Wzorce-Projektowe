using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            Caretaker caretaker = new Caretaker();
            Originator originator = new Originator();
            string wartosc;

            wartosc = "nazwa1";
            originator.SetState(wartosc);
            caretaker.Memento = originator.CreateMemento();

            wartosc = "nazwa2";
            originator.SetState(wartosc);
            caretaker.Memento = originator.CreateMemento();

            wartosc = "nazwa3";
            wartosc = "nazwa4";

            Console.WriteLine("Ostatnia wartość: " + wartosc);

            // przywracanie poprzedniej wartosci do originatora a potem do zmiennej
            originator.SetMemento(caretaker.Memento); 
            wartosc = originator.GetState();
            Console.WriteLine("Przywrocona wartosc: " +wartosc);

            Console.ReadLine();
        }
    }
}
