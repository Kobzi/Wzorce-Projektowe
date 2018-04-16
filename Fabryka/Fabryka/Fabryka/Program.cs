using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    class Program
    {
        static void Main(string[] args)
        {
            FactoryInterface item = null;

            try
            {
                item = Factory.createObject("Users");

                item.addItem("Jan");
                item.addItem("Adam");
                item.sortItems(0);
                Console.WriteLine(item.listItems());
            }
            catch (Exception e)
            {
                Console.WriteLine("Błąd: " + e.Message);
            }

            try
            {
                item = Factory.createObject("Products");

                item.addItem("Maka");
                item.addItem("Szynka");
                item.sortItems(1);
                Console.WriteLine(item.listItems());
            }
            catch (Exception e)
            {
                Console.WriteLine("Nie udalo sie: " + e.Message);
            }

            Console.Read();
        }
    }
}
