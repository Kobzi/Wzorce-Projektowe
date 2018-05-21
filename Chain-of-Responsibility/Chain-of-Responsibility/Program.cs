using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Approver Jan = new Pracownik();
            Approver Patryk = new Kierownik();
            Approver Andrzej = new Dyrektor();
            
            Jan.SetNatepny(Patryk);
            Patryk.SetNatepny(Andrzej);

            Zakup p = new Zakup(2034, 350.00, "Dodatki");

            Jan.WykonajZapytanie(p);
            p = new Zakup(2035, 32590.10, "Project X");

            Jan.WykonajZapytanie(p);
            p = new Zakup(2036, 122100.00, "Project Y");

            Jan.WykonajZapytanie(p);
            Console.ReadKey();
        }
    }

    abstract class Approver
    {
        protected Approver nastepny;
        public void SetNatepny(Approver nastepny)
        {
            this.nastepny = nastepny;
        }
        public abstract void WykonajZapytanie(Zakup purchase);
    }

    class Pracownik : Approver
    {
        public override void WykonajZapytanie(Zakup zakup)
        {
            if (zakup.Ilosc < 10000.0)
            {
                Console.WriteLine(this.GetType().Name+ " zrobi zakup: " + zakup.Liczba);
            }
            else if (nastepny != null)
            {
                nastepny.WykonajZapytanie(zakup);
            }
        }
    }

    class Kierownik : Approver
    {
        public override void WykonajZapytanie(Zakup zakup)
        {
            if (zakup.Ilosc < 25000.0)
            {
                Console.WriteLine(this.GetType().Name + " zrobi zakup: " + zakup.Liczba);
            }
            else if (nastepny != null)
            {
                nastepny.WykonajZapytanie(zakup);
            }
        }
    }

    class Dyrektor : Approver
    {
        public override void WykonajZapytanie(Zakup zakup)
        {
            if (zakup.Ilosc < 100000.0)
            {
                Console.WriteLine(this.GetType().Name + " zrobi zakup: " + zakup.Liczba);
            }
            else
            {
                Console.WriteLine(
                  "Wykonanie zakupu " +zakup.Liczba+ " wymaga dodatkowego spotkania");
            }
        }
    }

    class Zakup
    {
        public int Liczba { get; set; }
        public double Ilosc { get; set; }
        public string Cel { get; set; }

        public Zakup(int liczba, double ilosc, string cel)
        {
            this.Liczba = liczba;
            this.Ilosc = ilosc;
            this.Cel = cel;
        }
    }
}
