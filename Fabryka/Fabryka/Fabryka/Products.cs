using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    class Products : FactoryInterface
    {
        List<String> list;
        public Products()
        {
            list = new List<string>();
        }

        string FactoryInterface.addItem(String user)
        {
            list.Add(user);

            return "Dodano produkt: " + user;
        }

        string FactoryInterface.deleteItem(int index)
        {
            list.RemoveAt(index);

            return "Usunieto produkt o indeksie: " + index;
        }

        string FactoryInterface.listItems()
        {
            foreach (object product in list)
                Console.WriteLine("Nazwa produktu: " + product);

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
