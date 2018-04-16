using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    public interface FactoryInterface
    {
        String listItems();

        String deleteItem(int index);
        String addItem(String user);

        void sortItems(int order);
    }
}
