using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    class Users : FactoryInterface
    {
        List<String> list;
        public Users()
        {
            list = new List<string>();
        }

        string FactoryInterface.addItem(String user)
        {
            list.Add(user);

            return "Dodano uzytkwonika: " + user;
        }

        string FactoryInterface.deleteItem(int index)
        {
            list.RemoveAt(index);

            return "Usunieto uzytkwonika o indeksie: " + index;
        }

        string FactoryInterface.listItems()
        {
            foreach (object user in list)
                Console.WriteLine("Nazwa uzytkownika: " + user);

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
