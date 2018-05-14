using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasada
{
    class PersonFacade
    {
        Person user;

        public PersonFacade(Person user) {
            this.user = user;
        }

        public string getName()
        {
            return "Imie i nazwisko: " + this.user.getImie()+ " " +this.user.getNazwisko();
        }
    }
}
