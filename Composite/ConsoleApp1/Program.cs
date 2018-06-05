using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            CompositeElement glowny = new CompositeElement("Główny");

            glowny.Dodaj(new PrimitiveElement("Liść A"));
            glowny.Dodaj(new PrimitiveElement("Liść B"));
            glowny.Dodaj(new PrimitiveElement("Liść C"));


            CompositeElement inny = new CompositeElement("Inny");

            inny.Dodaj(new PrimitiveElement("Liść Kolorowy A"));
            inny.Dodaj(new PrimitiveElement("Liść Kolorowy B"));

            glowny.Dodaj(inny);

            PrimitiveElement pe = new PrimitiveElement("Jeszcze Inny");  // Który i tak niżej jest usuwany

            glowny.Dodaj(pe);
            glowny.Usun(pe);
            glowny.Wyswietl(1);

            Console.ReadLine();
        }
    }

    abstract class RysowanieElementu
    {
        protected string _name;

        public RysowanieElementu(string name)
        {
            this._name = name;
        }

        public abstract void Dodaj(RysowanieElementu d);
        public abstract void Usun(RysowanieElementu d);
        public abstract void Wyswietl(int akapit);
    }

    class PrimitiveElement : RysowanieElementu
    {
        public PrimitiveElement(string name) : base(name)
        {
        }

        public override void Dodaj(RysowanieElementu c)
        {
            Console.WriteLine("Nie można dodać do PrimitiveElement");
        }

        public override void Usun(RysowanieElementu c)
        {
            Console.WriteLine("Nie można usunąć z PrimitiveElement");
        }

        public override void Wyswietl(int indent)
        {
            Console.WriteLine(new String('-', indent) + " " + _name);
        }
    }

    class CompositeElement : RysowanieElementu
    {
        private List<RysowanieElementu> elementy = new List<RysowanieElementu>();
        
        public CompositeElement(string name): base(name)
        {

        }
        public override void Dodaj(RysowanieElementu d)
        {
            elementy.Add(d);
        }

        public override void Usun(RysowanieElementu d)
        {
            elementy.Remove(d);
        }

        public override void Wyswietl(int akapit)
        {
            Console.WriteLine( new String('-', akapit) + "+ " + _name );

            foreach (RysowanieElementu d in elementy)
            {
                d.Wyswietl(akapit + 2);
            }
        }
    }
}
