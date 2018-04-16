using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    class Privilages : FactoryInterface
    {
         List<String> list;
        public Privilages()
        {
            list = new List<string>();
        }

        string FactoryInterface.addItem(String privilage)
        {
            list.Add(privilage);

            return "Dodano uprawnienie: " + privilage;
        }

        string FactoryInterface.deleteItem(int index)
        {
            list.RemoveAt(index);

            return "Usunieto uprawnienie o indeksie: " + index;
        }

        string FactoryInterface.listItems()
        {
            foreach (object privilage in list)
                Console.WriteLine("Nazwa uprawnienia: " + privilage);

            return "";
        }

        void FactoryInterface.sortItems(int order)
        {
            if (order == 0)
                list.Sort();
            else
            {
                list.Sort();
                list.Reverse();
            }
        }
    }
}
