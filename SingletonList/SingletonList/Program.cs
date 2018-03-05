using System;
using System.Collections.Generic;

namespace SingletonList
{
    public class SingletonList
    {
        protected static SingletonList instance = null;
        protected List<int> lista = new List<int>();

        public static SingletonList GetInstance()
        {
            if (instance == null)
                instance = new SingletonList();
            return instance;
        }

        public void Dodaj(int x)
        {
            lista.Add(x);
        }

        public void Usun(int x)
        {
            lista.RemoveAt(x);
        }

        public void Pokaz()
        {
            Console.Write("\n");

            foreach (object x in lista)
                Console.Write(x + ", ");
        }

        public int IloscElemento()
        {
            return lista.Count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SingletonList lista_01_Ob = SingletonList.GetInstance();

            lista_01_Ob.Dodaj(4);
            lista_01_Ob.Dodaj(5);
            lista_01_Ob.Dodaj(6);

            Console.Write("Przykład zastosowania wzorca Singleton w zwykłej liście \n\n");
            Console.Write("Elementy listy w obiekcie numer 1:");
            lista_01_Ob.Pokaz();

            SingletonList lista_02_Ob = SingletonList.GetInstance();

            lista_01_Ob.Usun(lista_01_Ob.IloscElemento() - 1);

            Console.Write("\nElementy listy w obiekcie numer 2, po usunięciu ostatniego elemenu listy w obiekcie numer 1:");
            lista_02_Ob.Pokaz();

            Console.ReadLine();
        }
    }
}
