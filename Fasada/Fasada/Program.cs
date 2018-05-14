using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasada
{
    class Program
    {
        static void Main(string[] args)
        {
            Person user = new Person();
            user.setImie("Jan");
            user.setNazwisko("Kowalski");

            Console.WriteLine("Imie: " +user.getImie());
            Console.WriteLine("Nazwisko: " +user.getNazwisko());

            Console.WriteLine("\nWyświetlenie imienia i nazwiska przez inną klasę:");
            PersonFacade userFacade = new PersonFacade(user);
            Console.WriteLine(userFacade.getName());



            Console.ReadLine();
        }
    }
}
