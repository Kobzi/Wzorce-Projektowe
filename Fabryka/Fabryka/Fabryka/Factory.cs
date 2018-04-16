using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabryka
{
    public class Factory
    {
        public static FactoryInterface createObject(string className)
        {
            FactoryInterface interfejs = null;
            try
            {
                if (className.Equals("Users"))
                    return new Users();

                if (className.Equals("Products"))
                    return new Products();

                if (className.Equals("Privilages"))
                    return new Privilages();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nie udało się stowrzyć objektu" + ex.ToString());
            }
            return interfejs;
        }
    }
}
